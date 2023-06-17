using ChatApplicationApi.Domain;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplicationApi.Hubs
{
    public class ChatHub : Hub
    {

        private static List<Message> userMessages = new List<Message>(); // Mesajları tutmak için bir liste oluştur

        private static List<string> users = new List<string>();


        public List<string> GetAllUsers()
        {
            return users;
        }

        public List<Message> GetAllMessages()
        {
            return userMessages;
        }

        public Task UserConnected(string userName)
        {
            users.Add(userName);

            return Clients.AllExcept(Context.ConnectionId).SendAsync("NewUserConnected", userName);
        }

        public Task UserDisconnected(string userName)
        {
            users.Remove(userName);

            return Clients.AllExcept(Context.ConnectionId).SendAsync("NewUserDisconnected", userName);
        }

        public async Task SendMessage(string userName, string message)
        {
            // Mesajı al ve listeye ekle
            Message newMessage = new Message
            {
                Id = Guid.NewGuid(),
                Text = message,
                UserId =userName // İstemci bağlantı kimliğini kullanıcı kimliği olarak ayarla
            };

            userMessages.Add(newMessage);

            // Mesajı istemcilere yayınla
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveMessage", newMessage);

        }

        public IEnumerable<Message> GetMessages()
        {
            return userMessages;
        }
    }
}
