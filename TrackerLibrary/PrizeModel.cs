using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// n-th placement in the tournament
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Corresponding description of that placement
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// The amount of prize awarded
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// The percentage of prize awarded
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
