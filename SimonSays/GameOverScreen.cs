using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            #region Final Score Display
            //show the length of the pattern
            int Score = Form1.patternList.Count();
            lengthLabel.Text = $"{Score}";
            #endregion
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //Close this screen and open the MenuScreen
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
