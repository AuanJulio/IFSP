using Microsoft.Extensions.Logging;
using TarefasApp.Services;

// Auan Julio Galvão dos Santos CB3030369
// Paulo Eduardo da Silva Pessoa CB303092x

namespace TarefasApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<TarefaService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<DetalhesPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}