using System;
using System.Collections.Generic;
using System.Text;

namespace QO.Infrastructure.Config
{
    public class SalaryScraperConfig
    {
        public string Url { get; set; }
        public string TableId { get; set; }
        public string PlayerNameClass { get; set; }
        public string PlayerSalaryClass { get; set; }
        public string PlayerYearClass { get; set; }
        public string PlayerLevelClass { get; set; }
    }
}
