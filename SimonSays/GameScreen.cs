using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        #region Declaring Game Screen Variables
        //Create an int guess variable to track what part of the pattern the user is at
        int guessCount;
        int num; //rand num
        #endregion

        public GameScreen()
        {
            InitializeComponent();

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //Clear the pattern list from form1
            Form1.patternList.Clear();
            #region buttonAdding
            Form1.buttonList.Add(greenButton); //0
            Form1.buttonList.Add(blueButton); //1
            Form1.buttonList.Add(redButton); //2
            Form1.buttonList.Add(yellowButton); //3
            #endregion

            //Refresh the page
            Refresh();
            //Pause for a second
            Thread.Sleep(1000);
            //run the pattern
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            #region Create random num
            //Get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list. Each number represents a button. 0 is green, 1 is blue, 2 is red and 3 is yellow
            num = 0; //Initiallizing num to 0 in order to stop the list from leaving the range of numbers
            Random numGen = new Random();
            num += numGen.Next(0, 4);
            Form1.patternList.Add(num);
            #endregion

            CountDownTimer.Start();

            //Create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.patternList.Count(); i++)
            {
                num = Form1.patternList[i];
                Thread.Sleep(Form1.blinkSpaceTime);
                buttonFlashing();
                Form1.timeForTurn = Form1.patternList.Count() * Form1.timeForTurnMultiplier;
            }
            //TODO: set guess value back to 0
            guessCount = 0;
        }

        /// <summary>
        /// This is a generalized function for button flashing
        /// </summary>
        public void buttonFlashing()
        {
            Form1.buttonList[num].BackColor = Color.White;
            Refresh();
            Thread.Sleep(250);
            Form1.buttonList[num].BackColor = Form1.backColorList[num];
            Refresh();
            Thread.Sleep(250);
            
        }
        /// <summary>
        /// This is a generalized function for every button click event
        /// </summary>
        public void ButtonClickFuncton()
        {

            #region Button Click General Function
            //buttonTeleport();

            Form1.buttonList[num].BackColor = Color.Gray;
            Form1.soundList[num].Play(); //Play the sound of the button the player has clicked

            Refresh();
            Thread.Sleep(Form1.pauseTime);

            Form1.buttonList[num].BackColor = Form1.backColorList[num];//Change button color back
            Thread.Sleep(Form1.pauseTime);
            Refresh();

            guessCount++;

            if (guessCount == Form1.patternList.Count())
            {
                ComputerTurn();
            }

            #endregion
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            #region Green Button Click Code
            if (Form1.patternList[guessCount] == 0)
            {
                num = 0;
                ButtonClickFuncton();
            }
            else
            {
                GameOver();
            }
            #endregion
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            #region Red Button Click Code
            if (Form1.patternList[guessCount] == 2)
            {
                num = 2;
                ButtonClickFuncton();
            }
            else
            {
                GameOver();
            }
            #endregion
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            #region Yellow Button Click Code
            if (Form1.patternList[guessCount] == 3)
            {
                num = 3;
                ButtonClickFuncton();

            }
            else
            {
                GameOver();
            }
            #endregion
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            #region Blue Button Click Code
            if (Form1.patternList[guessCount] == 1)
            {
                num = 1;
                ButtonClickFuncton();
            }
            else
            {
                GameOver();
            }
            #endregion
        }

        private void buttonTeleport() { 
        
            Random newCoords = new Random();
            int ButtonX;
            int buttonY;
            //randomize button locations
            
            greenButton.Location = new Point(ButtonX = newCoords.Next(0 + greenButton.Width, this.Width- greenButton.Width), buttonY = newCoords.Next(0 + greenButton.Height, this.Height - greenButton.Height));
            redButton.Location = new Point (ButtonX = newCoords.Next(0 + redButton.Width, this.Width-redButton.Width), buttonY = newCoords.Next(0 + redButton.Height, this.Height - redButton.Height));
            yellowButton.Location = new Point(ButtonX = newCoords.Next(0 + yellowButton.Width, this.Width - yellowButton.Width), buttonY = newCoords.Next(0 + yellowButton.Height, this.Height - yellowButton.Height));
            blueButton.Location = new Point(ButtonX = newCoords.Next(0 + blueButton.Width, this.Width - blueButton.Width), buttonY = newCoords.Next(0 + blueButton.Height, this.Height - blueButton.Height));

        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            //double countDown = Form1.timeForTurn * Form1.timeForTurnMultiplier;
            //countDown--; 
            //if (countDown <= 0)
            //{
            //    GameOver();
            //}
        }

        public void GameOver()
        {
            //Play a game over sound
            Form1.mistakeSound.Play();

            //Close this screen and open the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
             
        }
    }
}
