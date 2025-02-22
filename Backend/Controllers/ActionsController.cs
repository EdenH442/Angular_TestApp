using Microsoft.AspNetCore.Mvc;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        // GET: api/actions/items
        [HttpGet("items")]
        public ActionResult<IEnumerable<string>> GetItems()
        {
            // Return a hardcoded list of items
            var items = new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
            return Ok(items);
        }

        // POST: api/actions/btnClicked
        [HttpPost("btnClicked")]
        public IActionResult ButtonClicked()
        {
            // Log a message to the console
            System.Console.WriteLine("Button clicked");
            return Ok(new { message = "Button clicked" });
        }
    }
}
