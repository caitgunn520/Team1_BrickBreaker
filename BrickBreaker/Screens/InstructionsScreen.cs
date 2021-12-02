﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BrickBreaker
{
    public partial class InstructionsScreen : UserControl
    {
        bool mDown, downArrowDown, upArrowDown = false;
        int musicCounter = 10000;
        int state = 0;

        System.Windows.Media.MediaPlayer instructionsMusic;

        public InstructionsScreen()
        {
            InitializeComponent();
            gameTimer.Enabled = true;
            //instructionsMusic = new System.Windows.Media.MediaPlayer();
            //instructionsMusic.Open(new Uri(Application.StartupPath + "/Resources/instructionsTheme.mp3"));
        }

        private void InstructionsScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.M):
                    mDown = true;
                break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
            }
        }

        private void InstructionsScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.M):
                    mDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (musicCounter >= 590)
            {
                instructionsMusic.Stop();
                instructionsMusic.Play();
                musicCounter = 0;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (musicCounter >= 590)
            {
                instructionsMusic.Stop();
                instructionsMusic.Play();
                musicCounter = 0;
            }

            if (mDown)
            {
                instructionsMusic.Stop();
                gameLoop.Enabled = false;

                Form f = this.FindForm();
                f.Controls.Remove(this);

                MenuScreen ms = new MenuScreen();
                ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
                f.Controls.Add(ms);

                mDown = false;

                ms.Focus();
            }

            switch (state)
            {
                case (0):
                    if (downArrowDown)
                    {
                        state = 1;
                    }
                    break;
                case (1):
                    if (upArrowDown)
                    {
                        state = 0;
                    }
                    break;
            }

            musicCounter++;

            Refresh();
        }

        private void InstructionsScreen_Paint(object sender, PaintEventArgs e)
        {
            switch (state)
            {
                case (0):
                    this.BackgroundImage = Properties.Resources.instructionScreen;
                    break;
                case (1):
                    this.BackgroundImage = Properties.Resources.InstructionScreen2;
                    break;
            }
        }
    }
}
