using Microsoft.Extensions.Logging;
using PRDM_TP03.Services;
using PRDM_TP03.ViewModels;
using PRDM_TP03.Views;

namespace PRDM_TP03
{
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

            builder.Services.AddSingleton<IRastreamentoService, RastreamentoService>();

            builder.Services.AddTransient<BuscaViewModel>();
            builder.Services.AddTransient<ResultadoViewModel>();

            builder.Services.AddTransient<BuscaPage>();
            builder.Services.AddTransient<ResultadoPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
