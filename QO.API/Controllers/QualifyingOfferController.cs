using MediatR;
using QO.Application.Models;
using QO.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace QO.API.Controllers
{
    public class QualifyingOfferController : ApiController
    {
        private readonly IMediator _mediator;

        public QualifyingOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<QualifyingOfferViewModel> Get() => await _mediator.Send(new QualifyingOfferQuery());
    }
}
