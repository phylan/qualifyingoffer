﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QO.Application.Models
{
    public class QualifyingOfferViewModel
    {
        public decimal Amount { get; set; }
        public int TopQuantity { get; set; }
        public IList<Player> IncludedPlayers { get; set; }
        public IList<Player> ExcludedPlayers { get; set; }
    }
}
