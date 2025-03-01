using Microsoft.AspNetCore.Mvc;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")] // This means the route is "api/actions"
    [ApiController]
    public class ActionsController : ControllerBase
    {
        // GET: api/actions/items
        [HttpGet("items")]
        public ActionResult<IEnumerable<string>> GetItems()
        {
            var items = new List<string> { "Item 1", "Item 2", "Item 3" };
            return Ok(items);
        }

          // POST: api/actions/buttonClicked
        [HttpPost("buttonClicked")]
        public IActionResult ButtonClicked()
        {
            // Log a message to the console
            System.Console.WriteLine("Button clicked");
            return Ok(new { message = "Button clicked" });
        }
    }
}
