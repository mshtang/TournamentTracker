using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represent a team in a matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        
        /// <summary>
        /// The score a team earns in a matchup
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// The winner of a matchup
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
