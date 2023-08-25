using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    
    public interface ICat : IMammal
    {
        #region Interface Members
        /// <summary>
        /// Breed of cat.
        /// </summary>
        string Breed { get; set; }
        /// <summary>
        /// Color of cat.
        /// </summary>
        string Color { get; set; }
        #endregion // Interface Members
    }
}
