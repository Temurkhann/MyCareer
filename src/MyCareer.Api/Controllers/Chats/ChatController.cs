using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Chats;
using MyCareer.Service.Interfaces.Chats;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Chats
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;
        private readonly IChatService chatService;

        public ChatController(IHubContext<ChatHub> hubContext, IChatService chatService)
        {
            this.hubContext = hubContext;
            this.chatService = chatService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(string user, string message)
        {
            await hubContext.Clients.All.SendAsync("RecieveMessage", user, message);
            return Ok();
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await chatService.GetAll(@params));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await chatService.GetAsync(u => u.Id == id));
    }
}
