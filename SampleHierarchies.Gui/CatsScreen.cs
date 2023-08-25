using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.IO;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class CatsScreen : Screen
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
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public CatsScreen(IDataService dataService, ISettings settings)
    {
        _settings = settings;
        _dataService = dataService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        //konwersja koloru z ciągu znaków na ConsoleColor
        Console.ForegroundColor = ConvertColorNameToConsoleColor(_settings.CatsScreenColor);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all cats");
            Console.WriteLine("2. Create a new cat");
            Console.WriteLine("3. Delete existing cat");
            Console.WriteLine("4. Modify existing cat");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                CatsScreenChoices choice = (CatsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case CatsScreenChoices.List:
                        ListCats();
                        break;

                    case CatsScreenChoices.Create:
                        AddCat(); break;

                    case CatsScreenChoices.Delete:
                        DeleteCat();
                        break;

                    case CatsScreenChoices.Modify:
                        EditCatMain();
                        break;

                    case CatsScreenChoices.Exit:
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

    /// <summary>
    /// List all dogs.
    /// </summary>
    private void ListCats()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Cats is not null &&
            _dataService.Animals.Mammals.Cats.Count > 0)
        {
            Console.WriteLine("Here's a list of cats:");
            int i = 1;
            foreach (Cat cat in _dataService.Animals.Mammals.Cats)
            {
                Console.Write($"Cat number {i}, ");
                cat.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of cats is empty.");
        }
    }

    /// <summary>
    /// Add a cat.
    /// </summary>
    private void AddCat()
    {
        try
        {
            Cat cat = AddEditCat();
            _dataService?.Animals?.Mammals?.Cats?.Add(cat);
            Console.WriteLine("Cat with name: {0} has been added to a list of cats", cat.Name);
            if (_dataService != null)
            {
                _dataService.Write("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json"); // Zapis danych do pliku
                _dataService.Read("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json"); // Odczyt danych z pliku
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a cat.
    /// </summary>
    private void DeleteCat()
    {
        try
        {
            Console.Write("What is the name of the cat you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Cat? cat = (Cat?)(_dataService?.Animals?.Mammals?.Cats
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (cat is not null)
            {
                _dataService?.Animals?.Mammals?.Cats?.Remove(cat);
                Console.WriteLine("Cat with name: {0} has been deleted from a list of cats", cat.Name);
            }
            else
            {
                Console.WriteLine("Cat not found.");
            }
            if (_dataService != null)
            {
                _dataService.Write("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json"); // Zapis danych do pliku
                _dataService.Read("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json"); // Odczyt danych z pliku
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing cat after choice made.
    /// </summary>
    private void EditCatMain()
    {
        try
        {
            Console.Write("What is the name of the cat you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Cat? cat = (Cat?)(_dataService?.Animals?.Mammals?.Cats
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (cat is not null)
            {
                Cat catEdited = AddEditCat();
                cat.Copy(catEdited);
                Console.Write("Cat after edit:");
                cat.Display();
            }
            else
            {
                Console.WriteLine("Cat not found.");
            }
            if (_dataService != null)
            {
                _dataService.Write("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json"); // Zapis danych do pliku
                _dataService.Read("C:\\Users\\marti\\OneDrive\\Рабочий стол\\src — kopia\\SampleHierarchies.App\\animals.json"); // Odczyt danych z pliku
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific cat.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Cat AddEditCat()
    {
        Console.Write("What name of the cat? ");
        string? name = Console.ReadLine();
        Console.Write("What is the cat's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the cat's breed? ");
        string? breed = Console.ReadLine();
        Console.Write("What is the cat's color? ");
        string? color = Console.ReadLine();
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        if (color is null)
        {
            throw new ArgumentNullException(nameof(color));
        }

        int age = Int32.Parse(ageAsString);
        Cat cat = new Cat(name, age, breed, color);

        return cat;

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
    #endregion // Private Methods
}

