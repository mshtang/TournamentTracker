using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        /// <summary>
        /// Name of the tournament
        /// </summary>
        public string TournamnentName { get; set; }

        /// <summary>
        /// Fees required for entering the tournament
        /// </summary>
        public decimal EntryFees { get; set; }

        /// <summary>
        /// Teams in this tournament
        /// </summary>
        public List<TeamModel> EnteredTeam { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Prizes for this tournament
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// All matchups in the tournament
        /// List<MatchupModel> stores the matchups in a round
        /// </summary>
        public List<List<MatchupModel>> Matchups { get; set; } = new List<List<MatchupModel>>();
    }
}
