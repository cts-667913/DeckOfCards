using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DeckOfCards.Services.Common
{
    public abstract class RepositoryBase
    {
        protected virtual CustomException GetCustomException(Exception ex)
        {
            return new CustomException()
            {
                StatusCode = HttpStatusCode.BadGateway,
                ErrorMessage = ex.Message,
                ExceptionTrace = ex.StackTrace
            };
        }
    }
}
