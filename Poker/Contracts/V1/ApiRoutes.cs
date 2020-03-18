using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Health
        {
            public const string HealthCheck = Base + "/health";
        }
        public static class Poker
        {
            public const string GetPokerWinner = Base + "/poker/winner";
        }
    }
}
