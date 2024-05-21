using System;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Functions
{
    public class DataCollector
    {
        private readonly ILogger<DataCollector> _logger;

        public DataCollector(ILogger<DataCollector> logger)
        {
            _logger = logger;
        }

        //[Function(nameof(DataCollector))]
        public void Run([EventHubTrigger("Iothub-messages", Connection = "IoTHubConnectionString")] EventData[] events)
        {
            foreach (EventData @event in events)
            {
                _logger.LogInformation("Event Body: {body}", @event.Body.ToString());
                _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
            }
        }
    }
}
