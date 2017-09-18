using System;
using System.Threading.Tasks;
using Matrix.NET.Abstractions;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;
using Microsoft.Extensions.Caching.Distributed;
using PeykOn.Data;
using static PeykOn.Helpers.Extensions;
using PeykOn.Models.Caching;

namespace PeykOn.Services
{
    public interface IRegistrationService
    {
        Task<UserInteractiveAuthResponseBase> GenerateSessionAsync(RegisterRequest<AuthenticationData> request);

        Task<RegistrationCacheData> GetCacheDataAsync(string session);

        Task<UserInteractiveAuthResponseBase> CreateAccountAsync(RegisterRequest<AuthenticationData> request);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly PeykOnDbContext _dbContext;

        private readonly IDistributedCache _cache;

        public RegistrationService(PeykOnDbContext dbContext, IDistributedCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<UserInteractiveAuthResponseBase> GenerateSessionAsync(
            RegisterRequest<AuthenticationData> request)
        {
            string sessionKey;
            bool sessionKeyIsDuplicate;
            var cacheData = new RegistrationCacheData
            {
                Request = request,
            };
            var caheOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(1)
            };

            do
            {
                sessionKey = GenerateAlphanumericString(64);
                var cacheTuple = await _cache.SetObjectIfNotExistsAsync(sessionKey, cacheData, caheOptions);
                sessionKeyIsDuplicate = cacheTuple.Exists;
            } while (sessionKeyIsDuplicate);

            return new UserInteractiveAuthResponse
            {
                Session = sessionKey,
                Flows = new[]
                {
                    new UserInteractiveAuthFlow
                    {
                        Stages = new[]
                        {
                            Constants.Authentication.Types.Dummy,
                        }
                    }
                }
            };
        }

        public Task<RegistrationCacheData> GetCacheDataAsync(string session) =>
            _cache.GetObjectAsync<RegistrationCacheData>(session)
                .ContinueWith(t => t.Result.Value);

        public Task<UserInteractiveAuthResponseBase> CreateAccountAsync(
            RegisterRequest<AuthenticationData> request)
        {
            if (request.Kind == UserAccountKind.Guest)
            {
                // ToDo create account
            }
            
            switch (request.Auth.Type)
            {
                case AuthenticationType.Dummy:
                    
                    // ToDo create account
                    break;
                case AuthenticationType.None:
                case AuthenticationType.PasswordBased:
                case AuthenticationType.GoogleReCaptcha:
                case AuthenticationType.TokenBased:
                case AuthenticationType.OAuth2Based:
                case AuthenticationType.EmailBased:
                default:
                    throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}