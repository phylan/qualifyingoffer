using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QO.Application.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string RawSalary { get; set; }
        public int? Year { get; set; }
        public string Level { get; set; }

        public decimal? Salary
        {
            get
            {
                var numeric = string.Join("", RawSalary.Where(c => char.IsDigit(c) || c == '.'));

                return decimal.TryParse(numeric, out var result) ? result : (decimal?)null;
            }
        }

    }
}
