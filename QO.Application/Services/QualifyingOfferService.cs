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
        private readonly IList<Player> _players;

        public QualifyingOfferService(QualifyingOfferConfig config, IList<Player> players)
        {
            _config = config;
            _players = players;
        }

        public decimal Amount => IncludedPlayers.Select(p => p.Salary.Value).Average();

        public IList<Player> IncludedPlayers => _players
            .Where(p => p.Salary.HasValue)
            .OrderByDescending(p => p.Salary)
            .Take(_config.TopQuantity)
            .ToList();

        public int TopQuantity => _config.TopQuantity;

        public IList<Player> ExcludedPlayers => _players.Where(p => !p.Salary.HasValue).ToList();

    }
}
