using System.Text.Json;

namespace Microsoft.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static void LogJsonTrace<T>(this ILogger logger, string message, T arg)
        {
            var json = JsonSerializer.Serialize<T>(arg, new JsonSerializerOptions { WriteIndented = true });
            logger.LogTrace($"{message}:\n{json}");
        }
        public static void LogJsonDebug<T>(this ILogger logger, string message, T arg)
        {
            var json = JsonSerializer.Serialize<T>(arg, new JsonSerializerOptions { WriteIndented = true });
            logger.LogDebug($"{message}:\n{json}");
        }

        public static void LogJsonInformation<T>(this ILogger logger, string message, T arg)
        {
            var json = JsonSerializer.Serialize<T>(arg, new JsonSerializerOptions { WriteIndented = true });
            logger.LogInformation($"{message}:\n{json}");
        }

        public static void LogJsonWarning<T>(this ILogger logger, string message, T arg)
        {
            var json = JsonSerializer.Serialize<T>(arg, new JsonSerializerOptions { WriteIndented = true });
            logger.LogWarning($"{message}:\n{json}");
        }

        public static void LogJsonError<T>(this ILogger logger, string message, T arg)
        {
            var json = JsonSerializer.Serialize<T>(arg, new JsonSerializerOptions { WriteIndented = true });
            logger.LogError($"{message}:\n{json}");
        }
    }
}
