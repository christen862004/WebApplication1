using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Hubs
{
    public class ChatHub:Hub
    {
        //Abdalla ==>Moudy Thorw Hub
        public async Task SendMessage(string name,string message,int age)
        {
            //Context.UserIdentifier
            //Context.ConnectionId
            //logic db
            //send MEssage To Another connected Client
            await Clients.All.SendAsync("ReciveNewMessage",name,message);
            

        }
        public override Task OnConnectedAsync()
        {
            
            return base.OnConnectedAsync();
        }
    }
    
}
