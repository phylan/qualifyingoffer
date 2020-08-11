using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using QO.Application.Interfaces;
using QO.Application.Models;
using QO.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QO.Infrastructure.Services
{
    public class SalaryScraper : ISalaryScraper
    {
        private readonly HttpClient _httpClient;
        private readonly SalaryScraperConfig _config;

        public SalaryScraper(HttpClient httpClient, IOptions<SalaryScraperConfig> config)
        {
            _httpClient = httpClient;
            _config = config.Value;
        }

        public async Task<IList<Player>> Scrape()
        {
            var rawHtml = await GetSalaryHtml();

            var doc = new HtmlDocument();

            doc.LoadHtml(rawHtml);

            return ParseSalaryHtml(doc).ToList();
        }

        private async Task<string> GetSalaryHtml()
        {
            try
            {
                var response = await _httpClient.GetAsync("");
                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                throw new Exception("An error occurred while retrieving salary data");
            }
        }

        private IEnumerable<Player> ParseSalaryHtml(HtmlDocument doc)
        {
            var rows = doc.DocumentNode
                .SelectSingleNode($"//*[@id=\"{_config.TableId}\"]")
                .SelectNodes("//tr");

            List<Player> players = new List<Player>();

            foreach(var row in rows)
            {
                var yearParsed = int.TryParse(row.SelectSingleNode($"td[@class=\"{_config.PlayerYearClass}\"]").InnerText, out var parsedYear);

                players.Add(new Player
                {
                    Name = row.SelectSingleNode($"td[@class=\"{_config.PlayerNameClass}\"]").InnerText,
                    RawSalary = row.SelectSingleNode($"td[@class=\"{_config.PlayerSalaryClass}\"]").InnerText,
                    Year = yearParsed ? parsedYear : (int?)null,
                    Level = row.SelectSingleNode($"td[@class=\"{_config.PlayerLevelClass}\"]").InnerText
                });
            }

            return players;
        }
    }
}
