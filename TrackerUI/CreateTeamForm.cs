using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableMembers = new List<PersonModel>();
        private List<PersonModel> selectedMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableMembers.Add(new PersonModel("Jone", "Doe", "xx", "xx"));
            availableMembers.Add(new PersonModel("Jane", "Doa", "xx", "xx"));
            selectedMembers.Add(new PersonModel("Sam", "Smith", "xx", "xx"));
            selectedMembers.Add(new PersonModel("Same", "Strom", "xx", "xx"));
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = availableMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = selectedMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidatePersonForm())
            {
                PersonModel personModel = new PersonModel(
                    firstNameValue.Text, lastNameValue.Text, 
                    emailValue.Text, cellphoneValue.Text);
                GlobalConfig.Connection.CreatePerson(personModel);
                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("All fields are required.");
            }
        }

        private bool ValidatePersonForm()
        {
            string firstName = firstNameValue.Text;
            string lastName = lastNameValue.Text;
            string email = emailValue.Text;
            string cellphone = cellphoneValue.Text;

            if (firstName == "" || lastName == "" || email == "" || cellphone== "")
                return false;
            else return true;
        }
    }
}
