using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    /*
    Name: Alex Magallon, Maurel Fabian, Dimas Chica,
    Group Name: the coders
    Date: 5/23/24
    Program: Payment screen for user to pay for food
 */

    public partial class frmCheckout : Form
    {
        //we will get the amounts from the users food selection
        //variables      
        public double getSum { get; set; } //pased from frmMain
        public double getTax { get; set; }
        private double tax = 0;
        private double sum = 0; //GET Sum FROM THE FIRST FORM AND SEND TO THIS VARIABLE
        const double RAD10 = .10;
        const double RAD15 = .15; //Constants for percentages for tip
        const double RAD20 = .20;
        private double amount = 0; // this is the tip amount for sum * tip
        private double total = 0;
        
        
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void rad10_CheckedChanged(object sender, EventArgs e)
        {

            btnNext.Enabled = true; //enables the next button when user selects tip

            btnCustom.Enabled = false; //disables the save tip btn if custom tip isnt selected
            txtTip.ReadOnly = true;

            txtTip.Clear();

            amount = sum * RAD10;             //get the amount and multiply by the tip they selected

            txtTip.Text = amount.ToString("c"); //sends tip amount to text box
        }

        private void rad15_CheckedChanged(object sender, EventArgs e)
        {

            btnNext.Enabled = true; //enables the next button when user selects tip

            btnCustom.Enabled = false; //disables the save tip btn if custom tip isnt selected
            txtTip.ReadOnly = true;

            txtTip.Clear();

            amount = sum * RAD15;             //get the amount and multiply by the tip they selected

            txtTip.Text = amount.ToString("c"); //sends tip amount to text box
        }

        private void rad20_CheckedChanged(object sender, EventArgs e)
        {
 
            btnNext.Enabled = true; //enables the next button when user selects tip

            btnCustom.Enabled = false; //disables the save tip btn if custom tip isnt selected
            txtTip.ReadOnly = true;

            txtTip.Clear();

            amount = sum * RAD20;             //get the amount and multiply by the tip they selected

            txtTip.Text = amount.ToString("c"); //sends tip amount to text box
        }

        private void radCustom_CheckedChanged(object sender, EventArgs e)
        {
            //makes button clickable and text editable so they can enter custom amount and save it
            btnNext.Enabled = false; //makes it so they cant select next until they click to save custm amount
            btnCustom.Enabled = true;
            txtTip.ReadOnly = false;
            txtTip.Clear();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            //checks to see if what they entered is a numerical number
            if (!double.TryParse(txtTip.Text, out amount))
            {
                MessageBox.Show("Please enter a numerical number."); //if its not a double they will get error

                //Reset the Textbox 
                txtTip.Clear();
            }
            else
            {
                txtTip.Text = amount.ToString("c"); //saves user input to dollar amount
                btnNext.Enabled = true;
            }
        }

        private void radNoTip_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true; //enables the next button when user selects tip
            btnCustom.Enabled = false; //disables the save tip btn if custom tip isnt selected
            txtTip.ReadOnly = true;
            txtTip.Clear();

            amount = 0;             //get the amount and multiply by the tip they selected

            txtTip.Text = amount.ToString("c"); //saves user input to dollar amount
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //validate that txtTip is not empty and contains a valid number
            if (string.IsNullOrWhiteSpace(txtTip.Text))
            {
                MessageBox.Show("Please enter a tip amount.");
                return;
            }
            
            gbxPayment.Visible = true; //makes payment method visibile after adding tip (Can remove if you want so its alaways visible)
            gbxTip.Enabled = false; //disables the tip box so they cant change it unless they click edit
            total = sum + tax + amount; 
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            //variables
            string cardPin = txtCardPin.Text.Trim();
            string cardNumber = txtCardNum.Text;
            int selectedOption = 3;

            // if else to change selectedOption to what user clicks for payment method
            if (radCash.Checked)
            {
                selectedOption = 0;
            }
            else if (radCredit.Checked)
            {
                selectedOption = 1;
            }
            else if (radDebit.Checked)
            {
                selectedOption = 2;
            }

            //Used a switch case based on what user clicked using selectedOption
            switch (selectedOption)
            {
                case 0:

                    MessageBox.Show("Your waiter will be with you shortly"); //cash

                    break;

                case 1:

                    if (!cardNumber.All(char.IsDigit)) //checks digits if numerical
                    {
                        txtCardNum.Clear();
                        MessageBox.Show("Please enter a numerical card number.");
                        return;
                    }
                    else if (cardNumber.Length != 16)
                    {
                        txtCardNum.Clear();
                        MessageBox.Show("Please enter a 16 digit card number"); //checks digits if length isnt enough

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Payment successfull"); //if above all good

                        break;
                    }



                case 2:

                    if (!cardNumber.All(char.IsDigit)) //Check digits
                    {
                        txtCardNum.Clear();
                        MessageBox.Show("Please enter a numerical card number.");
                        return;
                    }
                    else if (cardNumber.Length != 16) // check length
                    {
                        txtCardNum.Clear();
                        MessageBox.Show("Please enter a 16 digit card number");

                        return;
                    }
                    else if (!cardPin.All(char.IsDigit)) //Check digits
                    {
                        txtCardPin.Clear();

                        MessageBox.Show("Please enter numerical numbers for card pin");

                        return;
                    }
                    else if (cardPin.Length < 4) //check length
                    {
                        txtCardPin.Clear();

                        MessageBox.Show("Please enter a 4 through 6 digit pin"); //made pin max length 6

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Payment successfull"); //above all good

                        break;
                    }

            }
            txtITotal.Text = total.ToString();
            txtITip.Text = amount.ToString();
            ((frmMain)this.Owner).orderTip = double.Parse(txtITip.Text);
            ((frmMain)this.Owner).subTotal = double.Parse(txtITotal.Text);
            this.Close();

        }

        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            dtpCardDate.Value = DateTime.Now; //resets selected date, pin and card num for other options incase the user changes mind 
            txtCardPin.Clear();
            txtCardNum.Clear();
            txtCardPin.Visible = false; //hides everything so they can pay with cash
            lblCardPin.Visible = false;
            dtpCardDate.Visible = false;
            lblCardDate.Visible = false;
            lblCardNum.Visible = false;
            txtCardNum.Visible = false;
            lblCheckout.Visible = true;          
            lblCheckout.Text = "Your total is " + (sum + tax + amount).ToString("c") + " please wait \n" +
                    "for your waiter to collect your \n" +
                    "money at the table.";
            
        }

        private void radCredit_CheckedChanged(object sender, EventArgs e)
        {
            dtpCardDate.Value = DateTime.Now; //resets selected date, pin and card num for other options incase the user changes mind 
            txtCardPin.Clear();
            txtCardNum.Clear();
            txtCardPin.Visible = false; //hides everything except card and expiration date
            lblCardPin.Visible = false; //Makes it so user can input credit info
            dtpCardDate.Visible = true;
            lblCardDate.Visible = true;
            lblCardNum.Visible = true;
            txtCardNum.Visible = true;
            lblCheckout.Visible = true;
            lblCheckout.Text = "Your total is " + (amount + tax + sum).ToString("c") + " \nPlease enter your credit card \n" +
                "information"; 
        }

        private void radDebit_CheckedChanged(object sender, EventArgs e)
        {
            dtpCardDate.Value = DateTime.Now; //resets selected date, pin and card num for other options incase the user changes mind 
            txtCardPin.Clear();
            txtCardNum.Clear();
            txtCardPin.Visible = true; //shows everything so user can enter card num, pin, and date 
            lblCardPin.Visible = true;
            dtpCardDate.Visible = true;
            lblCardDate.Visible = true;
            lblCardNum.Visible = true;
            txtCardNum.Visible = true;
            lblCheckout.Visible = true;
            lblCheckout.Text = "Your total is " + (amount + tax + sum).ToString("c") +  " \nPlease enter your debit card \n" +
                "information"; 
        }

        private void dtpCardDate_ValueChanged(object sender, EventArgs e)
        {
            //Prevents the user from selecting a previous date from the current date
            if (dtpCardDate.Value < DateTime.Today)
            {
                dtpCardDate.Value = DateTime.Today;
                MessageBox.Show("Expiration date must be in the future"); //error when user tries to select past date
            }
        }

        private void btnEditTip_Click(object sender, EventArgs e)
        {
            //makes it so when user selects to edit tip it will make everything for the payment option unclickable
            amount = 0; //resets amount
            txtTip.Clear();
            radCash.Checked = false;
            radCredit.Checked = false;
            radDebit.Checked = false;
            txtCardPin.Visible = false;
            lblCardPin.Visible = false;
            dtpCardDate.Visible = false;
            lblCardDate.Visible = false;
            lblCardNum.Visible = false;
            txtCardNum.Visible = false;
            lblCheckout.Visible = false;
            radCustom.Checked = true;
            gbxTip.Enabled = true;
            gbxPayment.Visible = false;

            
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            {
                //loads sum and tax from frmMain
                sum = getSum;
                tax = getTax;
            }
        }

    }


}
