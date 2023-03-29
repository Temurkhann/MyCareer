using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyCareer.Api.Hubs;
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
        public async ValueTask<IActionResult> CreateAsync([FromForm] ChatForCreationDTO dto)
        {
            var chat =  await chatService.CreateAsync(dto);
            await hubContext.Clients.All.SendAsync("RecieveMessage", chat.Id.ToString());
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
