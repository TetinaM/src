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
/// Very basic tiger class.
/// </summary>
    public class Tiger : MammalBase, ITiger
    {
        #region Public Methods
        public override void Display()
        {

            Console.WriteLine($"My name is: {Name}, my age is: {Age}, i am {ApexPredator} and i am {Size}. I have a {Fur} fur and {Legs} legs. " +
                $"My behavior is {Behavior}");
        }
        #endregion // Public Methods

        #region Ctors And Properties
        /// <inheritdoc/>
        public string ApexPredator { get; set; }
        public string Size { get; set; }
        public string Fur { get; set; }
        public string Legs { get; set; }
        public string Behavior { get; set; }
        /// <summary>
        /// Ctor.
        /// </summary>
        public Tiger(string name, int age, string apexPredator, string size, string fur, string legs, string behavior) : base(name, age, MammalSpecies.Tiger)
        {
            ApexPredator = apexPredator;
            Size = size;
            Fur = fur;
            Legs = legs;
            Behavior = behavior;

        }

        #endregion // Ctors And Properties
    }
}