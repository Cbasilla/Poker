using System.Collections.Generic;

namespace Poker.Contracts.V1.Responses
{
    public class ErrorResponse : BaseResponse
    {

        public ErrorResponse()
        {
            this.ErrorMessages = new List<object>();
        }

        public List<object> ErrorMessages { get; set; }

    }
}
