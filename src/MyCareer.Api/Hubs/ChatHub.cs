﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MyCareer.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
