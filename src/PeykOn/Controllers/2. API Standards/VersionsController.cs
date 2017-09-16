using Matrix.NET.Abstractions;
using Matrix.NET.Models.Responses;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace
namespace PeykOn.Controllers
{
    [Route(Constants.Routes.ApiStandards.Versions)]
    public class VersionsController : Controller
    {
        [HttpGet]
        public VersionsResponse Index() => new VersionsResponse
        {
            Versions = new[]
            {
                "r0.2.0",
            }
        };
    }
}
