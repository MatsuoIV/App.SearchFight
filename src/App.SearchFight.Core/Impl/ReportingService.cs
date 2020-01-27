using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.SearchFight.Core.Schemas;
using App.SearchFight.Core.Services;

namespace App.SearchFight.Core.Impl
{
    public class ReportingService : IReportingService
    {
        public IList<string> GetSearchResultsReport(IList<SearchResultSchema> searchResults)
        {
            if (searchResults == null || searchResults.Count == 0)
                throw new Exception("Reporting Service: Invalid results");

            return searchResults.GroupBy(item => item.Query)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.Engine}: {item.Result}"))}")
                .ToList();
        }

        public IList<string> GetWinnersByEngineReport(IEnumerable<EngineWinnerSchema> engineWinners)
        {
            if (engineWinners == null || engineWinners.Count() == 0)
            {
                throw new Exception("Reporting Service: Invalid results");
            }

            List<string> results = new List<string>();

            foreach (EngineWinnerSchema engineWinner in engineWinners)
            {
                StringBuilder winnerReport = new StringBuilder();
                winnerReport.Append(engineWinner.Engine + " winner: ");
                winnerReport.Append(engineWinner.Term);
                results.Add(winnerReport.ToString());
            }

            return results;
        }

        public string GetAbsoluteWinnerReport(EngineWinnerSchema absoluteWinner)
        {
            if (absoluteWinner == null)
                throw new Exception("Reporting Service: Invalid results");

            StringBuilder grandWinnerBuilder = new StringBuilder();
            grandWinnerBuilder.Append("Total winner: ");
            grandWinnerBuilder.Append(absoluteWinner.Engine);
            return grandWinnerBuilder.ToString();
        }
    }
}
