using Microsoft.AspNetCore.Mvc;
using Poker.Contracts.V1;
using Poker.Contracts.V1.Requests;
using Poker.Contracts.V1.Responses;
using Poker.Domain;
using Poker.Helpers;
using Poker.Services.CardService;
using Poker.Services.PokerServices;
using Poker.Utilities;

namespace Poker.Controllers.V1
{
    public class PokerController : Controller
    {
        private readonly IPokerService _pokerService;
        private readonly ICardService _cardService;
        public PokerController(IPokerService pokerService, ICardService cardService)
        {
            _pokerService = pokerService;
            _cardService = cardService;
        }

        [HttpPost(ApiRoutes.Poker.GetPokerWinner)]
        public IActionResult GetPokerWinner([FromBody] PokerRequest pokerRequest)
        {
            if(!ValidationUtility.validateCards(pokerRequest, _cardService, _pokerService))
            {
                var error = new ErrorResponse();
                error.ErrorMessages.Add(MessageHelper.IsNotValid);
                error.Success = false;
                return BadRequest(error);
            }
            // identify winner 
            _pokerService.CheckPokerWinner();

            PokerResponse response = _pokerService.GetPokerWinner();
            return Ok(response);
        }
    }
}
