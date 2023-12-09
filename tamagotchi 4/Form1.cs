using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tamagotchi_4
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
        }

        string level = "quick";
        int toy = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            level = "quick";

            Button buttonStart = new Button();
            Button buttonRules = new Button();
            Button buttonCode = new Button();
            ButtonsInfo(buttonRules, 330, 300, Color.DeepPink, "Правила", 150, 30, 12, FlatStyle.Popup);
            ButtonsInfo(buttonStart, 330, 250, Color.YellowGreen, "Начать игру", 150, 50, 12, FlatStyle.Flat);

            ButtonsInfo(buttonCode, 330, 325, Color.DeepPink, "Код", 150, 30, 12, FlatStyle.Popup);

            pictureBG.Image = Properties.Resources.BG1;
            this.Controls.Add(buttonStart);
            this.Controls.Add(buttonRules);
            this.Controls.Add(buttonCode);
            this.Controls.Add(pictureBG);

            // BG2 Visible 
            // quick and long game choice
            Button buttonQ = new Button();
            Button buttonL = new Button();

            // Tamagotchi
            Button buttonT1 = new Button();
            Button buttonT2 = new Button();
            Button buttonT3 = new Button();

            // next
            Button buttonNext = new Button();

            // Pets name textbox
            TextBox textPetsName = new TextBox();

            //---- All buttons info -----
            ButtonsInfo(buttonQ, 520, 100, Color.MediumBlue, "Быстрая", 80, 25, 9, FlatStyle.Flat);
            ButtonsInfo(buttonL, 620, 100, Color.MediumPurple, "Долгая", 80, 25, 9, FlatStyle.Flat);

            ButtonsInfo(buttonT1, 520, 220, Color.MediumBlue, "1", 60, 20, 7, FlatStyle.Flat);
            ButtonsInfo(buttonT2, 600, 220, Color.MediumPurple, "2", 60, 20, 7, FlatStyle.Flat);
            ButtonsInfo(buttonT3, 680, 220, Color.MediumPurple, "3", 60, 20, 7, FlatStyle.Flat);

            ButtonsInfo(buttonNext, 700, 400, Color.YellowGreen, "Далее", 80, 25, 9, FlatStyle.Flat);

            textPetsName.Location = new Point(520, 360);
            textPetsName.Width = 220;


            //---- PictureBoxes -----
            PictureBox pictureT = new PictureBox();
            PictureBoxInfo(pictureT, 310, 160, 150, 100, Properties.Resources.toy1_BG);

            // label 
            Label labelw = new Label();
            labelw.ForeColor = Color.Red;
            labelw.Location = new Point(470, 385);
            labelw.BackColor = Color.Black;
            labelw.AutoSize = true;

            buttonStart.Click += (s, ev) =>
            {
                pictureBG.Image = Properties.Resources.BG2;
                ButtonsVis(buttonStart, false, false);
                ButtonsVis(buttonRules, false, false);
                ButtonsVis(buttonCode, false, false);

                ButtonAdd(buttonQ);
                ButtonAdd(buttonL);
                ButtonAdd(buttonT1);
                ButtonAdd(buttonT2);
                ButtonAdd(buttonT3);
                ButtonAdd(buttonNext);

                this.Controls.Add(textPetsName);
                textPetsName.BringToFront();

                Controls.Add(pictureT);
                pictureT.BringToFront();
            };

            buttonRules.Click += (s, ev) =>
            {
                string filePath = "Правила.txt";
                Process.Start(filePath);
            };

            buttonCode.Click += (s, ev) =>
            {
                string filePath = "Код игры.txt";
                Process.Start(filePath);
            };

                buttonQ.Click += (s, ev) =>
            {
                buttonL.BackColor = Color.MediumPurple;
                buttonQ.BackColor = Color.MediumBlue;
                level = "quick";
            };
            buttonL.Click += (s, ev) =>
            {
                buttonL.BackColor = Color.MediumBlue;
                buttonQ.BackColor = Color.MediumPurple;
                level = "long";
            };

            buttonT1.Click += (s, ev) =>
            {
                buttonT1.BackColor = Color.MediumBlue;
                buttonT2.BackColor = Color.MediumPurple;
                buttonT3.BackColor = Color.MediumPurple;
                toy = 1;
                pictureT.BackgroundImage = Properties.Resources.toy1_BG;
            };
            buttonT2.Click += (s, ev) =>
            {
                buttonT2.BackColor = Color.MediumBlue;
                buttonT1.BackColor = Color.MediumPurple;
                buttonT3.BackColor = Color.MediumPurple;
                toy = 2;
                pictureT.BackgroundImage = Properties.Resources.toy2_BG;
            };
            buttonT3.Click += (s, ev) =>
            {
                buttonT3.BackColor = Color.MediumBlue;
                buttonT2.BackColor = Color.MediumPurple;
                buttonT1.BackColor = Color.MediumPurple;
                toy = 3;
                pictureT.BackgroundImage = Properties.Resources.toy3_BG;
            };

            buttonNext.Click += (s, ev) =>
            {
                if (textPetsName.Text.Length > 3 && textPetsName.Text.Length < 10)
                {
                    AllData1.Level = level;
                    AllData1.Toy = toy;
                    AllData1.PetsName = textPetsName.Text;

                    this.Hide();
                    form2.ShowDialog();
                    if (AllData1.Close == "close")
                    {
                        this.Close();
                    }
                    else if (AllData1.Close == "hide")
                    {
                        this.Show();
                    }
                }
                else
                {
                    Controls.Add(labelw);
                    labelw.BringToFront();
                    labelw.Text = "имя должно содержать больше 3 и меньше 10 символов";

                }
            };
        }


        public void ButtonsInfo(Button button, int x, int y, Color color, String text, int width, int height, int fsize, FlatStyle style)
        {
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.Text = text;
            button.BackColor = color;
            button.Font = new Font("Orbitron", fsize, FontStyle.Bold);
            button.FlatStyle = style;
            button.Visible = true;
            button.Enabled = true;
        }

        public void ButtonsVis(Button button, bool visible, bool enabled)
        {
            button.Visible = visible;
            button.Enabled = enabled;
        }

        public void ButtonAdd(Button button)
        {
            this.Controls.Add(button);
            button.BringToFront();
        }

        private void PictureBoxInfo(PictureBox pictureBox, int x, int y, int width, int height, Image image)
        {
            pictureBox.Location = new Point(x, y);
            pictureBox.Size = new Size(width, height);
            pictureBox.BackgroundImage = image;
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
