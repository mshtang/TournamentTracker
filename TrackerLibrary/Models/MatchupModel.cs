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
        /// The n-th Round in a tournament
        /// </summary>
        public int MatchupRound { get; set; }

        /// <summary>
        /// The winner in a matchup
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// The teams in a matchup
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
    }
}
