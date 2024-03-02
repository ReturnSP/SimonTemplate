namespace SimonSays
{
    partial class EndGameAnimation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.starTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // starTimer
            // 
            this.starTimer.Interval = 20;
            this.starTimer.Tick += new System.EventHandler(this.starTimer_Tick);
            // 
            // EndGameAnimation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DoubleBuffered = true;
            this.Name = "EndGameAnimation";
            this.Size = new System.Drawing.Size(1059, 659);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EndGameAnimation_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer starTimer;
    }
}
