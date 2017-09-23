using System;
using System.Linq;
using System.Threading.Tasks;
using Matrix.NET.Abstractions;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using PeykOn.Data;
using PeykOn.Models;
using static PeykOn.Helpers.Extensions;
using PeykOn.Models.Caching;

namespace PeykOn.Services
{
    public interface IRegistrationService
    {
        Task<UserInteractiveAuthResponseBase> GenerateSessionAsync(RegisterRequest<AuthenticationData> request);

        Task<RegistrationCacheData> GetCacheDataAsync(string session);

        Task<UserInteractiveAuthResponseBase> CreateUserAccountAsync(RegisterRequest<AuthenticationData> request);

        Task<UserInteractiveAuthResponseBase> CreateGuestAccountAsync();
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
                Kind = request.Kind,
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

        public Task<UserInteractiveAuthResponseBase> CreateUserAccountAsync(RegisterRequest<AuthenticationData> request)
        {
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

        public async Task<UserInteractiveAuthResponseBase> CreateGuestAccountAsync()
        {
            const string homeServer = "peykon.ga";
            await Task.Delay(1);

            string userName;
            bool userIdExists;
            do
            {
                userName = GenerateAlphanumericString(10);
                userIdExists =
                    await _dbContext.Users.AnyAsync(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
            } while (userIdExists);

            var guestUser = new User
            {
                Name = userName,
                Kind = UserAccountKind.Guest,
            };
            _dbContext.Add(guestUser);
            _dbContext.AccessTokens.Add(new AccessToken
            {
                User = guestUser,
                DeviceId = "guest_device",
                Token = GenerateAlphanumericString(256),
            });
            await _dbContext.SaveChangesAsync();

            var resposne = new RegisterResponse
            {
                AccessToken = guestUser.AccessTokens.Single().Token,
                HomeServer = homeServer,
                UserId = $"@{guestUser.Name}:{homeServer}",
                DeviceId = guestUser.AccessTokens.Single().DeviceId,
            };

            return resposne;
        }
    }
}