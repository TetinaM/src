using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{

    public interface IElephant: IMammal
    {
        #region Interface Members
        /// <summary>
        /// Interface depicting a lion.
        /// </summary>
        public float Height { get; set; }
        public float Weight { get; set; }
        public float TuskLength { get; set; }
        public int LongLifespan { get; set; }
        public string SocialBehavior { get; set; }
        #endregion // Interface Members
    }


}
