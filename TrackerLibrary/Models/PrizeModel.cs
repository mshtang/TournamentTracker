using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier of an object in the table
        /// </summary>
        public int Id { get; set; }

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

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount = null, string prizePercentage = null)
        {
            int.TryParse(placeNumber, out int placeNumberValue);
            PlaceNumber = placeNumberValue;

            PlaceName = placeName;

            decimal.TryParse(prizeAmount, out decimal prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double.TryParse(prizePercentage, out double prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
