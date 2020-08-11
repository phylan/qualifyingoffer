using MediatR;
using QO.Application.Interfaces;
using QO.Application.Models;
using QO.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QO.Application.Queries
{
    public class QualifyingOfferQuery : IRequest<QualifyingOfferViewModel>
    {
        public class Handler : IRequestHandler<QualifyingOfferQuery, QualifyingOfferViewModel>
        {
            private readonly QualifyingOfferService _qoService;
            private readonly ISalaryScraper _scraper;

            public Handler(QualifyingOfferService qoService, ISalaryScraper scraper)
            {
                _qoService = qoService;
                _scraper = scraper;
            }

            public async Task<QualifyingOfferViewModel> Handle(QualifyingOfferQuery request, CancellationToken cancellationToken)
            {
                var players = await _scraper.Scrape();

                return new QualifyingOfferViewModel
                {
                    IncludedPlayers = _qoService.SelectIncludedPlayers(players),
                    Amount = _qoService.CalculateQualifyingOffer(players)
                };
            }
        }
    }
}
