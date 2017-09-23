using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using PeykOn.Models.Caching;
using PeykOn.Services;
using Constants = Matrix.NET.Abstractions.Constants;

// ReSharper disable once CheckNamespace
namespace PeykOn.Controllers
{
    [Route(Constants.Routes.ClientAuthentication.Registration)]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _regService;

        public RegistrationController(IRegistrationService regService)
        {
            _regService = regService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        /// <!--
        ///  if sessionKey exists in cache AND account kind is the same as in cache
        ///      process with flows/stages
        ///  else
        ///      generate a new session
        /// -->
        [HttpPost]
        public async Task<IActionResult> Index(
            [FromBody] RegisterRequest<AuthenticationData> request, [FromQuery] UserAccountKind? kind)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            request.Kind = kind ?? UserAccountKind.User;
            UserInteractiveAuthResponseBase authResponse;

            if (request.Kind == UserAccountKind.Guest)
            {
                authResponse = await _regService.CreateGuestAccountAsync();
            }
            else
            {
                if (request.Auth?.Session != null &&
                    Regex.IsMatch(request.Auth.Session, @"^(?:[a-z]|\d){64}$", RegexOptions.IgnoreCase))
                {
                    var cacheData = await _regService.GetCacheDataAsync(request.Auth.Session);
                    if (cacheData != null && HaveSameRegistrationInfo(cacheData, request))
                    {
                        // ToDo check whether all steps are completed
                        authResponse = await _regService.CreateUserAccountAsync(request);
                    }
                    else
                    {
                        authResponse = await _regService.GenerateSessionAsync(request);
                    }
                }
                else
                {
                    authResponse = await _regService.GenerateSessionAsync(request);
                }
            }

            return StatusCode((int) authResponse.StatusCode, authResponse);
        }

        private static bool HaveSameRegistrationInfo(RegistrationCacheData cacheData,
            RegisterRequest<AuthenticationData> request2) =>
            cacheData.Kind == request2.Kind &&
            (cacheData.Request.UserName?.Equals(request2.UserName, StringComparison.OrdinalIgnoreCase) ?? true);
    }
}