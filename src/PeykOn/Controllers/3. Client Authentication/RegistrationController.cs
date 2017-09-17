using System;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using PeykOn.Data;
using static PeykOn.Helpers.Helpers;
using Constants = Matrix.NET.Abstractions.Constants;

// ReSharper disable once CheckNamespace
namespace PeykOn.Controllers
{
    [Route(Constants.Routes.ClientAuthentication.Registration)]
    public class RegistrationController : Controller
    {
        private readonly PeykOnDbContext _dbContext;

        public RegistrationController(PeykOnDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Index(
            [FromBody] RegisterRequest<AuthenticationData> request,
            [FromQuery] UserAccountKind kind = UserAccountKind.User
            )
        {
            UserInteractiveAuthResponseBase response;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (request.Auth?.Type == AuthenticationType.Dummy &&
                Guid.TryParse(request.Auth?.Session, out var guid))
            {
                response = new RegisterResponse
                {
                    UserId = $"@{GenerateAlphanumericString(20).ToLower()}:peykon.ga",
                    AccessToken = Guid.NewGuid().ToString(),
                    HomeServer = "peykon.ga",
                    DeviceId = GenerateAlphanumericString(10),
                };
            }
            else
            {
                response = new UserInteractiveAuthResponse
                {
                    Session = Guid.NewGuid().ToString(),
                    Flows = new[]
                    {
                        new UserInteractiveAuthFlow
                        {
                            Stages = new []
                            {
                                Constants.Authentication.Types.Dummy,
                            }
                        }
                    }
                };

            }

            return Json(response);
        }
    }
}
