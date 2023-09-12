﻿using Microsoft.Extensions.Logging;

namespace facade;

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

        builder.Services.AddTransient<GameOverPage>(); // make a new copy of the page every time

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

