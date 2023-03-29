using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyCareer.Domain.Configurations;
using MyCareer.Service.Interfaces.Messages;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Messages
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMessageService messageService;

        public MessageController(IHubContext<MessageHub> hubContext, IMessageService messageService)
        {
            this.hubContext = hubContext;
            this.messageService = messageService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(string user, string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
            return Ok();
        }
    }
}
