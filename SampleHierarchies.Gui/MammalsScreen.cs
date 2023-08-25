using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using System.IO;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    /// <summary>
    /// Settings.
    /// </summary>
    #region Properties And Ctor
    private readonly ISettings _settings;
    

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;
    private LionsScreen _lionsScreen;
    private CatsScreen _catsScreen;
    private ElephantsScreen _elephantsScreen;
    private TigersScreen _tigersScreen;
  
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    /// 
    public MammalsScreen(DogsScreen dogsScreen, LionsScreen lionsScreen,CatsScreen catsScreen, ISettings settings, ElephantsScreen elephantsScreen, TigersScreen tigersScreen)
    {
        _catsScreen = catsScreen;  
        _settings = settings;
        _dogsScreen = dogsScreen;
        _lionsScreen = lionsScreen;
        _elephantsScreen = elephantsScreen;
        _tigersScreen = tigersScreen;
    }
    
    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        //konwersja koloru z ciągu znaków na ConsoleColor
        Console.ForegroundColor = ConvertColorNameToConsoleColor(_settings.MammalsScreenColor);
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Cats");
            Console.WriteLine("3. Lions");
            Console.WriteLine("4. Elephants");
            Console.WriteLine("5. Tigers");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;
                    case MammalsScreenChoices.Cats:
                        _catsScreen.Show();
                        break;
                    case MammalsScreenChoices.Lions:
                        _lionsScreen.Show();
                        break;
                    case MammalsScreenChoices.Elephants:
                        _elephantsScreen.Show();
                        break;
                    case MammalsScreenChoices.Tigers:
                        _tigersScreen.Show();
                        break;
                    case MammalsScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods
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
#endregion // Private Methods
}
