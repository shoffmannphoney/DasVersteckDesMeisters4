using Microsoft.Extensions.Logging;
using Phoney_MAUI.Core;
using Phoney_MAUI.Game.General;
using Phoney_MAUI.Menu;
using Phoney_MAUI.Model;
using Phoney_MAUI.Platform;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Media;



using WebViewInterop;
using WebViewInterop.Handlers;

namespace Phoney_MAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
#if WINDOWS
        // Window w = new Window();
#endif
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitCore()
            // .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); // \'Open Sans\'
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined-Regular");
                fonts.AddFont("Font Awesome 5 Free-Solid-900.otf", "Fa-Solid");
                fonts.AddFont("cour.ttf", "Courier");                   // \'Courier\'
                fonts.AddFont("BRUSHSCI.ttf", "Brush Script MT");       // \'Brush Script MT\'
                // fonts.AddFont("Italianno-regular.ttf", "Italianno");
                fonts.AddFont("times new roman.ttf", "TimesNewRoman");      // \"Times New Roman\"
                fonts.AddFont("Raleway-regular.ttf", "Railway");        // \'Raleway\'
                fonts.AddFont("Verdana.ttf", "Verdana");                // Verdana

            }) // ;
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(BridgedWebView), typeof(BridgedWebViewHandler));
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<ISpeechToText>(SpeechToText.Default);
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddSingleton<GameViewModel>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<GeneralViewModel>();
        builder.Services.AddSingleton<MenuExtension>();
        builder.Services.AddSingleton<IUIServices, UIServices>();

        builder.Services.AddTransient<GamePage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ReplayPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<EndPage>();
        builder.Services.AddTransient<CreditsPage>();

        builder.Services.AddSingleton<IGlobalSpecs, GlobalSpecs>();
        builder.Services.AddSingleton<IGlobalData, GlobalData>();
        builder.Services.AddSingleton<IDataService, DataService>();
        builder.Services.AddSingleton<IDeviceData, DeviceData>();



        return builder.Build();

  //       GlobalSpecs.CurrentGlobalSpecs.AppRunning = IGlobalSpecs.appRunning.running;
	}
 }
