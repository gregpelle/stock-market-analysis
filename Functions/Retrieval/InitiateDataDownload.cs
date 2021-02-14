using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.ServiceBus;
using System.Text;
using Microsoft.Azure.ServiceBus.Core;

using common;


namespace gregpelle.stockmarketanalysis
{
    public static class InitiateDataDownload
    {
        [FunctionName("InitiateDataDownload")]
        [return: ServiceBus("%SERVICEBUS_TopicName%", Connection = "SERVICEBUS_ConnectionString")]
        public static void Run([TimerTrigger("0 0 20 * * Mon-Fri"
#if DEBUG
            , RunOnStartup = true
#endif
            )] TimerInfo myTimer,
        [CosmosDB(
                databaseName: "ticker",
                collectionName: "ticker",
                ConnectionStringSetting = "DocumentDBConnectionString",
                SqlQuery = "SELECT TOP 150 * FROM c WHERE NOT IS_DEFINED(c.LastDataRetrieval) OR c.LastDataRetrieval < DateTimeAdd('day',60, GetCurrentDateTime())")]
                IEnumerable<Ticker> tickers,
        [ServiceBus("%SERVICEBUS_TopicName%", Connection = "SERVICEBUS_ConnectionString")] MessageSender messagesQueue, ILogger log)
        {
            foreach(var ticker in tickers)
            {
                // publish message to service bus
                byte[] bytes = Encoding.ASCII.GetBytes(ticker.Id);
                var message = new Message(bytes);
                messagesQueue.SendAsync(message).Wait();
            }

            log.LogInformation($"Data Download Request completed: {DateTime.Now}");
        }
    }
}
