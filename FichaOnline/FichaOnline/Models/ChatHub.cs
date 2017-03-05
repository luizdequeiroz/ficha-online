using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace FichaOnline.Models
{
    public class ChatHub : Hub
    {
        public void EnviarMensagem(string de, string msg)
        {
            Clients.All.AddMessage(de, msg);
        }        
    }
}