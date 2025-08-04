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
    public partial class frmSplash : Form
    {

        public frmSplash()
        {
            InitializeComponent();
            lblWarning_name.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //error checking if the user writes nothing.
            if (txtName.Text.Length == 0)
                lblWarning_name.Visible = true;
            else
                this.Close();
        }
    }
}
