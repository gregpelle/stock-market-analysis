using System;
using System.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace gregpelle.stockmarketanalysis
{
    public static class RetrieveDataFromAlphaVantage
    {
        [FunctionName("RetrieveDataFromAlphaVantage")]
        public static void Run([ServiceBusTrigger("%SERVICEBUS_TopicName%", "%SERVICEBUS_SubscriptionName%", Connection = "SERVICEBUS_ConnectionString")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
