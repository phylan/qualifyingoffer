using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QO.Application.Models;
using QO.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualifyingOfferController
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
