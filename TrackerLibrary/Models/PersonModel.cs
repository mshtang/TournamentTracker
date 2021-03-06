﻿using System;
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
        public string FirstName { get; set; }

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

        public int Id { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public PersonModel() { }
        public PersonModel(string firstName, string lastName, string emailAddress, string cellphone)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            CellphoneNumber = cellphone;
        }
    }
}
