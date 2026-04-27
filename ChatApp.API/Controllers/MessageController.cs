using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers
{

    /// <summary>
    /// Provides endpoints for managing chat messages.
    /// </summary>
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessagesController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var messages = await _service.GetAllAsync();
            return Ok(messages);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMessageRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.User) ||
                string.IsNullOrWhiteSpace(request.Text))
            {
                return BadRequest("User and text are required.");
            }

            var result = await _service.CreateAsync(request.User, request.Text);

            return Created(string.Empty, result);
        }
    }

    public class CreateMessageRequest
    {
        public string User { get; set; }
        public string Text { get; set; }
    }
} 
