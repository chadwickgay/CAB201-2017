namespace Currency_Converter_GUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblCurrencyHave = new System.Windows.Forms.Label();
            this.lblCurencyHave = new System.Windows.Forms.Label();
            this.lblAmountHave = new System.Windows.Forms.Label();
            this.lblAmountWant = new System.Windows.Forms.Label();
            this.cmdEquals = new System.Windows.Forms.Button();
            this.grpConversion = new System.Windows.Forms.GroupBox();
            this.optConversionNo = new System.Windows.Forms.RadioButton();
            this.optConversionYes = new System.Windows.Forms.RadioButton();
            this.txtAmountHave = new System.Windows.Forms.TextBox();
            this.txtAmountWant = new System.Windows.Forms.TextBox();
            this.cboCurrencyHave = new System.Windows.Forms.ComboBox();
            this.cboCurrencyWant = new System.Windows.Forms.ComboBox();
            this.lblCurrencyCode1 = new System.Windows.Forms.Label();
            this.lblCurrencyCode2 = new System.Windows.Forms.Label();
            this.grpConversion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrencyHave
            // 
            this.lblCurrencyHave.AutoSize = true;
            this.lblCurrencyHave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyHave.Location = new System.Drawing.Point(35, 54);
            this.lblCurrencyHave.Name = "lblCurrencyHave";
            this.lblCurrencyHave.Size = new System.Drawing.Size(122, 17);
            this.lblCurrencyHave.TabIndex = 0;
            this.lblCurrencyHave.Text = "Currency I have";
            // 
            // lblCurencyHave
            // 
            this.lblCurencyHave.AutoSize = true;
            this.lblCurencyHave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurencyHave.Location = new System.Drawing.Point(281, 57);
            this.lblCurencyHave.Name = "lblCurencyHave";
            this.lblCurencyHave.Size = new System.Drawing.Size(120, 17);
            this.lblCurencyHave.TabIndex = 1;
            this.lblCurencyHave.Text = "Currency I want";
            // 
            // lblAmountHave
            // 
            this.lblAmountHave.AutoSize = true;
            this.lblAmountHave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountHave.Location = new System.Drawing.Point(35, 138);
            this.lblAmountHave.Name = "lblAmountHave";
            this.lblAmountHave.Size = new System.Drawing.Size(111, 17);
            this.lblAmountHave.TabIndex = 2;
            this.lblAmountHave.Text = "Amount I have";
            // 
            // lblAmountWant
            // 
            this.lblAmountWant.AutoSize = true;
            this.lblAmountWant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountWant.Location = new System.Drawing.Point(281, 141);
            this.lblAmountWant.Name = "lblAmountWant";
            this.lblAmountWant.Size = new System.Drawing.Size(109, 17);
            this.lblAmountWant.TabIndex = 3;
            this.lblAmountWant.Text = "Amount I want";
            // 
            // cmdEquals
            // 
            this.cmdEquals.Enabled = false;
            this.cmdEquals.Location = new System.Drawing.Point(162, 138);
            this.cmdEquals.Name = "cmdEquals";
            this.cmdEquals.Size = new System.Drawing.Size(75, 23);
            this.cmdEquals.TabIndex = 4;
            this.cmdEquals.Text = "equals";
            this.cmdEquals.UseVisualStyleBackColor = true;
            this.cmdEquals.Click += new System.EventHandler(this.cmdEquals_Click);
            // 
            // grpConversion
            // 
            this.grpConversion.Controls.Add(this.optConversionNo);
            this.grpConversion.Controls.Add(this.optConversionYes);
            this.grpConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConversion.Location = new System.Drawing.Point(162, 198);
            this.grpConversion.Name = "grpConversion";
            this.grpConversion.Size = new System.Drawing.Size(178, 86);
            this.grpConversion.TabIndex = 5;
            this.grpConversion.TabStop = false;
            this.grpConversion.Text = "Another conversion?";
            this.grpConversion.Visible = false;
            // 
            // optConversionNo
            // 
            this.optConversionNo.AutoSize = true;
            this.optConversionNo.Location = new System.Drawing.Point(13, 44);
            this.optConversionNo.Name = "optConversionNo";
            this.optConversionNo.Size = new System.Drawing.Size(46, 21);
            this.optConversionNo.TabIndex = 1;
            this.optConversionNo.TabStop = true;
            this.optConversionNo.Text = "No";
            this.optConversionNo.UseVisualStyleBackColor = true;
            this.optConversionNo.CheckedChanged += new System.EventHandler(this.optConversionNo_CheckedChanged);
            // 
            // optConversionYes
            // 
            this.optConversionYes.AutoSize = true;
            this.optConversionYes.Location = new System.Drawing.Point(13, 20);
            this.optConversionYes.Name = "optConversionYes";
            this.optConversionYes.Size = new System.Drawing.Size(53, 21);
            this.optConversionYes.TabIndex = 0;
            this.optConversionYes.TabStop = true;
            this.optConversionYes.Text = "Yes";
            this.optConversionYes.UseVisualStyleBackColor = true;
            this.optConversionYes.CheckedChanged += new System.EventHandler(this.optConversionYes_CheckedChanged);
            // 
            // txtAmountHave
            // 
            this.txtAmountHave.Enabled = false;
            this.txtAmountHave.Location = new System.Drawing.Point(38, 155);
            this.txtAmountHave.Name = "txtAmountHave";
            this.txtAmountHave.Size = new System.Drawing.Size(100, 20);
            this.txtAmountHave.TabIndex = 6;
            this.txtAmountHave.TextChanged += new System.EventHandler(this.txtAmountHave_TextChanged);
            // 
            // txtAmountWant
            // 
            this.txtAmountWant.Enabled = false;
            this.txtAmountWant.Location = new System.Drawing.Point(284, 158);
            this.txtAmountWant.Name = "txtAmountWant";
            this.txtAmountWant.Size = new System.Drawing.Size(100, 20);
            this.txtAmountWant.TabIndex = 7;
            // 
            // cboCurrencyHave
            // 
            this.cboCurrencyHave.FormattingEnabled = true;
            this.cboCurrencyHave.Location = new System.Drawing.Point(38, 71);
            this.cboCurrencyHave.Name = "cboCurrencyHave";
            this.cboCurrencyHave.Size = new System.Drawing.Size(121, 21);
            this.cboCurrencyHave.TabIndex = 8;
            this.cboCurrencyHave.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyHave_SelectedIndexChanged);
            // 
            // cboCurrencyWant
            // 
            this.cboCurrencyWant.Enabled = false;
            this.cboCurrencyWant.FormattingEnabled = true;
            this.cboCurrencyWant.Location = new System.Drawing.Point(284, 74);
            this.cboCurrencyWant.Name = "cboCurrencyWant";
            this.cboCurrencyWant.Size = new System.Drawing.Size(121, 21);
            this.cboCurrencyWant.TabIndex = 9;
            this.cboCurrencyWant.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyWant_SelectedIndexChanged);
            // 
            // lblCurrencyCode1
            // 
            this.lblCurrencyCode1.AutoSize = true;
            this.lblCurrencyCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCode1.Location = new System.Drawing.Point(1, 158);
            this.lblCurrencyCode1.Name = "lblCurrencyCode1";
            this.lblCurrencyCode1.Size = new System.Drawing.Size(31, 13);
            this.lblCurrencyCode1.TabIndex = 10;
            this.lblCurrencyCode1.Text = "XXX";
            this.lblCurrencyCode1.Visible = false;
            // 
            // lblCurrencyCode2
            // 
            this.lblCurrencyCode2.AutoSize = true;
            this.lblCurrencyCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCode2.Location = new System.Drawing.Point(249, 161);
            this.lblCurrencyCode2.Name = "lblCurrencyCode2";
            this.lblCurrencyCode2.Size = new System.Drawing.Size(31, 13);
            this.lblCurrencyCode2.TabIndex = 11;
            this.lblCurrencyCode2.Text = "XXX";
            this.lblCurrencyCode2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 332);
            this.Controls.Add(this.lblCurrencyCode2);
            this.Controls.Add(this.lblCurrencyCode1);
            this.Controls.Add(this.cboCurrencyWant);
            this.Controls.Add(this.cboCurrencyHave);
            this.Controls.Add(this.txtAmountWant);
            this.Controls.Add(this.txtAmountHave);
            this.Controls.Add(this.grpConversion);
            this.Controls.Add(this.cmdEquals);
            this.Controls.Add(this.lblAmountWant);
            this.Controls.Add(this.lblAmountHave);
            this.Controls.Add(this.lblCurencyHave);
            this.Controls.Add(this.lblCurrencyHave);
            this.MinimumSize = new System.Drawing.Size(450, 371);
            this.Name = "Form1";
            this.Text = "Currency Convertor";
            this.grpConversion.ResumeLayout(false);
            this.grpConversion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrencyHave;
        private System.Windows.Forms.Label lblCurencyHave;
        private System.Windows.Forms.Label lblAmountHave;
        private System.Windows.Forms.Label lblAmountWant;
        private System.Windows.Forms.Button cmdEquals;
        private System.Windows.Forms.GroupBox grpConversion;
        private System.Windows.Forms.RadioButton optConversionNo;
        private System.Windows.Forms.RadioButton optConversionYes;
        private System.Windows.Forms.TextBox txtAmountHave;
        private System.Windows.Forms.TextBox txtAmountWant;
        private System.Windows.Forms.ComboBox cboCurrencyHave;
        private System.Windows.Forms.ComboBox cboCurrencyWant;
        private System.Windows.Forms.Label lblCurrencyCode1;
        private System.Windows.Forms.Label lblCurrencyCode2;
    }
}

