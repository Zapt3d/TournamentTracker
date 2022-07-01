using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Teams that were part of this match
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// Winner of the match
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// What round this match was part of
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
