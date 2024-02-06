namespace Template.Lambda.Functions;

using Microsoft.Extensions.Logging;

#pragma warning disable SYSLIB1006
internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Information, Message = "Data created. id=[{id}]")]
    public static partial void InfoDataCreated(this ILogger logger, string id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Data deleted. id=[{id}]")]
    public static partial void InfoDataDeleted(this ILogger logger, string id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Timer event raised.")]
    public static partial void InfoTimerEventRaised(this ILogger logger);
}
#pragma warning restore SYSLIB1006
