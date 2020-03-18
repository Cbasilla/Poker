using Newtonsoft.Json.Linq;
using Poker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Contracts.V1.Requests
{
    public class PokerRequest
    {
        public List<PokerData> data { get; set; }
    }
}
