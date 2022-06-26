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
    }
}
