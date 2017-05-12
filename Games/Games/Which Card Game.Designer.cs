namespace Games {
    partial class WhichCardGameForm {
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
            this.lblChooseGame = new System.Windows.Forms.Label();
            this.cboCardGameSelect = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChooseGame
            // 
            this.lblChooseGame.AutoSize = true;
            this.lblChooseGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseGame.Location = new System.Drawing.Point(28, 27);
            this.lblChooseGame.Name = "lblChooseGame";
            this.lblChooseGame.Size = new System.Drawing.Size(227, 24);
            this.lblChooseGame.TabIndex = 0;
            this.lblChooseGame.Text = "Choose a Game to play";
            // 
            // cboCardGameSelect
            // 
            this.cboCardGameSelect.DisplayMember = "Solitaire";
            this.cboCardGameSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardGameSelect.FormattingEnabled = true;
            this.cboCardGameSelect.Location = new System.Drawing.Point(71, 79);
            this.cboCardGameSelect.Name = "cboCardGameSelect";
            this.cboCardGameSelect.Size = new System.Drawing.Size(121, 21);
            this.cboCardGameSelect.TabIndex = 1;
            this.cboCardGameSelect.SelectedIndexChanged += new System.EventHandler(this.cboCardGameSelect_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(84, 155);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 42);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WhichCardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboCardGameSelect);
            this.Controls.Add(this.lblChooseGame);
            this.Name = "WhichCardGameForm";
            this.Text = "Card Games";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseGame;
        private System.Windows.Forms.ComboBox cboCardGameSelect;
        private System.Windows.Forms.Button btnExit;
    }
}