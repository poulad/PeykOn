using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;
using Microsoft.AspNetCore.Mvc;
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
            [FromBody] RegisterRequest<AuthenticationData> request,
            [FromQuery] UserAccountKind kind = UserAccountKind.User
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            request.Kind = kind;
            UserInteractiveAuthResponseBase authResponse;

            // ToDo if kind is guest, allow access
            if (request.Kind == UserAccountKind.Guest || request.Auth?.Type == AuthenticationType.Dummy)
            {
                authResponse = await _regService.CreateAccountAsync(request);
                return StatusCode((int) authResponse.StatusCode, authResponse);
            }


            if (request.Auth?.Session == null ||
                !Regex.IsMatch(request.Auth.Session, @"^(?:[a-z][A-Z]\d){64}$"))
            {
                authResponse = await _regService.GenerateSessionAsync(request);
                return StatusCode((int) authResponse.StatusCode, authResponse);
            }

            var cacheData = await _regService.GetCacheDataAsync(request.Auth.Session);
            if (cacheData?.Request.Kind == request.Kind)
            {
                authResponse = await _regService.CreateAccountAsync(request);
            }
            else
            {
                authResponse = await _regService.GenerateSessionAsync(request);
            }

            return StatusCode((int) authResponse.StatusCode, authResponse);
        }
    }
}