using Microsoft.AspNetCore.Mvc;
using SubBoard.Application.Dtos.Subscription;
using SubBoard.Application.Services;

namespace SubBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _serv;

        public SubscriptionController(ISubscriptionService serv)
        {
            _serv = serv;
        }

        // GET: api/subscription
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var subscriptions = await _serv.GetAllAsync();
            return Ok(subscriptions);
        }

        // GET: api/subscription/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await _serv.GetById(id);
            
            return Ok(subscription);
        }

        // POST: api/subscription
        [HttpPost]
        public async Task<IActionResult> AddSubscription([FromBody] CreateSubscriptionDto dto)
        {
            await _serv.AddAsync(dto);
            return Ok(new { message = "Subscription created successfully" });
        }

        // PUT: api/subscription
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubscriptionDto dto)
        {
            await _serv.UpdateAsync(dto);
            return Ok(new { message = "Subscription updated successfully" });
        }

        // DELETE: api/subscription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serv.DeleteAsync(id);
            return Ok(new { message = "Subscription deleted successfully" });
        }
    }
}
