using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    public class WelcomeMessage
    {
        public string Message { get; }

        public WelcomeMessage(string message)
        {
            Message = message;
        }
    }
}