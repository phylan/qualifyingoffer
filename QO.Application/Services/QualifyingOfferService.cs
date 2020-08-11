using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QO.Application.Models;
using QO.Application.Config;
using Microsoft.Extensions.Options;

namespace QO.Application.Services
{
    public class QualifyingOfferService
    {
        private readonly QualifyingOfferConfig _config;

        public QualifyingOfferService(IOptions<QualifyingOfferConfig> config)
        {
            _config = config.Value;
        }

        public decimal CalculateQualifyingOffer(IList<Player> players)
            => SelectIncludedPlayers(players).Select(p => p.Salary.Value).Average();

        public IList<Player> SelectIncludedPlayers(IList<Player> players) 
            => players
            .Where(p => p.Salary.HasValue)
            .OrderByDescending(p => p.Salary)
            .Take(_config.TopQuantity)
            .ToList();
    }
}
