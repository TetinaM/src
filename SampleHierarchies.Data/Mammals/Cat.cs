using SampleHierarchies.Interfaces.Data.Mammals;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Very basic cat class.
    /// </summary>
    public class Cat : MammalBase, ICat
    {
        #region Public Methods
     
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am a {Breed} cat and i am {Color}");
        }
        #endregion // Public Methods

        #region Ctors And Properties
        public string Breed { get; set; }
        public string Color { get; set; }

        public Cat(string name, int age, string breed, string color) : base(name, age, MammalSpecies.Cat)
        {
            Breed = breed;
            Color = color;

        }
        #endregion // Ctors And Properties
    }

}
