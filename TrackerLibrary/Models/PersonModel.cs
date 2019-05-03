using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// First name of a person
        /// </summary>
        public string FristName { get; set; }

        /// <summary>
        /// Last name of a person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of a person
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Cellphone number of a person
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
