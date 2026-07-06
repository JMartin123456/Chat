using Microsoft.AspNetCore.SignalR;
using ChatServer.Data;
using ChatServer.Models;

namespace ChatServer.Hubs;

public class ChatHub : Hub
{
    private readonly ChatContext _context;

    public ChatHub(ChatContext context)
    {
        _context = context;
    }

    public async Task SendMessage(string username, string message)
    {
        var msg = new Message
        {
            Username = username,
            Text = message,
            Created = DateTime.Now
        };

        _context.Messages.Add(msg);
        await _context.SaveChangesAsync();

        await Clients.All.SendAsync("ReceiveMessage", username, message);
    }
}