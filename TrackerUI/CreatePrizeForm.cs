﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel prizeModel = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);
                GlobalConfig.Connection.CreatePrize(prizeModel);
                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This box has invalid information");
            }

        }

        private bool ValidateForm()
        {
            bool output = true;
            bool placeNumberValid = int.TryParse(placeNumberValue.Text, out int placeNumber);

            if (!placeNumberValid || placeNumber<1) output = false;

            if (placeNameValue.Text.Length == 0) output = false;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out decimal prizeAmount);

            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out double prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid) output = false;
      
            if(prizeAmount <=0 && prizePercentage <= 0) output = false;

            if (prizePercentage<0 || prizePercentage > 1) output = false;

            return output;
        }
    }
}
