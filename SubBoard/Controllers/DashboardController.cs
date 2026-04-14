using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubBoard.Application.Services;

namespace SubBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _serv;
        public DashboardController(IDashboardService serv)
        {
            _serv = serv;
        }
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var GetDash = await _serv.GetDashboardAsync();
            return Ok(GetDash);

        }
    }
}
