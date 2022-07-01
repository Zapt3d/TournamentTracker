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

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);

                foreach(IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
                ResetForm();
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again");
            }
        }

        /// <summary>
        /// Validates all field inputs by user
        /// </summary>
        /// <returns><c>true</c> if all form fields are valid; <c>false</c> if one or more form field(s) are invalid</returns>
        private bool ValidateForm()
        {
            bool validForm = true;
            
            // Placenumber needs to be a valid int
            if (!int.TryParse(placeNumberValue.Text, out int placeNumber))
            {
                validForm = false;
            }

            // Placenumber needs to be >= 1
            if (placeNumber < 1)
            {
                validForm = false;
            }

            // Placename cant be empty
            if (placeNameValue.Text.Length == 0)
            {
                validForm = false;
            }
            
            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out decimal prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out double prizePercentage);

            // Either prize amount or prize percentage needs to be valid
            if (!prizeAmountValid || !prizePercentageValid)
            {
                validForm = false;
            }

            // prize amount and prize percentage need to be equal or greater than 0
            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                validForm = false;
            }

            // prize percentage cant be above 100 or below 0
            if (prizePercentage > 100 || prizePercentage < 0)
            {
                validForm = false;
            }

            return validForm;
        }

        private void ResetForm()
        {
            placeNameValue.Text = "";
            placeNumberValue.Text = "";
            prizeAmountValue.Text = "0";
            prizePercentageValue.Text = "0";
        }
    }
}
