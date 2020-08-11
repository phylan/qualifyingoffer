using QO.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QO.Application.Interfaces
{
    public interface ISalaryScraper
    {
        Task<IList<Player>> Scrape();
    }
}
