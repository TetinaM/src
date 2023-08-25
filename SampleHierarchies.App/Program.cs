// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeanutButter.TinyEventAggregator;
using SampleHierarchies.Data;
using SampleHierarchies.Gui;
using System.IO;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace ImageTagger.FrontEnd.WinForms;

/// <summary>
/// Main class for starting up program.
/// </summary>
internal static class Program
{

    #region Main Method

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    /// <param name="args">Arguments</param>
    [STAThread]
   
    static void Main(string[] args)
    {
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;
        // ścieżka do pliku json
        var dataService = ServiceProvider.GetRequiredService<IDataService>();
        dataService.Read("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json");
        var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
        mainScreen.Show();
    }

    #endregion // Main Method

    #region Properties And Methods

    /// <summary>
    /// Service provider.
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; private set; } = null;

    /// <summary>
    /// Creates a host builder.
    /// </summary>
    /// <returns></returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                
                services.AddSingleton<ISettings, Settings>();
                services.AddSingleton<ISettingsService, SettingsService>();
                services.AddSingleton<IEventAggregator, EventAggregator>();
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<MainScreen, MainScreen>();
                services.AddSingleton<DogsScreen, DogsScreen>();
                services.AddSingleton<CatsScreen, CatsScreen>();
                services.AddSingleton<LionsScreen, LionsScreen>();
                services.AddSingleton<ElephantsScreen, ElephantsScreen>();
                services.AddSingleton<TigersScreen, TigersScreen>();
                services.AddSingleton<AnimalsScreen, AnimalsScreen>();
                services.AddSingleton<MammalsScreen, MammalsScreen>();
                
            });
    }

    #endregion // Properties And Methods
}