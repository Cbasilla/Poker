using Poker.Helpers.Length;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Domain
{
    public class PokerData
    {
        [Required]
        [MinLength(MinLengthHelper.NameMinLength)]
        [MaxLength(MaxLengthHelper.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string[] playerCards { get; set; }
    }
}
