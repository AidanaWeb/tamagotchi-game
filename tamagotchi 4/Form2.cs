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
using Label = System.Windows.Forms.Label;
using System.Media;
using System.Net.Http.Headers;
using WMPLib;
using AxWMPLib;

namespace tamagotchi_4
{
    public partial class Form2 : Form
    {
        WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form2_FormClosing;

            player1.URL = "bgMusic1.wav";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            timer1.Enabled = true;
            timer2.Enabled = true;
            gameIsStarted = true;
            labelPetsName.Text = AllData1.PetsName;

            tick = 0;
            age.Value = 0;
            mood.Value = 100;
            energy.Value = 100;

            // Toy tamagotchi
            switch (AllData1.Toy)
            {
                case 1:
                    pictureToy.Image = Properties.Resources.toy1_BG;
                    picturePet.Location = new Point(148, 255);
                    break;
                case 2:
                    pictureToy.Image = Properties.Resources.toy2_BG;
                    picturePet.Location = new Point(148, 250);
                    break;
                case 3:
                    pictureToy.Image = Properties.Resources.toy3_BG;
                    picturePet.Location = new Point(148, 257);
                    break;
                default:
                    pictureToy.Image = Properties.Resources.toy1_BG;
                    picturePet.Location = new Point(148, 255);
                    break;
            }

            Labels(label1, label2, label3, label4, label5, label6, label7, label8, false);

            textBox1.Visible = false;
            textBox1.Enabled = false;
            buttonCheat.Visible = false;
            buttonCheat.Enabled = false;

            pictureEnd.Visible = false;

            picturePet.Image = Properties.Resources.Happy;

            // Music
            //PlayMusic("bgMusic.wav");
            //Player.URL = "bgMusic.wav";


            //Player.URL = "bgMusic.wav";

            //Player.Location = new Point(90, 410);
            //Player.Height = 34;


            player1.controls.play();


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

            textBox1.Visible = false;
            textBox1.Enabled = false;
            buttonCheat.Visible = false;
            buttonCheat.Enabled = false;

            pictureEnd.Visible = false;


            // Background image back
            BackgroundImage = Properties.Resources.Background1;
            menuStrip1.BackColor = Color.Indigo;
            picturePet.Image = Properties.Resources.Happy;
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

        int musictick = 0;
        int tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelAge.Text = Convert.ToString(Math.Round(age.Value * 0.025));
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
                        timer1.Enabled = false;

                        PictureEnd(pictureEnd, Properties.Resources.WinGif);
                    }
                }
                if (AllData1.Level == "long")
                {
                    tick += 1;
                    age.Value = tick;
                    if (age.Value == 600)
                    {
                        gameIsStarted = false;
                        gameIsWon = true;
                        timer1.Enabled = false;

                        PictureEnd(pictureEnd, Properties.Resources.WinGif);
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
                            timer1.Enabled = false;
                        }
                        else if (energy.Value == 0)
                        {
                            picturePet.Image = Properties.Resources.dead;
                            gameIsWon = false;
                            timer1.Enabled = false;
                        }
                    }
                }



                // End of the game
                if (gameIsStarted == false)
                {
                    if (mood.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.blue;
                        timer1.Enabled = false;

                        // pictureEnd
                        PictureEnd(pictureEnd, Properties.Resources.GoneGif);
                        pictureEnd.Visible = true;
                    }
                    else if (energy.Value < 5)
                    {
                        picturePet.Image = Properties.Resources.dead;
                        timer1.Enabled = false;

                        // pictureEnd
                        PictureEnd(pictureEnd, Properties.Resources.DeadGif);
                        pictureEnd.Visible = true;
                    }
                    else if (age.Value == 600)
                    {
                        gameIsWon = true;
                        timer1.Enabled = false;

                        // pictureEnd
                        PictureEnd(pictureEnd, Properties.Resources.WinGif);
                        pictureEnd.Visible = true;
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
            if (gameIsStarted == true)
            {
                pauseCounter++;
                if (pauseCounter % 2 == 0)
                {
                    timer1.Enabled = true;
                    gameIsStarted = true;
                    паузаToolStripMenuItem.Text = "Пауза";
                }
                else if (pauseCounter % 2 != 0)
                {
                    timer1.Enabled = false;
                    //gameIsStarted = false;
                    паузаToolStripMenuItem.Text = "Продолжить";
                }
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
            pauseCounter = 0;
            паузаToolStripMenuItem.Text = "пауза";
            musicCounter = 0;

            this.Close();
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

        int musicCounter = 0;
        private void музыкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicCounter++;
            if (musicCounter % 2 == 0)
            {
                player1.controls.play();
                музыкаToolStripMenuItem.Image = Properties.Resources.soundPic;
            }
            else if (musicCounter % 2 != 0)
            {
                player1.controls.pause();
                музыкаToolStripMenuItem.Image = Properties.Resources.nosoundPic;
            }
        }


        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Y)
            {
                textBox1.Visible = true;
                textBox1.Enabled = true;
                buttonCheat.Visible = true;
                buttonCheat.Enabled = true;
            }
            else if (e.KeyCode == Keys.U)
            {
                textBox1.Visible = false;
                textBox1.Enabled = false;
                buttonCheat.Visible = false;
                buttonCheat.Enabled = false;
            }
        }

        private void buttonCheat_Click(object sender, EventArgs e)
        {
            switch (textBox1.Text)
            {
                case "age++":
                    age.Value = 600;
                    break;
                case "mood--":
                    mood.Value = 0;
                    break;
                case "energy--":
                    energy.Value = 0;
                    break;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "age++")
                {
                    age.Value = 598;
                    tick = 598;
                    //timer1.Enabled = false;
                    gameIsWon = true;
                    gameIsStarted = false;
                }
                else if (textBox1.Text == "mood--")
                {
                    mood.Value = 3;
                }
                else if (textBox1.Text == "energy--")
                {
                    energy.Value = 3;
                }

            }
        }









        private void отключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void включитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Закрывается пользователем (крестик)
                AllData1.Close = "close";
            }
        }


        private void PictureBoxInfo(PictureBox pictureBox, int x, int y, int width, int height, Image image)
        {
            pictureBox.Location = new Point(x, y);
            pictureBox.Size = new Size(width, height);
            pictureBox.BackgroundImage = image;
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void PictureEnd(PictureBox pictureBox, Image image)
        {
            pictureBox.Visible = true;
            pictureBox.Width = this.Width;
            pictureBox.Height = this.Height;
            pictureBox.Image = image;
            pictureBox.Location = new Point(0, 20);
            BackgroundImage = Properties.Resources.WinGif;
            menuStrip1.BackColor = Color.Black;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            musictick += 1;
            // music loop
            if (musictick % 170 == 0)
            {
                player1.controls.stop();
                player1.controls.play();
            }
        }
    }
}
