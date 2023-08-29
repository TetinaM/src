using SampleHierarchies.Interfaces.Data.Mammals;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{/// <summary>
/// Very basic lion class.
/// </summary>
    public class Lion : MammalBase, ILion
    {
        #region Public Methods
        public override void Display()
        {

            Console.WriteLine($"My name is: {Name}, my age is: {Age}, i am {ApexPredator} and i am {PackHunter}. My mane is {Mane} " +
                $"and my type of communication is {Communication}. I {TerritoryDefense}");
        }
        #endregion // Public Methods

        #region Ctors And Properties
        /// <inheritdoc/>
        public string ApexPredator { get; set; }
        public string PackHunter { get; set; }
        public string Mane { get; set; }
        public string Communication { get; set; }
        public string TerritoryDefense { get; set; }
        /// <summary>
        /// Ctor.
        /// </summary>
        public Lion(string name, int age, string apexPredator, string packHunter, string mane, string communication, string territoryDefence) : base(name, age, MammalSpecies.Lion)
        {
            ApexPredator = apexPredator;
            PackHunter = packHunter;
            Mane = mane;
            Communication = communication;
            TerritoryDefense = territoryDefence;

        }
        #endregion // Ctors And Properties

    }
}
