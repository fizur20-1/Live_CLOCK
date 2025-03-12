using Microsoft.AspNetCore.Mvc;

namespace Live_Clock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTime()
        {
            var times = new
            {
                Bangladesh = GetTimeForTimeZone("Asia/Dhaka"),
                UK = GetTimeForTimeZone("Europe/London"),
                Germany = GetTimeForTimeZone("Europe/Berlin")
            };
            return Ok(times);
        }

        private string GetTimeForTimeZone(string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            return time.ToString("yyyy-MM-dd hh:mm:ss tt"); 
        }

    }
}
