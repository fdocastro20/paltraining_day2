using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/")]
    public class WelcomeController : ControllerBase
    {

        private readonly WelcomeMessage message;
        public WelcomeController(WelcomeMessage msg)
        {
            this.message = msg;

        }
        [HttpGet]
        public string SayHello() => message.Message;
    }
}