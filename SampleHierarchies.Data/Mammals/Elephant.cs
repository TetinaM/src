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
/// Very basic elephant class.
/// </summary>
    public class Elephant : MammalBase, IElephant
    {
        #region Public Methods
        public override void Display()
        {

            Console.WriteLine($"My name is: {Name}, my age is: {Age}.  My height is {Height} cm and my weight is {Weight} cm. My tusk length is {TuskLength} cm " +
                $"and my long lifespan is {LongLifespan} years. My social behavior is {SocialBehavior}");
        }
        #endregion // Public Methods

        #region Ctors And Properties
        /// <inheritdoc/>
        public float Height { get; set; }
        public float Weight { get; set; }
        public float TuskLength { get; set; }
        public int LongLifespan { get; set; }
        public string SocialBehavior { get; set; }
        /// <summary>
        /// Ctor.
        /// </summary>
        public Elephant(string name, int age, float height, float weight, float tuskLength, int longLifespan, string socialBehavior)
    : base(name, age, MammalSpecies.Elephant)
        {
            Height = height;
            Age = age;
            Weight = weight;
            TuskLength = tuskLength;
            LongLifespan = longLifespan;
            SocialBehavior = socialBehavior;
        }
        #endregion // Ctors And Properties

    }
}
