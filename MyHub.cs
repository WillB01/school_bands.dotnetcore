using FavoriteBand.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FavoriteBand
{
    public class MyHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync(
                 "ReceivePost", "ChatKewl",
                     DateTimeOffset.UtcNow,
                     "Hello do you like music?");
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task PostMessage(string name, string text)
        {
            var message = new ForumMessage
            {
                SenderName = name,
                Text = text,
                PostAt = DateTimeOffset.UtcNow
            };

            await Clients.All.SendAsync(
                "ReceivePost",
                message.SenderName,
                message.PostAt,
                message.Text);
        }
    }
}