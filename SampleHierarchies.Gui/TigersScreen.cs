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
    public sealed class TigersScreen : Screen
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
        /// Ctor.
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="settings"></param>
        public TigersScreen(IDataService dataService, ISettings settings)
        {
            _settings = settings;
            _dataService = dataService;

        }
        #endregion Properties And Ctor
        #region Public Methods
        public override void Show()
        {
            /// <summury>
            /// Konwersja koloru z ciągu znaków na ConsoleColor
            /// </summury>

            Console.ForegroundColor = ConvertColorNameToConsoleColor(_settings.TigersScreenColor);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all tigers");
                Console.WriteLine("2. Create a new tiger");
                Console.WriteLine("3. Delete existing tiger");
                Console.WriteLine("4. Modify existing tiger");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    TigersScreenChoices choice = (TigersScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case TigersScreenChoices.List:
                            ListTigers();
                            break;

                        case TigersScreenChoices.Create:
                            AddTiger();
                            break;

                        case TigersScreenChoices.Delete:
                            DeleteTiger();
                            break;

                        case TigersScreenChoices.Modify:
                            EditTigerMain();
                            break;

                        case TigersScreenChoices.Exit:
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
        #endregion Public Methods

        #region Private Methods
        private void ListTigers()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Tigers is not null &&
                _dataService.Animals.Mammals.Tigers.Count > 0)
            {
                Console.WriteLine("Here's a list of tigers:");
                int i = 1;
                foreach (Tiger tiger in _dataService.Animals.Mammals.Tigers)
                {
                    Console.Write($"Tiger number {i}, ");
                    tiger.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of tigers is empty.");
            }
        }

        /// <summary>
        /// Add a tiger.
        /// </summary>
        private void AddTiger()
        {
            try
            {
                Tiger tiger = AddEditTiger();
                _dataService?.Animals?.Mammals?.Tigers?.Add(tiger);
                Console.WriteLine("Tiger with name: {0} has been added to a list of tigers", tiger.Name);

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
        /// Deletes a tiger.
        /// </summary>
        private void DeleteTiger()
        {
            try
            {
                Console.Write("What is the name of the tiger you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));

                }
                Tiger? tiger = (Tiger?)(_dataService?.Animals?.Mammals?.Tigers
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (tiger is not null)
                {
                    _dataService?.Animals?.Mammals?.Tigers?.Remove(tiger);
                    Console.WriteLine("Tiger with name: {0} has been deleted from a list of tigers", tiger.Name);

                }
                else
                {
                    Console.WriteLine("Tiger not found.");
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
        /// Edits an existing tiger after choice made.
        /// </summary>
        private void EditTigerMain()
        {
            try
            {
                Console.Write("What is the name of the tiger you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Tiger? tiger = (Tiger?)(_dataService?.Animals?.Mammals?.Tigers
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (tiger is not null)
                {
                    Tiger tigerEdited = AddEditTiger();
                    tiger.Copy(tigerEdited);
                    Console.Write("Tiger after edit:");
                    tiger.Display();
                }
                else
                {
                    Console.WriteLine("Tiger not found.");
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
        /// Adds/edit specific tiger.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Tiger AddEditTiger()
        {
            Console.Write("What name of the tiger? ");
            string? name = Console.ReadLine();
            Console.Write("What is the tiger's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("A tiger is a apex predater? Yes or no?");
            string? apexPredatorString = Console.ReadLine();
            Console.Write("A lion is big ot small?");
            string? size = Console.ReadLine();
            Console.Write("What kind of fur does he have?");
            string? fur = Console.ReadLine();
            Console.Write("What are his legs? ");
            string? legs = Console.ReadLine();
            Console.Write("What is his behavior?");
            string? behavior = Console.ReadLine();


            string apexPredatorText = apexPredatorString == "Yes" ? " apex predator" : " not apex predator";
            

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (apexPredatorString is null)
            {
                throw new ArgumentNullException(nameof(apexPredatorString));
            }
            if (size is null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            if (fur is null)
            {
                throw new ArgumentNullException(nameof(fur));
            }
            if (legs is null)
            {
                throw new ArgumentNullException(nameof(legs));
            }
            if (behavior is null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            int age = Int32.Parse(ageAsString);
            string apexPredator = apexPredatorText;
            



            Tiger tiger = new Tiger(name, age, apexPredator, size, fur, legs, behavior);

            return tiger;
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