using System.Net;

namespace DeckOfCards.Services.Common
{
    public class CustomException
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ExceptionTrace { get; set; }
    }
}