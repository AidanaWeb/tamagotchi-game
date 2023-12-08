using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tamagotchi_4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            gameIsStarted = true;
            labelPetsName.Text = AllData1.PetsName;

            tick = 0;
            age.Value = 0;
            mood.Value = 100;
            energy.Value = 100;

            // Toy tamagotchi
            switch (AllData1.Toy)
            {
                case 1: pictureToy.Image = Properties.Resources.toy1_BG;
                    picturePet.Location = new Point(148, 255);
                    break;
                case 2: pictureToy.Image = Properties.Resources.toy2_BG;
                    picturePet.Location = new Point(148, 250);
                    break;
                case 3: pictureToy.Image = Properties.Resources.toy3_BG;
                    picturePet.Location = new Point(148, 257);
                    break;
                default: pictureToy.Image = Properties.Resources.toy1_BG;
                    picturePet.Location = new Point(148, 255);
                    break;
            }

            //if (AllData1.Toy == 1)
            //{
            //    picturePet.Location = new Point(148, 255);
            //}

            Labels(label1, label2, label3, label4, label5, label6, label7, label8, false);

        }

        int plusValue = 5;
        int minusValue = 15;
        bool isSleeping = false;
        string activity = "nothing";

        bool gameIsWon;

        bool gameIsStarted = false;

        // заново
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            gameIsStarted = true;
            labelPetsName.Text = AllData1.PetsName;

            tick = 0;
            age.Value = 0;
            mood.Value = 100;
            energy.Value = 100;

            pauseCounter = 0;
            паузаToolStripMenuItem.Text = "Пауза";
        }


        // eat
        private void button1_Click(object sender, EventArgs e)
        {
            if (gameIsStarted == true)
            {
                if (energy.Value <= 65)
                {
                    energy.Value += 30;
                    picturePet.Image = Properties.Resources.Happy;
                }
                else if (energy.Value > 65)
                {
                    mood.Value -= minusValue;
                    picturePet.Image = Properties.Resources.AngrySad;
                }
            }
        }


        // play
        private void button2_Click(object sender, EventArgs e)
        {
            if (gameIsStarted == true)
            {
                activity = "play";
                if (mood.Value + 15 <= 95)
                {
                    mood.Value += 15;
                    picturePet.Image = Properties.Resources.HappyRed;

                    isSleeping = false;
                }
                else
                {
                    mood.Value = 100;
                    picturePet.Image = Properties.Resources.AngrySad;

                    mood.Value -= minusValue;
                }

                if (energy.Value >= 15)
                {
                    energy.Value -= minusValue;
                }
                else { }
            }
        }


        // walk
        bool isWalking = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (gameIsStarted == true)
            {
                if (activity == "walk")
                {
                    activity = "nothing";
                }
                else if (activity != "walk")
                {
                    if (energy.Value > 15 && mood.Value < 95)
                    {
                        energy.Value -= 5;
                        mood.Value += plusValue;
                        picturePet.Image = Properties.Resources.HappyWalk;
                        activity = "walk";
                    }
                    else if (energy.Value < 15)
                    {
                        picturePet.Image = Properties.Resources.dead;
                        gameIsStarted = false;
                        activity = "nothing";
                    }
                    else if (mood.Value > 95)
                    {
                        picturePet.Image = Properties.Resources.Happy;
                        isWalking = false;
                        activity = "nothing";
                    }
                }
            }
        }

        // sleep
        private void button3_Click(object sender, EventArgs e)
        {
            if (gameIsStarted == true)
            {
                if (energy.Value < 70)
                {
                    activity = "sleep";
                    picturePet.Image = Properties.Resources.Sleep;
                    isSleeping = true;
                }
                else if (energy.Value > 70)
                {
                    picturePet.Image = Properties.Resources.AngrySad;
                    activity = "nothing";
                    mood.Value -= minusValue;
                }
            }
        }


        int tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameIsStarted == true)
            {
                // Win
                if (AllData1.Level == "quick")
                {
                    tick += 2;
                    age.Value = tick;
                    if (age.Value == 600)
                    {
                        gameIsStarted = false;
                        gameIsWon = true;
                    }
                }
                if (AllData1.Level == "long")
                {
                    tick++;
                    age.Value = tick;
                    if (age.Value == 600)
                    {
                        gameIsStarted = false;
                        gameIsWon = true;
                    }
                }


                if (mood.Value < 5 || energy.Value < 5)
                {
                    gameIsStarted = false; gameIsWon = false;

                    if (mood.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.blue;
                    }
                    else if (energy.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.dead;
                    }
                }


                if (mood.Value >= 5)
                {
                    mood.Value -= 1;
                }
                if (mood.Value < 5)
                {
                    gameIsStarted = false;
                    gameIsWon = false;
                    picturePet.Image = Properties.Resources.blue;
                }
                if (energy.Value >= 5 && activity != "sleep")
                {
                    energy.Value -= 2;
                }
                else if (energy.Value < 3)
                {
                    gameIsStarted = false;
                    gameIsWon = false;
                    picturePet.Image = Properties.Resources.dead;
                }

                if (mood.Value <= minusValue || energy.Value <= minusValue)
                {
                    if (energy.Value > 0 && age.Value > 0 && mood.Value > 0)
                    {
                        picturePet.Image = Properties.Resources.AngrySad;
                    }
                    else if (mood.Value == 0)
                    {
                        picturePet.Image = Properties.Resources.blue;
                        gameIsWon = false;
                    }
                    else if (energy.Value == 0)
                    {
                        picturePet.Image = Properties.Resources.dead;
                        gameIsWon = false;
                    }
                }

                if (activity == "sleep")
                {
                    if (energy.Value < 95)
                        energy.Value += plusValue;

                    if (energy.Value >= 95 && mood.Value >= minusValue)
                    {
                        isSleeping = false;
                        activity = "nothing";
                        picturePet.Image = Properties.Resources.Happy;
                    }
                    else if (mood.Value <= minusValue && mood.Value > 5)
                    {
                        activity = "nothing";
                        picturePet.Image = Properties.Resources.AngrySad;
                    }
                    else if (mood.Value <= 5)
                    {
                        gameIsStarted = false;
                        picturePet.Image = Properties.Resources.blue;
                    }
                }

                if (activity == "walk")
                {
                    picturePet.Image = Properties.Resources.HappyWalk;
                    if (energy.Value > 15 && mood.Value < 95)
                    {
                        energy.Value -= 5;
                        mood.Value += plusValue;
                        picturePet.Image = Properties.Resources.HappyWalk;
                        activity = "walk";
                    }
                    else if (energy.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.dead;
                        gameIsStarted = false;
                        activity = "nothing";
                    }
                    else if (mood.Value > 95)
                    {
                        picturePet.Image = Properties.Resources.Happy;
                        isWalking = false;
                        activity = "nothing";
                    }
                }

                if (activity == "nothing")
                {
                    if (energy.Value < 15 || mood.Value < 15)
                    {
                        picturePet.Image = Properties.Resources.AngrySad;
                    }
                    else if (energy.Value > 15 && mood.Value > 15 && activity == "nothing")
                    {
                        picturePet.Image = Properties.Resources.Happy;
                    }

                    if (mood.Value >= 3)
                    {
                        mood.Value -= 1;
                    }
                    if (mood.Value < 3)
                    {
                        gameIsStarted = false;
                        gameIsWon = false;
                        picturePet.Image = Properties.Resources.blue;
                    }
                    if (energy.Value >= 3 && activity != "sleep")
                    {
                        energy.Value -= 2;
                    }
                    else if (energy.Value < 3)
                    {
                        gameIsStarted = false;
                        gameIsWon = false;
                        picturePet.Image = Properties.Resources.dead;
                    }

                    if (mood.Value <= minusValue || energy.Value <= minusValue)
                    {
                        if (energy.Value > 0 && age.Value > 0 && mood.Value > 0)
                        {
                            picturePet.Image = Properties.Resources.AngrySad;
                        }
                        else if (mood.Value == 0)
                        {
                            picturePet.Image = Properties.Resources.blue;
                            gameIsWon = false;
                        }
                        else if (energy.Value == 0)
                        {
                            picturePet.Image = Properties.Resources.dead;
                            gameIsWon = false;
                        }
                    }
                }

                if (gameIsStarted == false)
                {
                    if (mood.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.blue;
                    }
                    else if (energy.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.dead;
                    }
                }
            }
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        int pauseCounter = 0;
        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pauseCounter++;
            if (pauseCounter % 2 == 0)
            {
                timer1.Enabled = true;
                gameIsStarted = true;
                паузаToolStripMenuItem.Text = "Пауза";
            }
            else if (pauseCounter % 2 != 0 )
            {
                timer1.Enabled = false;
                gameIsStarted = false;
                паузаToolStripMenuItem.Text = "Продолжить";
            }
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {
            tick = 0;
            gameIsStarted = true;
            timer1.Enabled = true;

            age.Value = 0;
            mood.Value = 100;
            energy.Value = 100;
        }

        private void выйтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            AllData1.Close = "close";
        }

        private void ещеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllData1.Close = "hide";
        }


        // ?
        int Qcounter = 0;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Qcounter++;
            if (Qcounter % 2 == 0)
            {
                Labels(label1, label2, label3, label4, label5, label6, label7, label8, false);
            }
            else if (Qcounter % 2 != 0)
            {
                Labels(label1, label2, label3, label4, label5, label6, label7, label8, true);
            }
        }

        static void Labels(System.Windows.Forms.Label label1, System.Windows.Forms.Label label2, 
            System.Windows.Forms.Label label3, System.Windows.Forms.Label label4,
            System.Windows.Forms.Label label5, System.Windows.Forms.Label label6,
            System.Windows.Forms.Label label7, System.Windows.Forms.Label label8,
            bool vis)
        {
            label1.Visible = vis;
            label2.Visible = vis;
            label3.Visible = vis;
            label4.Visible = vis;
            label5.Visible = vis;
            label6.Visible = vis;
            label7.Visible = vis;
            label8.Visible = vis;
        }
    }
}
