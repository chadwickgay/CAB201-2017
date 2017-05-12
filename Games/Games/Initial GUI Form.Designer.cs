namespace Games {
    partial class IntitalGUIForm {
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpGameSelect = new System.Windows.Forms.GroupBox();
            this.optCardGame = new System.Windows.Forms.RadioButton();
            this.optDiceGame = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpGameSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(41, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Interactive Games";
            // 
            // grpGameSelect
            // 
            this.grpGameSelect.Controls.Add(this.optCardGame);
            this.grpGameSelect.Controls.Add(this.optDiceGame);
            this.grpGameSelect.Location = new System.Drawing.Point(55, 66);
            this.grpGameSelect.Name = "grpGameSelect";
            this.grpGameSelect.Size = new System.Drawing.Size(144, 100);
            this.grpGameSelect.TabIndex = 1;
            this.grpGameSelect.TabStop = false;
            this.grpGameSelect.Text = "Select Game Type";
            // 
            // optCardGame
            // 
            this.optCardGame.AutoSize = true;
            this.optCardGame.Location = new System.Drawing.Point(19, 44);
            this.optCardGame.Name = "optCardGame";
            this.optCardGame.Size = new System.Drawing.Size(78, 17);
            this.optCardGame.TabIndex = 1;
            this.optCardGame.Text = "Card Game";
            this.optCardGame.UseVisualStyleBackColor = true;
            this.optCardGame.CheckedChanged += new System.EventHandler(this.optCardGame_CheckedChanged);
            // 
            // optDiceGame
            // 
            this.optDiceGame.AutoSize = true;
            this.optDiceGame.Location = new System.Drawing.Point(19, 20);
            this.optDiceGame.Name = "optDiceGame";
            this.optDiceGame.Size = new System.Drawing.Size(76, 17);
            this.optDiceGame.TabIndex = 0;
            this.optDiceGame.Text = "Dice game";
            this.optDiceGame.UseVisualStyleBackColor = true;
            this.optDiceGame.CheckedChanged += new System.EventHandler(this.optDiceGame_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(74, 208);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 27);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(74, 255);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // IntitalGUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 321);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpGameSelect);
            this.Controls.Add(this.lblTitle);
            this.Name = "IntitalGUIForm";
            this.Text = "Games";
            this.grpGameSelect.ResumeLayout(false);
            this.grpGameSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpGameSelect;
        private System.Windows.Forms.RadioButton optCardGame;
        private System.Windows.Forms.RadioButton optDiceGame;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
    }
}

