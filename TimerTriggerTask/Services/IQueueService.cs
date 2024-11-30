﻿namespace TimerTriggerTask.Services;

public interface IQueueService
{
    Task SendMessageAsync(string message);
    Task<string> ReceiveMessageAsync();
}
