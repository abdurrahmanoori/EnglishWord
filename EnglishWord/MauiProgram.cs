using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using System.Text.Json;

namespace EnglishWord
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var secretsPath = Path.Combine(AppContext.BaseDirectory, "secrets.json");
            if (File.Exists(secretsPath))
            {
                var json = JsonDocument.Parse(File.ReadAllText(secretsPath));
                var key = json.RootElement.GetProperty("SyncfusionLicenseKey").GetString();
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(key);
            }

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
