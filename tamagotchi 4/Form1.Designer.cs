namespace tamagotchi_4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBG = new System.Windows.Forms.PictureBox();
            this.buttonSound = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBG
            // 
            this.pictureBG.Location = new System.Drawing.Point(0, 0);
            this.pictureBG.Name = "pictureBG";
            this.pictureBG.Size = new System.Drawing.Size(1084, 553);
            this.pictureBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBG.TabIndex = 0;
            this.pictureBG.TabStop = false;
            // 
            // buttonSound
            // 
            this.buttonSound.BackColor = System.Drawing.Color.Transparent;
            this.buttonSound.BackgroundImage = global::tamagotchi_4.Properties.Resources.soundPic;
            this.buttonSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSound.Location = new System.Drawing.Point(1050, 0);
            this.buttonSound.Name = "buttonSound";
            this.buttonSound.Size = new System.Drawing.Size(34, 31);
            this.buttonSound.TabIndex = 1;
            this.buttonSound.UseVisualStyleBackColor = false;
            this.buttonSound.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.buttonSound);
            this.Controls.Add(this.pictureBG);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tamagotchi ♥ ♥ ♥ ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBG;
        private System.Windows.Forms.Button buttonSound;
    }
}

