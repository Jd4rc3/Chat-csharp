using Serilog;

namespace Chat.AppServices.Auth.Extensions
{
    /// <summary>
    /// Host Extensions
    /// </summary>
    public static class HostExtensions
    {
        /// <summary>
        /// Configura Serilog
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder) =>
            hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .Enrich.WithProperty("ApplicationName", context.HostingEnvironment.ApplicationName)
                        .Enrich.FromLogContext();
            });
    }
}