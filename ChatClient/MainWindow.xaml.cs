using ChatClient.Services;
using System.Windows;

namespace ChatClient;

public partial class MainWindow : Window
{
    private readonly ChatService _chatService = new();

    public MainWindow()
    {
        InitializeComponent();

        _chatService.MessageReceived += (user, message) =>
        {
            Dispatcher.Invoke(() =>
            {
                ChatList.Items.Add($"{user}: {message}");
            });
        };

        Loaded += async (_, __) =>
        {
            await _chatService.ConnectAsync();
        };
    }

    private async void Send_Click(object sender, RoutedEventArgs e)
    {
        await _chatService.SendMessage(
            UsernameBox.Text,
            MessageBox.Text
        );

        MessageBox.Text = "";
    }
}