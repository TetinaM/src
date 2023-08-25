using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface ITiger : IMammal
    {
        #region Interface Members
        /// <summary>
        /// Interface depicting a tiger.
        /// </summary>
        public string ApexPredator { get; set; }
        public string Size { get; set; }
        public string Fur { get; set; }
        public string Legs { get; set; }
        public string Behavior { get; set; }

        #endregion // Interface Members



    }
}
