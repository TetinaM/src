using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface ILion: IMammal
    {
        #region Interface Members
        /// <summary>
        /// Interface depicting a lion.
        /// </summary>
        public string ApexPredator { get; set; }
        public string PackHunter { get; set; }
        public string Mane { get; set; }
        public string Communication { get; set; }
        public string TerritoryDefense { get; set; }

        #endregion // Interface Members



    }
}
