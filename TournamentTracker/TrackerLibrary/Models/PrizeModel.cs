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
        /// Unique identifier for the prize in database
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Place number in the tournament that the prize is for
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Place name in the tournament
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Prize amount for the place
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Prize percentage for the place
        /// </summary>
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            _ = int.TryParse(placeNumber, out int placeNumberValue);
            _ = decimal.TryParse(prizeAmount, out decimal prizeAmountValue);
            _ = double.TryParse(prizePercentage, out double prizePercentageValue);

            PlaceName = placeName;
            PlaceNumber = placeNumberValue;
            PrizeAmount = prizeAmountValue;
            PrizePercentage = prizePercentageValue;

        }
    }
}
