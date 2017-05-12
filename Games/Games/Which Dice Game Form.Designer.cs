namespace Games {
    partial class WhichDiceGameForm {
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
            this.grpDiceGameSelect = new System.Windows.Forms.GroupBox();
            this.optTwoDicePig = new System.Windows.Forms.RadioButton();
            this.optSingleDiePig = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpDiceGameSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDiceGameSelect
            // 
            this.grpDiceGameSelect.Controls.Add(this.optTwoDicePig);
            this.grpDiceGameSelect.Controls.Add(this.optSingleDiePig);
            this.grpDiceGameSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDiceGameSelect.Location = new System.Drawing.Point(34, 22);
            this.grpDiceGameSelect.Name = "grpDiceGameSelect";
            this.grpDiceGameSelect.Size = new System.Drawing.Size(176, 100);
            this.grpDiceGameSelect.TabIndex = 0;
            this.grpDiceGameSelect.TabStop = false;
            this.grpDiceGameSelect.Text = "Select which Pig to play";
            // 
            // optTwoDicePig
            // 
            this.optTwoDicePig.AutoSize = true;
            this.optTwoDicePig.Location = new System.Drawing.Point(27, 54);
            this.optTwoDicePig.Name = "optTwoDicePig";
            this.optTwoDicePig.Size = new System.Drawing.Size(101, 17);
            this.optTwoDicePig.TabIndex = 1;
            this.optTwoDicePig.Text = "Two Dice Pig";
            this.optTwoDicePig.UseVisualStyleBackColor = true;
            this.optTwoDicePig.CheckedChanged += new System.EventHandler(this.optTwoDicePig_CheckedChanged);
            // 
            // optSingleDiePig
            // 
            this.optSingleDiePig.AutoSize = true;
            this.optSingleDiePig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSingleDiePig.Location = new System.Drawing.Point(27, 30);
            this.optSingleDiePig.Name = "optSingleDiePig";
            this.optSingleDiePig.Size = new System.Drawing.Size(105, 17);
            this.optSingleDiePig.TabIndex = 0;
            this.optSingleDiePig.Text = "Single Die Pig";
            this.optSingleDiePig.UseVisualStyleBackColor = true;
            this.optSingleDiePig.CheckedChanged += new System.EventHandler(this.optSingleDiePig_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(79, 135);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 27);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WhichDiceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 178);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpDiceGameSelect);
            this.Name = "WhichDiceGameForm";
            this.Text = "Dice Games";
            this.grpDiceGameSelect.ResumeLayout(false);
            this.grpDiceGameSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDiceGameSelect;
        private System.Windows.Forms.RadioButton optTwoDicePig;
        private System.Windows.Forms.RadioButton optSingleDiePig;
        private System.Windows.Forms.Button btnExit;
    }
}