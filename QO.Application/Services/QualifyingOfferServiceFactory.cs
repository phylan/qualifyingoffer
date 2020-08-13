using Microsoft.Extensions.Options;
using QO.Application.Config;
using QO.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QO.Application.Services
{
    public class QualifyingOfferServiceFactory
    {
        private readonly QualifyingOfferConfig _config;

        public QualifyingOfferServiceFactory(IOptions<QualifyingOfferConfig> config)
        {
            _config = config.Value;
        }

        public QualifyingOfferService Create(IList<Player> players) => new QualifyingOfferService(_config, players);
    }
}
