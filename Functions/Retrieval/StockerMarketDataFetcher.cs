using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace gregpelle.Retrieval
{
    public static class StockerMarketDataFetcher
    {
        [FunctionName("StockerMarketDataFetcher")]
        public static void Run([TimerTrigger("0 0 20 * * Mon-Fri")]TimerInfo myTimer,
        [CosmosDB(
                databaseName: "ToDoItems",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection",
                Id = "{ToDoItemId}",
                PartitionKey = "{ToDoItemPartitionKeyValue}")]ToDoItem toDoItem,
         ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
