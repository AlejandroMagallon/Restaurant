namespace Finals
{
    partial class frmCheckout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxPayment = new System.Windows.Forms.GroupBox();
            this.btnEditTip = new System.Windows.Forms.Button();
            this.dtpCardDate = new System.Windows.Forms.DateTimePicker();
            this.lblCardPin = new System.Windows.Forms.Label();
            this.txtCardPin = new System.Windows.Forms.TextBox();
            this.lblCardDate = new System.Windows.Forms.Label();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.lblCheckout = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.radDebit = new System.Windows.Forms.RadioButton();
            this.radCredit = new System.Windows.Forms.RadioButton();
            this.radCash = new System.Windows.Forms.RadioButton();
            this.lblPayment = new System.Windows.Forms.Label();
            this.gbxTip = new System.Windows.Forms.GroupBox();
            this.radNoTip = new System.Windows.Forms.RadioButton();
            this.btnCustom = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.radCustom = new System.Windows.Forms.RadioButton();
            this.rad20 = new System.Windows.Forms.RadioButton();
            this.rad15 = new System.Windows.Forms.RadioButton();
            this.rad10 = new System.Windows.Forms.RadioButton();
            this.txtTip = new System.Windows.Forms.TextBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.txtITotal = new System.Windows.Forms.TextBox();
            this.txtITip = new System.Windows.Forms.TextBox();
            this.gbxPayment.SuspendLayout();
            this.gbxTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPayment
            // 
            this.gbxPayment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxPayment.Controls.Add(this.btnEditTip);
            this.gbxPayment.Controls.Add(this.dtpCardDate);
            this.gbxPayment.Controls.Add(this.lblCardPin);
            this.gbxPayment.Controls.Add(this.txtCardPin);
            this.gbxPayment.Controls.Add(this.lblCardDate);
            this.gbxPayment.Controls.Add(this.lblCardNum);
            this.gbxPayment.Controls.Add(this.txtCardNum);
            this.gbxPayment.Controls.Add(this.lblCheckout);
            this.gbxPayment.Controls.Add(this.btnCheckout);
            this.gbxPayment.Controls.Add(this.radDebit);
            this.gbxPayment.Controls.Add(this.radCredit);
            this.gbxPayment.Controls.Add(this.radCash);
            this.gbxPayment.Controls.Add(this.lblPayment);
            this.gbxPayment.Location = new System.Drawing.Point(403, 52);
            this.gbxPayment.Name = "gbxPayment";
            this.gbxPayment.Size = new System.Drawing.Size(297, 341);
            this.gbxPayment.TabIndex = 8;
            this.gbxPayment.TabStop = false;
            this.gbxPayment.Text = "Payment Method";
            this.gbxPayment.Visible = false;
            // 
            // btnEditTip
            // 
            this.btnEditTip.BackColor = System.Drawing.Color.Maroon;
            this.btnEditTip.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditTip.Location = new System.Drawing.Point(63, 306);
            this.btnEditTip.Name = "btnEditTip";
            this.btnEditTip.Size = new System.Drawing.Size(77, 29);
            this.btnEditTip.TabIndex = 9;
            this.btnEditTip.Text = "Edit Tip";
            this.btnEditTip.UseVisualStyleBackColor = false;
            this.btnEditTip.Click += new System.EventHandler(this.btnEditTip_Click);
            // 
            // dtpCardDate
            // 
            this.dtpCardDate.CustomFormat = "MM/yy";
            this.dtpCardDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCardDate.Location = new System.Drawing.Point(122, 240);
            this.dtpCardDate.Name = "dtpCardDate";
            this.dtpCardDate.ShowUpDown = true;
            this.dtpCardDate.Size = new System.Drawing.Size(65, 20);
            this.dtpCardDate.TabIndex = 16;
            this.dtpCardDate.Value = new System.DateTime(2024, 5, 13, 16, 9, 0, 0);
            this.dtpCardDate.Visible = false;
            this.dtpCardDate.ValueChanged += new System.EventHandler(this.dtpCardDate_ValueChanged);
            // 
            // lblCardPin
            // 
            this.lblCardPin.AutoSize = true;
            this.lblCardPin.Location = new System.Drawing.Point(23, 269);
            this.lblCardPin.Name = "lblCardPin";
            this.lblCardPin.Size = new System.Drawing.Size(93, 13);
            this.lblCardPin.TabIndex = 14;
            this.lblCardPin.Text = "Card Pin Number: ";
            this.lblCardPin.Visible = false;
            // 
            // txtCardPin
            // 
            this.txtCardPin.Location = new System.Drawing.Point(122, 266);
            this.txtCardPin.MaxLength = 6;
            this.txtCardPin.Name = "txtCardPin";
            this.txtCardPin.Size = new System.Drawing.Size(56, 20);
            this.txtCardPin.TabIndex = 13;
            this.txtCardPin.Visible = false;
            // 
            // lblCardDate
            // 
            this.lblCardDate.AutoSize = true;
            this.lblCardDate.Location = new System.Drawing.Point(6, 240);
            this.lblCardDate.Name = "lblCardDate";
            this.lblCardDate.Size = new System.Drawing.Size(110, 13);
            this.lblCardDate.TabIndex = 12;
            this.lblCardDate.Text = "Card Expiration Date: ";
            this.lblCardDate.Visible = false;
            // 
            // lblCardNum
            // 
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Location = new System.Drawing.Point(39, 214);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(75, 13);
            this.lblCardNum.TabIndex = 10;
            this.lblCardNum.Text = "Card Number: ";
            this.lblCardNum.Visible = false;
            // 
            // txtCardNum
            // 
            this.txtCardNum.Location = new System.Drawing.Point(122, 214);
            this.txtCardNum.MaxLength = 16;
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(110, 20);
            this.txtCardNum.TabIndex = 9;
            this.txtCardNum.Visible = false;
            // 
            // lblCheckout
            // 
            this.lblCheckout.AutoSize = true;
            this.lblCheckout.Location = new System.Drawing.Point(39, 158);
            this.lblCheckout.Name = "lblCheckout";
            this.lblCheckout.Size = new System.Drawing.Size(0, 13);
            this.lblCheckout.TabIndex = 8;
            this.lblCheckout.Visible = false;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.Maroon;
            this.btnCheckout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCheckout.Location = new System.Drawing.Point(153, 306);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(79, 29);
            this.btnCheckout.TabIndex = 7;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // radDebit
            // 
            this.radDebit.AutoSize = true;
            this.radDebit.Location = new System.Drawing.Point(42, 132);
            this.radDebit.Name = "radDebit";
            this.radDebit.Size = new System.Drawing.Size(75, 17);
            this.radDebit.TabIndex = 3;
            this.radDebit.Text = "Debit Card";
            this.radDebit.UseVisualStyleBackColor = true;
            this.radDebit.CheckedChanged += new System.EventHandler(this.radDebit_CheckedChanged);
            // 
            // radCredit
            // 
            this.radCredit.AutoSize = true;
            this.radCredit.Location = new System.Drawing.Point(42, 109);
            this.radCredit.Name = "radCredit";
            this.radCredit.Size = new System.Drawing.Size(77, 17);
            this.radCredit.TabIndex = 2;
            this.radCredit.Text = "Credit Card";
            this.radCredit.UseVisualStyleBackColor = true;
            this.radCredit.CheckedChanged += new System.EventHandler(this.radCredit_CheckedChanged);
            // 
            // radCash
            // 
            this.radCash.AutoSize = true;
            this.radCash.Location = new System.Drawing.Point(42, 86);
            this.radCash.Name = "radCash";
            this.radCash.Size = new System.Drawing.Size(49, 17);
            this.radCash.TabIndex = 1;
            this.radCash.Text = "Cash";
            this.radCash.UseVisualStyleBackColor = true;
            this.radCash.CheckedChanged += new System.EventHandler(this.radCash_CheckedChanged);
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPayment.Location = new System.Drawing.Point(60, 44);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(160, 13);
            this.lblPayment.TabIndex = 0;
            this.lblPayment.Text = "Please select a payment method\r\n";
            // 
            // gbxTip
            // 
            this.gbxTip.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxTip.Controls.Add(this.radNoTip);
            this.gbxTip.Controls.Add(this.btnCustom);
            this.gbxTip.Controls.Add(this.btnNext);
            this.gbxTip.Controls.Add(this.radCustom);
            this.gbxTip.Controls.Add(this.rad20);
            this.gbxTip.Controls.Add(this.rad15);
            this.gbxTip.Controls.Add(this.rad10);
            this.gbxTip.Controls.Add(this.txtTip);
            this.gbxTip.Controls.Add(this.lblTip);
            this.gbxTip.Location = new System.Drawing.Point(101, 52);
            this.gbxTip.Name = "gbxTip";
            this.gbxTip.Size = new System.Drawing.Size(247, 346);
            this.gbxTip.TabIndex = 7;
            this.gbxTip.TabStop = false;
            this.gbxTip.Text = "Tip";
            // 
            // radNoTip
            // 
            this.radNoTip.AutoSize = true;
            this.radNoTip.Checked = true;
            this.radNoTip.Location = new System.Drawing.Point(50, 229);
            this.radNoTip.Name = "radNoTip";
            this.radNoTip.Size = new System.Drawing.Size(57, 17);
            this.radNoTip.TabIndex = 8;
            this.radNoTip.TabStop = true;
            this.radNoTip.Text = "No Tip";
            this.radNoTip.UseVisualStyleBackColor = true;
            this.radNoTip.CheckedChanged += new System.EventHandler(this.radNoTip_CheckedChanged);
            // 
            // btnCustom
            // 
            this.btnCustom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCustom.Enabled = false;
            this.btnCustom.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnCustom.FlatAppearance.BorderSize = 2;
            this.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom.ForeColor = System.Drawing.Color.Maroon;
            this.btnCustom.Location = new System.Drawing.Point(116, 182);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(87, 38);
            this.btnCustom.TabIndex = 7;
            this.btnCustom.Text = "Save Custom Tip";
            this.btnCustom.UseVisualStyleBackColor = false;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Maroon;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNext.Location = new System.Drawing.Point(50, 278);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(136, 29);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // radCustom
            // 
            this.radCustom.AutoSize = true;
            this.radCustom.Location = new System.Drawing.Point(50, 182);
            this.radCustom.Name = "radCustom";
            this.radCustom.Size = new System.Drawing.Size(60, 17);
            this.radCustom.TabIndex = 5;
            this.radCustom.Text = "Custom";
            this.radCustom.UseVisualStyleBackColor = true;
            this.radCustom.CheckedChanged += new System.EventHandler(this.radCustom_CheckedChanged);
            // 
            // rad20
            // 
            this.rad20.AutoSize = true;
            this.rad20.Location = new System.Drawing.Point(50, 159);
            this.rad20.Name = "rad20";
            this.rad20.Size = new System.Drawing.Size(45, 17);
            this.rad20.TabIndex = 4;
            this.rad20.Text = "20%";
            this.rad20.UseVisualStyleBackColor = true;
            this.rad20.CheckedChanged += new System.EventHandler(this.rad20_CheckedChanged);
            // 
            // rad15
            // 
            this.rad15.AutoSize = true;
            this.rad15.Location = new System.Drawing.Point(50, 136);
            this.rad15.Name = "rad15";
            this.rad15.Size = new System.Drawing.Size(45, 17);
            this.rad15.TabIndex = 3;
            this.rad15.Text = "15%";
            this.rad15.UseVisualStyleBackColor = true;
            this.rad15.CheckedChanged += new System.EventHandler(this.rad15_CheckedChanged);
            // 
            // rad10
            // 
            this.rad10.AutoSize = true;
            this.rad10.Location = new System.Drawing.Point(50, 113);
            this.rad10.Name = "rad10";
            this.rad10.Size = new System.Drawing.Size(45, 17);
            this.rad10.TabIndex = 2;
            this.rad10.Text = "10%";
            this.rad10.UseVisualStyleBackColor = true;
            this.rad10.CheckedChanged += new System.EventHandler(this.rad10_CheckedChanged);
            // 
            // txtTip
            // 
            this.txtTip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTip.Location = new System.Drawing.Point(50, 75);
            this.txtTip.Name = "txtTip";
            this.txtTip.ReadOnly = true;
            this.txtTip.Size = new System.Drawing.Size(136, 20);
            this.txtTip.TabIndex = 1;
            this.txtTip.Text = "$0.00";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTip.Location = new System.Drawing.Point(47, 49);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(139, 13);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "Would you like to add a tip?";
            // 
            // txtITotal
            // 
            this.txtITotal.Location = new System.Drawing.Point(-54, -2);
            this.txtITotal.Name = "txtITotal";
            this.txtITotal.Size = new System.Drawing.Size(82, 20);
            this.txtITotal.TabIndex = 9;
            // 
            // txtITip
            // 
            this.txtITip.Location = new System.Drawing.Point(769, -2);
            this.txtITip.Name = "txtITip";
            this.txtITip.Size = new System.Drawing.Size(82, 20);
            this.txtITip.TabIndex = 10;
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtITip);
            this.Controls.Add(this.txtITotal);
            this.Controls.Add(this.gbxPayment);
            this.Controls.Add(this.gbxTip);
            this.Name = "frmCheckout";
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            this.gbxPayment.ResumeLayout(false);
            this.gbxPayment.PerformLayout();
            this.gbxTip.ResumeLayout(false);
            this.gbxTip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPayment;
        private System.Windows.Forms.DateTimePicker dtpCardDate;
        private System.Windows.Forms.Label lblCardPin;
        private System.Windows.Forms.TextBox txtCardPin;
        private System.Windows.Forms.Label lblCardDate;
        private System.Windows.Forms.Label lblCardNum;
        private System.Windows.Forms.TextBox txtCardNum;
        private System.Windows.Forms.Label lblCheckout;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.RadioButton radDebit;
        private System.Windows.Forms.RadioButton radCredit;
        private System.Windows.Forms.RadioButton radCash;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.GroupBox gbxTip;
        private System.Windows.Forms.RadioButton radNoTip;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.RadioButton radCustom;
        private System.Windows.Forms.RadioButton rad20;
        private System.Windows.Forms.RadioButton rad15;
        private System.Windows.Forms.RadioButton rad10;
        private System.Windows.Forms.TextBox txtTip;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnEditTip;
        public System.Windows.Forms.TextBox txtITotal;
        public System.Windows.Forms.TextBox txtITip;
    }
}