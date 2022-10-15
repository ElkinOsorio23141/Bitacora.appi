using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Ekisa.Api.BotFetal.Configuration
{
    public class NotificationHub: Hub
    {
        public static List<Client> ConnectedUsers { get; set; } = new List<Client>();
              
        public void Connect(string numeroCliente)
        {
            Client c = new()
            {
                NumeroCliente = numeroCliente,
                ID = Context.ConnectionId
            };
            ConnectedUsers.Add(c);         
        }

        public void Send(string message, string idConection)
        {
            var sender = ConnectedUsers.Find(u => u.ID.Equals(Context.ConnectionId));
            Clients.Client(idConection).SendAsync(sender.NumeroCliente, message);
        }
    }

    public class Client
    {
        public string NumeroCliente { get; set; }
        public string ID { get; set; }
    }
}
