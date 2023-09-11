using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using System.IO;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    
    public sealed class ElephantsScreen : Screen
    {
        #region Properties And Ctor
        /// <summary>
        /// Settings
        /// </summary>
        private readonly ISettings _settings;

        /// <summary>
        /// Date Service
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="settings"></param>
        public ElephantsScreen(IDataService dataService, ISettings settings)
        {
            _settings = settings;
            _dataService = dataService;

        }
        #endregion //Properties And Ctor

        #region Public Methods
        public override void Show()
        {
            /// <summury>
            /// Konwersja koloru z ciągu znaków na ConsoleColor
            /// </summury>

            Console.ForegroundColor = ConvertColorNameToConsoleColor(_settings.ElephantsScreenColor);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all elephants");
                Console.WriteLine("2. Create a new elephant");
                Console.WriteLine("3. Delete existing elephant");
                Console.WriteLine("4. Modify existing elephant");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    ElephantsScreenChoices choice = (ElephantsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case ElephantsScreenChoices.List:
                            ListElephants();
                            break;

                        case ElephantsScreenChoices.Create:
                            AddElephant(); break;

                        case ElephantsScreenChoices.Delete:
                            DeleteElephant();
                            break;

                        case ElephantsScreenChoices.Modify:
                            EditElephantMain();
                            break;

                        case ElephantsScreenChoices.Exit:
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
        private void ListElephants()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Elephants is not null &&
                _dataService.Animals.Mammals.Elephants.Count > 0)
            {
                Console.WriteLine("Here's a list of elephants:");
                int i = 1;
                foreach (Elephant elephant in _dataService.Animals.Mammals.Elephants)
                {
                    Console.Write($"Elephant number {i}, ");
                    elephant.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of elephants is empty.");
            }
        }

        /// <summary>
        /// Add a elephant.
        /// </summary>
        private void AddElephant()
        {
            try
            {
                Elephant elephant = AddEditElephant();
                _dataService?.Animals?.Mammals?.Elephants?.Add(elephant);
                Console.WriteLine("Elephant with name: {0} has been added to a list of elephants", elephant.Name);

                if (_dataService != null)
                {
                    _dataService.Write("animals.json"); // Zapis danych do pliku
                    _dataService.Read("animals.json"); // Odczyt danych z pliku
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a elephant.
        /// </summary>
        private void DeleteElephant()
        {
            try
            {
                Console.Write("What is the name of the elephant you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));

                }
                Elephant? elephant = (Elephant?)(_dataService?.Animals?.Mammals?.Elephants
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (elephant is not null)
                {
                    _dataService?.Animals?.Mammals?.Elephants?.Remove(elephant);
                    Console.WriteLine("Elephant with name: {0} has been deleted from a list elephants", elephant.Name);

                }
                else
                {
                    Console.WriteLine("Elephant not found.");
                }
                if (_dataService != null)
                {
                    _dataService.Write("animals.json"); // Zapis danych do pliku
                    _dataService.Read("animals.json"); // Odczyt danych z pliku
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing elephant after choice made.
        /// </summary>
        private void EditElephantMain()
        {
            try
            {
                Console.Write("What is the name of the elephant you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Elephant? elephant = (Elephant?)(_dataService?.Animals?.Mammals?.Elephants
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (elephant is not null)
                {
                    Elephant elephantEdited = AddEditElephant();
                    elephant.Copy(elephantEdited);
                    Console.Write("Elephant after edit:");
                    elephant.Display();
                }
                else
                {
                    Console.WriteLine("Elephant not found.");
                }
                if (_dataService != null)
                {
                    _dataService.Write("animals.json"); // Zapis danych do pliku
                    _dataService.Read("animals.json"); // Odczyt danych z pliku
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific elephant.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Elephant AddEditElephant()
        {
            Console.Write("What name of the elephant? ");
            string? name = Console.ReadLine();
            Console.Write("What is the elephant's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the elephant's height (cm)? ");
            string? heightAsString = Console.ReadLine();
            Console.Write("What is the elephant's weight (cm)? ");
            string? weightAsString = Console.ReadLine();
            Console.Write("What is the elephant's tusk length (cm)? ");
            string? tuskLengthAsString = Console.ReadLine();
            Console.Write("What is the elephant's long lifespan? ");
            string? longLifespanAsString = Console.ReadLine();
            Console.Write("What is the social behavior of an elephant? ");
            string? socialBehavior = Console.ReadLine();





            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (heightAsString is null)
            {
                throw new ArgumentNullException(nameof(heightAsString));
            }
            if (weightAsString is null)
            {
                throw new ArgumentNullException(nameof(weightAsString));
            }
            if (tuskLengthAsString is null)
            {
                throw new ArgumentNullException(nameof(tuskLengthAsString));
            }
            if (longLifespanAsString is null)
            {
                throw new ArgumentNullException(nameof(longLifespanAsString));
            }
            if (socialBehavior is null)
            {
                throw new ArgumentNullException(nameof(socialBehavior));
            }

            int age = Int32.Parse(ageAsString);
            float height = Single.Parse(heightAsString);
            float weight = Single.Parse(weightAsString);
            float tuskLength = Single.Parse(tuskLengthAsString);
            int longLifespan = Int32.Parse(longLifespanAsString);





            Elephant elephant = new Elephant(name, age, height, weight, tuskLength, longLifespan, socialBehavior);

            return elephant;
        }
        /// <summary>
        /// <param name="colorName"></param>
        /// implementacja mechanizmu konwersji ciągów znaków w ConsoleColor
        /// </summary>

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
        #endregion Private Methods

    }

}
