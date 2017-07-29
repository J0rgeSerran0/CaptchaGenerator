namespace WindowsCaptchaGeneratorDemo
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new CaptchaGenerator.Builder();

                var captchaProperties = new CaptchaGenerator.CaptchaProperties()
                    .Configure
                    .WithBackgroundColor(Color.White)
                    .WithCharacters(6)
                    .WithColorDownUpLine(Color.Gray)
                    .WithColorUpDownLine(Color.Gray)
                    .WithDownUpLine(true)
                    .WithUpDownLine(true)
                    .WithRandomCharacters(CaptchaGenerator.RandomCharactersType.All)
                    .WithSizeDownUpLine(2)
                    .WithSizeUpDownLine(2)
                    .WithFont(new Font("Segoe UI", 24, FontStyle.Strikeout))
                    .WithFontColor(Color.DarkSlateGray)
                    .Get();

                // ****************************************************************
                // Basic call to generate a captcha with CaptchaGenerator
                // ****************************************************************
                //var captchaProperties = new CaptchaGenerator.CaptchaProperties()
                //    .Configure
                //    .Get();
                // ****************************************************************

                var response = builder.CreateImage(captchaProperties);

                this.pictureBox1.Image = response.Item1;
                this.label1.Text = response.Item2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}