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
            this.btnEquals = new System.Windows.Forms.Button();
            this.grpConversion = new System.Windows.Forms.GroupBox();
            this.optConversionNo = new System.Windows.Forms.RadioButton();
            this.optConversionYes = new System.Windows.Forms.RadioButton();
            this.txtAmountHave = new System.Windows.Forms.TextBox();
            this.txtAmountWant = new System.Windows.Forms.TextBox();
            this.cboCurrencyHave = new System.Windows.Forms.ComboBox();
            this.cboCurrencyWant = new System.Windows.Forms.ComboBox();
            this.lblCurrencyCodeHave = new System.Windows.Forms.Label();
            this.lblCurrencyCodeWant = new System.Windows.Forms.Label();
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
            // btnEquals
            // 
            this.btnEquals.Enabled = false;
            this.btnEquals.Location = new System.Drawing.Point(162, 138);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(75, 23);
            this.btnEquals.TabIndex = 4;
            this.btnEquals.Text = "equals";
            this.btnEquals.UseVisualStyleBackColor = true;
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
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
            this.optConversionNo.CheckedChanged += new System.EventHandler(this.optConversion_CheckedChanged);
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
            this.optConversionYes.CheckedChanged += new System.EventHandler(this.optConversion_CheckedChanged);
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
            // 
            // cboCurrencyWant
            // 
            this.cboCurrencyWant.Enabled = false;
            this.cboCurrencyWant.FormattingEnabled = true;
            this.cboCurrencyWant.Location = new System.Drawing.Point(284, 74);
            this.cboCurrencyWant.Name = "cboCurrencyWant";
            this.cboCurrencyWant.Size = new System.Drawing.Size(121, 21);
            this.cboCurrencyWant.TabIndex = 9;
            // 
            // lblCurrencyCodeHave
            // 
            this.lblCurrencyCodeHave.AutoSize = true;
            this.lblCurrencyCodeHave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCodeHave.Location = new System.Drawing.Point(1, 158);
            this.lblCurrencyCodeHave.Name = "lblCurrencyCodeHave";
            this.lblCurrencyCodeHave.Size = new System.Drawing.Size(31, 13);
            this.lblCurrencyCodeHave.TabIndex = 10;
            this.lblCurrencyCodeHave.Text = "XXX";
            this.lblCurrencyCodeHave.Visible = false;
            // 
            // lblCurrencyCodeWant
            // 
            this.lblCurrencyCodeWant.AutoSize = true;
            this.lblCurrencyCodeWant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCodeWant.Location = new System.Drawing.Point(249, 161);
            this.lblCurrencyCodeWant.Name = "lblCurrencyCodeWant";
            this.lblCurrencyCodeWant.Size = new System.Drawing.Size(31, 13);
            this.lblCurrencyCodeWant.TabIndex = 11;
            this.lblCurrencyCodeWant.Text = "XXX";
            this.lblCurrencyCodeWant.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 332);
            this.Controls.Add(this.lblCurrencyCodeWant);
            this.Controls.Add(this.lblCurrencyCodeHave);
            this.Controls.Add(this.cboCurrencyWant);
            this.Controls.Add(this.cboCurrencyHave);
            this.Controls.Add(this.txtAmountWant);
            this.Controls.Add(this.txtAmountHave);
            this.Controls.Add(this.grpConversion);
            this.Controls.Add(this.btnEquals);
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
        private System.Windows.Forms.Button btnEquals;
        private System.Windows.Forms.GroupBox grpConversion;
        private System.Windows.Forms.RadioButton optConversionNo;
        private System.Windows.Forms.RadioButton optConversionYes;
        private System.Windows.Forms.TextBox txtAmountHave;
        private System.Windows.Forms.TextBox txtAmountWant;
        private System.Windows.Forms.ComboBox cboCurrencyHave;
        private System.Windows.Forms.ComboBox cboCurrencyWant;
        private System.Windows.Forms.Label lblCurrencyCodeHave;
        private System.Windows.Forms.Label lblCurrencyCodeWant;
    }
}

