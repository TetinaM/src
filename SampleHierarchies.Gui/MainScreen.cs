using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.IO;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{




    #region Properties And Ctor
    /// <summary>
    /// Settings
    /// </summary>
    private readonly ISettings _settings;

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        ISettings settings)
    {
        _settings = settings;
        _dataService = dataService;
        _animalsScreen = animalsScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        //konwersja koloru z ciągu znaków na ConsoleColor
        Console.ForegroundColor = ConvertColorNameToConsoleColor(_settings.MainScreenColor);
        
        

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Create a new settings");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        Console.WriteLine("Not yet implemented.");
                        // TODO: implement
                        break;

                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
    //implementacja mechanizmu konwersji ciągów znaków w ConsoleColor
    private ConsoleColor ConvertColorNameToConsoleColor(string colorName)
    {
        ConsoleColor color;
        if (Enum.TryParse(colorName, out color))
        {
            return color;
        }
        else
        {
            
            return ConsoleColor.White;
        }
    }
}







    #endregion // Public Methods
