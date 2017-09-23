using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeykOn.Data;
using Constants = Matrix.NET.Abstractions.Constants;

// ReSharper disable once CheckNamespace
namespace PeykOn.Controllers
{
    [Route(Constants.Routes.ClientAuthentication.Logout)]
    public class LogoutController : Controller
    {
        private readonly PeykOnDbContext _dbContext;

        public LogoutController(PeykOnDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromQuery(Name = "access_token")] string accessToken)
        {
            IActionResult result;

            if (accessToken != null)
            {
                var token = await _dbContext.AccessTokens.SingleOrDefaultAsync(t => t.Token == accessToken);
                if (token != null)
                {
                    _dbContext.Remove(token);
                    await _dbContext.SaveChangesAsync();
                    result = Ok(new object());
                }
                else
                {
                    result = NotFound();
                }
            }
            else
            {
                result = Unauthorized();
            }

            return result;
        }
    }
}