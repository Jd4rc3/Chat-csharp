using System.Diagnostics.CodeAnalysis;
using SC.Configuration.Provider.Mongo;

namespace Chat.AppServices.Auth.Extensions
{
    /// <summary>
    /// ConfigurationExtensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ConfigurationExtensions
    {
        /// <summary>
        ///   Agrega archivo JSON como proveedor de configuración.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddJsonProvider(this IConfigurationBuilder configuration)
                => configuration
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("config/appsettings.json", optional: true, reloadOnChange: true);
    }
}