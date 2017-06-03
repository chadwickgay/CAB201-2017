namespace Games {
    partial class PigWithTwoDiceForm {
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
            this.components = new System.ComponentModel.Container();
            this.grpAnotherGame = new System.Windows.Forms.GroupBox();
            this.optAnotherGameNo = new System.Windows.Forms.RadioButton();
            this.optAnotherGameYes = new System.Windows.Forms.RadioButton();
            this.txtPlayerTwoTotal = new System.Windows.Forms.TextBox();
            this.txtPlayerOneTotal = new System.Windows.Forms.TextBox();
            this.lblPlayerTwoTotal = new System.Windows.Forms.Label();
            this.lblPlayerOneTotal = new System.Windows.Forms.Label();
            this.picDie1 = new System.Windows.Forms.PictureBox();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnRoll = new System.Windows.Forms.Button();
            this.lblRollOrHold = new System.Windows.Forms.Label();
            this.lblWhoseTurn = new System.Windows.Forms.Label();
            this.picDie2 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.grpAnotherGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDie2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAnotherGame
            // 
            this.grpAnotherGame.Controls.Add(this.optAnotherGameNo);
            this.grpAnotherGame.Controls.Add(this.optAnotherGameYes);
            this.grpAnotherGame.Enabled = false;
            this.grpAnotherGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAnotherGame.Location = new System.Drawing.Point(301, 156);
            this.grpAnotherGame.Name = "grpAnotherGame";
            this.grpAnotherGame.Size = new System.Drawing.Size(122, 88);
            this.grpAnotherGame.TabIndex = 19;
            this.grpAnotherGame.TabStop = false;
            this.grpAnotherGame.Text = "Another Game?";
            // 
            // optAnotherGameNo
            // 
            this.optAnotherGameNo.AutoSize = true;
            this.optAnotherGameNo.Location = new System.Drawing.Point(22, 53);
            this.optAnotherGameNo.Name = "optAnotherGameNo";
            this.optAnotherGameNo.Size = new System.Drawing.Size(41, 17);
            this.optAnotherGameNo.TabIndex = 1;
            this.optAnotherGameNo.TabStop = true;
            this.optAnotherGameNo.Text = "No";
            this.optAnotherGameNo.UseVisualStyleBackColor = true;
            this.optAnotherGameNo.CheckedChanged += new System.EventHandler(this.optAnotherGameNo_CheckedChanged);
            // 
            // optAnotherGameYes
            // 
            this.optAnotherGameYes.AutoSize = true;
            this.optAnotherGameYes.Location = new System.Drawing.Point(22, 30);
            this.optAnotherGameYes.Name = "optAnotherGameYes";
            this.optAnotherGameYes.Size = new System.Drawing.Size(46, 17);
            this.optAnotherGameYes.TabIndex = 0;
            this.optAnotherGameYes.TabStop = true;
            this.optAnotherGameYes.Text = "Yes";
            this.optAnotherGameYes.UseVisualStyleBackColor = true;
            this.optAnotherGameYes.CheckedChanged += new System.EventHandler(this.optAnotherGameYes_CheckedChanged);
            // 
            // txtPlayerTwoTotal
            // 
            this.txtPlayerTwoTotal.Location = new System.Drawing.Point(338, 93);
            this.txtPlayerTwoTotal.Name = "txtPlayerTwoTotal";
            this.txtPlayerTwoTotal.ReadOnly = true;
            this.txtPlayerTwoTotal.Size = new System.Drawing.Size(96, 20);
            this.txtPlayerTwoTotal.TabIndex = 18;
            this.txtPlayerTwoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPlayerOneTotal
            // 
            this.txtPlayerOneTotal.Location = new System.Drawing.Point(338, 67);
            this.txtPlayerOneTotal.Name = "txtPlayerOneTotal";
            this.txtPlayerOneTotal.ReadOnly = true;
            this.txtPlayerOneTotal.Size = new System.Drawing.Size(96, 20);
            this.txtPlayerOneTotal.TabIndex = 17;
            this.txtPlayerOneTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPlayerTwoTotal
            // 
            this.lblPlayerTwoTotal.AutoSize = true;
            this.lblPlayerTwoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTwoTotal.Location = new System.Drawing.Point(246, 96);
            this.lblPlayerTwoTotal.Name = "lblPlayerTwoTotal";
            this.lblPlayerTwoTotal.Size = new System.Drawing.Size(86, 13);
            this.lblPlayerTwoTotal.TabIndex = 16;
            this.lblPlayerTwoTotal.Text = "Player 2 Total";
            // 
            // lblPlayerOneTotal
            // 
            this.lblPlayerOneTotal.AutoSize = true;
            this.lblPlayerOneTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerOneTotal.Location = new System.Drawing.Point(246, 69);
            this.lblPlayerOneTotal.Name = "lblPlayerOneTotal";
            this.lblPlayerOneTotal.Size = new System.Drawing.Size(86, 13);
            this.lblPlayerOneTotal.TabIndex = 15;
            this.lblPlayerOneTotal.Text = "Player 1 Total";
            // 
            // picDie1
            // 
            this.picDie1.Location = new System.Drawing.Point(112, 54);
            this.picDie1.Name = "picDie1";
            this.picDie1.Size = new System.Drawing.Size(55, 55);
            this.picDie1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDie1.TabIndex = 14;
            this.picDie1.TabStop = false;
            // 
            // btnHold
            // 
            this.btnHold.BackColor = System.Drawing.Color.Red;
            this.btnHold.Enabled = false;
            this.btnHold.Location = new System.Drawing.Point(139, 186);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(75, 23);
            this.btnHold.TabIndex = 13;
            this.btnHold.Text = "Hold";
            this.btnHold.UseVisualStyleBackColor = false;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnRoll
            // 
            this.btnRoll.BackColor = System.Drawing.Color.Lime;
            this.btnRoll.Location = new System.Drawing.Point(47, 186);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 12;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = false;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // lblRollOrHold
            // 
            this.lblRollOrHold.AutoSize = true;
            this.lblRollOrHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRollOrHold.Location = new System.Drawing.Point(19, 84);
            this.lblRollOrHold.Name = "lblRollOrHold";
            this.lblRollOrHold.Size = new System.Drawing.Size(74, 13);
            this.lblRollOrHold.TabIndex = 11;
            this.lblRollOrHold.Text = "Roll or Hold";
            // 
            // lblWhoseTurn
            // 
            this.lblWhoseTurn.AutoSize = true;
            this.lblWhoseTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhoseTurn.Location = new System.Drawing.Point(19, 66);
            this.lblWhoseTurn.Name = "lblWhoseTurn";
            this.lblWhoseTurn.Size = new System.Drawing.Size(87, 13);
            this.lblWhoseTurn.TabIndex = 10;
            this.lblWhoseTurn.Text = "Whose turn to";
            // 
            // picDie2
            // 
            this.picDie2.Location = new System.Drawing.Point(173, 54);
            this.picDie2.Name = "picDie2";
            this.picDie2.Size = new System.Drawing.Size(55, 55);
            this.picDie2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDie2.TabIndex = 20;
            this.picDie2.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PigWithTwoDiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 323);
            this.Controls.Add(this.picDie2);
            this.Controls.Add(this.grpAnotherGame);
            this.Controls.Add(this.txtPlayerTwoTotal);
            this.Controls.Add(this.txtPlayerOneTotal);
            this.Controls.Add(this.lblPlayerTwoTotal);
            this.Controls.Add(this.lblPlayerOneTotal);
            this.Controls.Add(this.picDie1);
            this.Controls.Add(this.btnHold);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.lblRollOrHold);
            this.Controls.Add(this.lblWhoseTurn);
            this.Name = "PigWithTwoDiceForm";
            this.Text = "Pig with Two Dice";
            this.grpAnotherGame.ResumeLayout(false);
            this.grpAnotherGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDie2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAnotherGame;
        private System.Windows.Forms.RadioButton optAnotherGameNo;
        private System.Windows.Forms.RadioButton optAnotherGameYes;
        private System.Windows.Forms.TextBox txtPlayerTwoTotal;
        private System.Windows.Forms.TextBox txtPlayerOneTotal;
        private System.Windows.Forms.Label lblPlayerTwoTotal;
        private System.Windows.Forms.Label lblPlayerOneTotal;
        private System.Windows.Forms.PictureBox picDie1;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Label lblRollOrHold;
        private System.Windows.Forms.Label lblWhoseTurn;
        private System.Windows.Forms.PictureBox picDie2;
        private System.Windows.Forms.Timer timer;
    }
}