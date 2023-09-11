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
    public sealed class LionsScreen : Screen
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
        public LionsScreen(IDataService dataService, ISettings settings)
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

            Console.ForegroundColor = ConvertColorNameToConsoleColor(_settings.LionsScreenColor);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all lions");
                Console.WriteLine("2. Create a new lion");
                Console.WriteLine("3. Delete existing lion");
                Console.WriteLine("4. Modify existing lion");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    LionsScreenChoices choice = (LionsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case LionsScreenChoices.List:
                            ListLions();
                            break;

                        case LionsScreenChoices.Create:
                            AddLion(); break;

                        case LionsScreenChoices.Delete:
                            DeleteLion();
                            break;

                        case LionsScreenChoices.Modify:
                            EditLionMain();
                            break;

                        case LionsScreenChoices.Exit:
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
        private void ListLions()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Lions is not null &&
                _dataService.Animals.Mammals.Lions.Count > 0)
            {
                Console.WriteLine("Here's a list of lions:");
                int i = 1;
                foreach (Lion lion in _dataService.Animals.Mammals.Lions)
                {
                    Console.Write($"Lion number {i}, ");
                    lion.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of lions is empty.");
            }
        }

        /// <summary>
        /// Add a lion.
        /// </summary>
        private void AddLion()
        {
            try
            {
                Lion lion = AddEditLion();
                _dataService?.Animals?.Mammals?.Lions?.Add(lion);
                Console.WriteLine("Lion with name: {0} has been added to a list of lions", lion.Name);

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
        /// Deletes a lion.
        /// </summary>
        private void DeleteLion()
        {
            try
            {
                Console.Write("What is the name of the lion you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                   
                }
                Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (lion is not null)
                {
                    _dataService?.Animals?.Mammals?.Lions?.Remove(lion);
                    Console.WriteLine("Lion with name: {0} has been deleted from a list of lions", lion.Name);
                    
                }
                else
                {
                    Console.WriteLine("Lion not found.");
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
        /// Edits an existing lion after choice made.
        /// </summary>
        private void EditLionMain()
        {
            try
            {
                Console.Write("What is the name of the lion you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (lion is not null)
                {
                    Lion lionEdited = AddEditLion();
                    lion.Copy(lionEdited);
                    Console.Write("Lion after edit:");
                    lion.Display();
                }
                else
                {
                    Console.WriteLine("Lion not found.");
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
        /// Adds/edit specific lion.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Lion AddEditLion()
        {
            Console.Write("What name of the lion? ");
            string? name = Console.ReadLine();
            Console.Write("What is the lion's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("A lion is a apex predater? Yes or no? ");
            string? apexPredatorString = Console.ReadLine();
            Console.Write("A lion is a pack hunter. Yes or no? ");
            string? packHunterString = Console.ReadLine();
            Console.Write("What is his mane?");
            string? mane = Console.ReadLine();
            Console.Write("What type of communication does a lion have?");
            string? communication = Console.ReadLine();
            Console.Write("Do lions defend territory? Yes or no?");
            string? territoryDefenceString = Console.ReadLine();


            string apexPredatorText = apexPredatorString == "yes" ? " apex predator" : " not apex predator";
            string packHunterText = packHunterString == "yes" ? " pack hunter" : " not pack hunter";
            string territoryDefenceText = territoryDefenceString == "yes" ? " defend territory" : " don't defend territory";

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
            if (packHunterString is null)
            {
                throw new ArgumentNullException(nameof(packHunterString));
            }
            if (mane is null)
            {
                throw new ArgumentNullException(nameof(mane));
            }
            if (communication is null)
            {
                throw new ArgumentNullException(nameof(communication));
            }
            if (territoryDefenceString is null)
            {
                throw new ArgumentNullException(nameof(territoryDefenceString));
            }

            int age = Int32.Parse(ageAsString);
            string apexPredator = apexPredatorText;
            string packHunter = packHunterText;
            string territoryDefence = territoryDefenceText;



            Lion lion = new Lion(name, age, apexPredator, packHunter, mane, communication, territoryDefence);

            return lion;
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
