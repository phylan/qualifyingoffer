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
            private readonly QualifyingOfferServiceFactory _qoServiceFactory;
            private readonly ISalaryScraper _scraper;

            public Handler(QualifyingOfferServiceFactory qoServiceFactory, ISalaryScraper scraper)
            {
                _qoServiceFactory = qoServiceFactory;
                _scraper = scraper;
            }

            public async Task<QualifyingOfferViewModel> Handle(QualifyingOfferQuery request, CancellationToken cancellationToken)
            {
                var players = await _scraper.Scrape();

                var qoService = _qoServiceFactory.Create(players);

                return new QualifyingOfferViewModel
                {
                    IncludedPlayers = qoService.IncludedPlayers,
                    ExcludedPlayers = qoService.ExcludedPlayers,
                    Amount = qoService.Amount,
                    TopQuantity = qoService.TopQuantity
                };
            }
        }
    }
}
