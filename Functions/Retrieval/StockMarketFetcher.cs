using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace gregpelle.Retrieval
{
    public static class StockMarketFetcher
    {
        [FunctionName("StockMarketFetcher")]
        public static void Run([TimerTrigger("0 0 20 * * Mon-Fri")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
