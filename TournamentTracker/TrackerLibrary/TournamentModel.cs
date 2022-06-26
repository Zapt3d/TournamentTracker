using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class TournamentModel
    {
        /// <summary>
        /// Name of the tournament
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// Entryfee to the tournament
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// List of teams that have entered to the tournament
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        /// <summary>
        /// List of prizes in the tournament
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// List of rounds that contain list of matchups between teams
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    }
}
