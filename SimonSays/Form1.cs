using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        #region Declaring Lists
        //Creating pattern list, buttonList, and backColorList
        public static List<int> patternList = new List<int>();
        public static List<Button> buttonList = new List<Button>();
        public static List<Color> backColorList = new List<Color>(new Color[]{Color.ForestGreen, Color.DarkBlue, Color.DarkRed, Color.Goldenrod});
        public static List<SoundPlayer> soundList = new List<SoundPlayer>();
        #endregion

        #region Sound Objects
        //Sound object creation
        SoundPlayer blueClickSound = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer greenClickSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redClickSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowClickSound = new SoundPlayer(Properties.Resources.yellow);

        //Mistake and game over sound
        public static SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
        #endregion

        #region Difficulty Variables
        //These are the variables that dictate the speed of the thread.sleep functions
        public static int pauseTime;
        public static int blinkSpaceTime;

        public static double timeForTurnMultiplier;
        public static double timeForTurn; //This is the amount of time allowed for a turn depending on how long the pattern is
        //Difficulty finding is in MenuScreen
        #endregion

        public Form1()
        {
            InitializeComponent();
            #region Add Sound objects to List
            soundList.Add(greenClickSound); //0
            soundList.Add(blueClickSound); //1
            soundList.Add(redClickSound); //2
            soundList.Add(yellowClickSound); //3
            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Launch MenuScreen
            ChangeScreen(this, new MenuScreen());
        }
        public static void ChangeScreen(object sender, UserControl nextScreen)
        {
            #region Change Screen Function
            Form f;
            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            nextScreen.Location = new Point((f.Width - nextScreen.Width) / 2, (f.Height - nextScreen.Height) / 2);
            f.Controls.Add(nextScreen);
            #endregion
        }
    }
}
