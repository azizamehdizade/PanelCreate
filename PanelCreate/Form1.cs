using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace PanelCreate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Users\ezize\OneDrive\İş masası\images\bomba.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        Random r = new Random();
        Random g = new Random();
        Random b = new Random();

        Random xL = new Random();
        Random yL = new Random();
        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            Panel p = new Panel();
            p.Size = new Size(60, 60);
            p.Tag = "oyun";
            p.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));
            p.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
            this.Controls.Add(p);
            pictureBox1.BringToFront();
            label2.Text = count.ToString();

            Toqqusma();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));

            Toqqusma();
        }

        private void Toqqusma()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Tag == "oyun")
                {
                    if (c.Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        SoundPlayer ses = new SoundPlayer(@"C:\Users\ezize\OneDrive\İş masası\images\explosion.wav");
                        ses.Play();

                        DialogResult cavab = MessageBox.Show("Oyun bitdi! Yeni oyun başlasın?", "Oyun bitdi", MessageBoxButtons.OK);

                        if (cavab == DialogResult.OK)
                        {
                            YeniOyun();
                        }
                        break;
                    }
                }
            }
        }

        private void YeniOyun()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Panel && this.Controls[i].Tag == "oyun")
                {
                    this.Controls.Remove(this.Controls[i]);
                }
            }

            count = 0;
            label2.Text = "0";
            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
        }
    }
}