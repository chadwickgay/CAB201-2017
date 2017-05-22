namespace Games {
    partial class TwentyOneGameForm {
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
            this.tblPanelDealer = new System.Windows.Forms.TableLayoutPanel();
            this.tblPanelPlayer = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblBustedPlayer = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblPointsPlayer = new System.Windows.Forms.Label();
            this.lblGamesWonPlayer = new System.Windows.Forms.Label();
            this.lblNumberWonPlayer = new System.Windows.Forms.Label();
            this.lblBustedDealer = new System.Windows.Forms.Label();
            this.lblDealer = new System.Windows.Forms.Label();
            this.lblPointsDealer = new System.Windows.Forms.Label();
            this.lblGamesWonDealer = new System.Windows.Forms.Label();
            this.lblNumberWonDealer = new System.Windows.Forms.Label();
            this.lblAcesWithValueOne = new System.Windows.Forms.Label();
            this.lblNumberAcesValueOne = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tblPanelDealer
            // 
            this.tblPanelDealer.ColumnCount = 8;
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelDealer.Location = new System.Drawing.Point(27, 75);
            this.tblPanelDealer.Name = "tblPanelDealer";
            this.tblPanelDealer.RowCount = 1;
            this.tblPanelDealer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanelDealer.Size = new System.Drawing.Size(576, 95);
            this.tblPanelDealer.TabIndex = 0;
            // 
            // tblPanelPlayer
            // 
            this.tblPanelPlayer.ColumnCount = 8;
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblPanelPlayer.Location = new System.Drawing.Point(27, 204);
            this.tblPanelPlayer.Name = "tblPanelPlayer";
            this.tblPanelPlayer.RowCount = 1;
            this.tblPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tblPanelPlayer.Size = new System.Drawing.Size(576, 95);
            this.tblPanelPlayer.TabIndex = 1;
            // 
            // btnDeal
            // 
            this.btnDeal.Location = new System.Drawing.Point(36, 369);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(75, 23);
            this.btnDeal.TabIndex = 2;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // btnHit
            // 
            this.btnHit.Enabled = false;
            this.btnHit.Location = new System.Drawing.Point(145, 369);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(75, 23);
            this.btnHit.TabIndex = 3;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.Enabled = false;
            this.btnStand.Location = new System.Drawing.Point(246, 369);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(75, 23);
            this.btnStand.TabIndex = 4;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(527, 347);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblBustedPlayer
            // 
            this.lblBustedPlayer.AutoSize = true;
            this.lblBustedPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBustedPlayer.ForeColor = System.Drawing.Color.Red;
            this.lblBustedPlayer.Location = new System.Drawing.Point(127, 321);
            this.lblBustedPlayer.Name = "lblBustedPlayer";
            this.lblBustedPlayer.Size = new System.Drawing.Size(85, 24);
            this.lblBustedPlayer.TabIndex = 7;
            this.lblBustedPlayer.Text = "BUSTED";
            this.lblBustedPlayer.Visible = false;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(242, 321);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(68, 24);
            this.lblPlayer.TabIndex = 8;
            this.lblPlayer.Text = "Player";
            // 
            // lblPointsPlayer
            // 
            this.lblPointsPlayer.AutoSize = true;
            this.lblPointsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsPlayer.Location = new System.Drawing.Point(330, 321);
            this.lblPointsPlayer.Name = "lblPointsPlayer";
            this.lblPointsPlayer.Size = new System.Drawing.Size(79, 24);
            this.lblPointsPlayer.TabIndex = 9;
            this.lblPointsPlayer.Text = "POINTS";
            // 
            // lblGamesWonPlayer
            // 
            this.lblGamesWonPlayer.AutoSize = true;
            this.lblGamesWonPlayer.Location = new System.Drawing.Point(464, 321);
            this.lblGamesWonPlayer.Name = "lblGamesWonPlayer";
            this.lblGamesWonPlayer.Size = new System.Drawing.Size(63, 13);
            this.lblGamesWonPlayer.TabIndex = 10;
            this.lblGamesWonPlayer.Text = "Games won";
            // 
            // lblNumberWonPlayer
            // 
            this.lblNumberWonPlayer.AutoSize = true;
            this.lblNumberWonPlayer.BackColor = System.Drawing.Color.White;
            this.lblNumberWonPlayer.Location = new System.Drawing.Point(533, 321);
            this.lblNumberWonPlayer.Name = "lblNumberWonPlayer";
            this.lblNumberWonPlayer.Size = new System.Drawing.Size(13, 13);
            this.lblNumberWonPlayer.TabIndex = 11;
            this.lblNumberWonPlayer.Text = "0";
            // 
            // lblBustedDealer
            // 
            this.lblBustedDealer.AutoSize = true;
            this.lblBustedDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBustedDealer.ForeColor = System.Drawing.Color.Red;
            this.lblBustedDealer.Location = new System.Drawing.Point(127, 29);
            this.lblBustedDealer.Name = "lblBustedDealer";
            this.lblBustedDealer.Size = new System.Drawing.Size(85, 24);
            this.lblBustedDealer.TabIndex = 12;
            this.lblBustedDealer.Text = "BUSTED";
            this.lblBustedDealer.Visible = false;
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealer.Location = new System.Drawing.Point(242, 29);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(71, 24);
            this.lblDealer.TabIndex = 13;
            this.lblDealer.Text = "Dealer";
            // 
            // lblPointsDealer
            // 
            this.lblPointsDealer.AutoSize = true;
            this.lblPointsDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsDealer.Location = new System.Drawing.Point(330, 29);
            this.lblPointsDealer.Name = "lblPointsDealer";
            this.lblPointsDealer.Size = new System.Drawing.Size(79, 24);
            this.lblPointsDealer.TabIndex = 14;
            this.lblPointsDealer.Text = "POINTS";
            // 
            // lblGamesWonDealer
            // 
            this.lblGamesWonDealer.AutoSize = true;
            this.lblGamesWonDealer.Location = new System.Drawing.Point(464, 29);
            this.lblGamesWonDealer.Name = "lblGamesWonDealer";
            this.lblGamesWonDealer.Size = new System.Drawing.Size(63, 13);
            this.lblGamesWonDealer.TabIndex = 15;
            this.lblGamesWonDealer.Text = "Games won";
            // 
            // lblNumberWonDealer
            // 
            this.lblNumberWonDealer.AutoSize = true;
            this.lblNumberWonDealer.BackColor = System.Drawing.Color.White;
            this.lblNumberWonDealer.Location = new System.Drawing.Point(533, 29);
            this.lblNumberWonDealer.Name = "lblNumberWonDealer";
            this.lblNumberWonDealer.Size = new System.Drawing.Size(13, 13);
            this.lblNumberWonDealer.TabIndex = 16;
            this.lblNumberWonDealer.Text = "0";
            // 
            // lblAcesWithValueOne
            // 
            this.lblAcesWithValueOne.AutoSize = true;
            this.lblAcesWithValueOne.Location = new System.Drawing.Point(289, 350);
            this.lblAcesWithValueOne.Name = "lblAcesWithValueOne";
            this.lblAcesWithValueOne.Size = new System.Drawing.Size(91, 13);
            this.lblAcesWithValueOne.TabIndex = 17;
            this.lblAcesWithValueOne.Text = "Aces with value 1";
            // 
            // lblNumberAcesValueOne
            // 
            this.lblNumberAcesValueOne.AutoSize = true;
            this.lblNumberAcesValueOne.BackColor = System.Drawing.Color.White;
            this.lblNumberAcesValueOne.Location = new System.Drawing.Point(270, 350);
            this.lblNumberAcesValueOne.Name = "lblNumberAcesValueOne";
            this.lblNumberAcesValueOne.Size = new System.Drawing.Size(13, 13);
            this.lblNumberAcesValueOne.TabIndex = 18;
            this.lblNumberAcesValueOne.Text = "0";
            // 
            // TwentyOneGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 421);
            this.Controls.Add(this.lblNumberAcesValueOne);
            this.Controls.Add(this.lblAcesWithValueOne);
            this.Controls.Add(this.lblNumberWonDealer);
            this.Controls.Add(this.lblGamesWonDealer);
            this.Controls.Add(this.lblPointsDealer);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.lblBustedDealer);
            this.Controls.Add(this.lblNumberWonPlayer);
            this.Controls.Add(this.lblGamesWonPlayer);
            this.Controls.Add(this.lblPointsPlayer);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblBustedPlayer);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.tblPanelPlayer);
            this.Controls.Add(this.tblPanelDealer);
            this.Name = "TwentyOneGameForm";
            this.Text = "Twenty-One";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblPanelDealer;
        private System.Windows.Forms.TableLayoutPanel tblPanelPlayer;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblBustedPlayer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblPointsPlayer;
        private System.Windows.Forms.Label lblGamesWonPlayer;
        private System.Windows.Forms.Label lblNumberWonPlayer;
        private System.Windows.Forms.Label lblBustedDealer;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.Label lblPointsDealer;
        private System.Windows.Forms.Label lblGamesWonDealer;
        private System.Windows.Forms.Label lblNumberWonDealer;
        private System.Windows.Forms.Label lblAcesWithValueOne;
        private System.Windows.Forms.Label lblNumberAcesValueOne;
    }
}