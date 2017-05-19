using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logic_Library;


namespace Games {
    public partial class PigGameForm : Form {
        public PigGameForm() {
            InitializeComponent();

            Pig_Single_Die_Game.SetUpGame();

            SetDieImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void lblPlayerTwoTotal_Click(object sender, EventArgs e) {

        }

        private void btnRoll_Click(object sender, EventArgs e) {
            Pig_Single_Die_Game.PlayGame();

            SetDieImage();

            btnHold.Enabled = true;
        }

        private void SetDieImage() {
            picDie.Image = Images.GetDieImage(Pig_Single_Die_Game.GetFaceValue());
        }

    }
}
