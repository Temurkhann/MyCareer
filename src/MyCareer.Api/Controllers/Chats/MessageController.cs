using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyCareer.Api.Hubs;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Chats;
using MyCareer.Service.Interfaces.Messages;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Chats
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;
        private readonly IMessageService messageService;

        public MessageController(IHubContext<ChatHub> hubContext, IMessageService messageService)
        {
            this.hubContext = hubContext;
            this.messageService = messageService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] MessageForCreationDTO dto)
        {
            var message = await messageService.CreateAsync(dto);
            await hubContext.Clients.All.SendAsync("ReceiveMessage", message.Content);
            return Ok(message);
        }
    }
}
