using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TimerTriggerTask.Services;

namespace TimerTriggerTask
{
    public class Setter
    {
        private readonly ILogger _logger;
        private readonly IQueueService _queueService;

        public Setter(ILoggerFactory loggerFactory, IQueueService queueService)
        {
            _logger = loggerFactory.CreateLogger<Setter>();
            _queueService = queueService;
        }

        [Function("Function1")]
        public async Task Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _queueService.SendMessageAsync("New Message is being sent By Setter Time Trigger");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
