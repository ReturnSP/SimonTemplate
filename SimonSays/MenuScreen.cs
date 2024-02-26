using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        bool difficultyState = false;

        public MenuScreen()
        {
            InitializeComponent();
            #region Initialized Game Settings
            //If player doesn't choose seperate difficulty these are normal settings
            Form1.pauseTime = 250;
            Form1.blinkSpaceTime = 300;
            Form1.timeForTurnMultiplier = 1.5;
            #endregion
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            //TODO: remove this screen and start the GameScreen
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //TODO: end the application
            Application.Exit();
        }

        private void difficultySelectButton_Click(object sender, EventArgs e)
        {
            #region Finding difficulty
            //Declare all variables needed
            //False means slow and true means Hard mode

            //initialize button text for multiple presses
            difficultySelectButton.Text = "";
            Refresh();

            //Check state of button
            //If I click this once it is Hard mode, if I click it once more it becomes slow mode
            difficultyState = !difficultyState;
            //Output state of button and find pause time for game
            if (!difficultyState)
            {
                Form1.pauseTime = 450; //slow mode
                Form1.blinkSpaceTime = 500;
                Form1.timeForTurnMultiplier = 1.5;
                difficultySelectButton.Text = "";
                difficultySelectButton.Text = "Slow Mode";
            }
            else
            {
                Form1.pauseTime = 250; //Hard mode
                Form1.blinkSpaceTime = 300;
                Form1.timeForTurnMultiplier = 1.2;
                difficultySelectButton.Text = "";
                difficultySelectButton.Text = "Hard Mode";
            }
            Refresh();
            #endregion
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {

        }
    }
}