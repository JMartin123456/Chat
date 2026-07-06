using Microsoft.AspNetCore.SignalR.Client;

namespace ChatClient.Services;

public class ChatService
{
    private HubConnection? _connection;

    public event Action<string, string>? MessageReceived;

    public async Task ConnectAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:****/chat")
            .WithAutomaticReconnect()
            .Build();

        _connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            MessageReceived?.Invoke(user, message);
        });

        await _connection.StartAsync();
    }

    public async Task SendMessage(string user, string message)
    {
        if (_connection is null) return;

        await _connection.InvokeAsync("SendMessage", user, message);
    }
}