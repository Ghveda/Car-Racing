using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class Form1 : Form
    {
        int coinsInLabel = 0;
        int highspeed = 0;
        Random r = new Random();
        int x;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(highspeed);
            enemy(highspeed);
            gameOver();
            coins(highspeed);
            coinCounterLabel();
        }
        void enemy(int speed)
        {
            if (pictureBox9.Top >= 500)
            {
                x = r.Next(0, 350);
                if (pictureBox9.Bounds != pictureBox11.Bounds && pictureBox9.Bounds != pictureBox13.Bounds)
                {
                    pictureBox9.Location = new Point(x, 0);
                }
            }
            else
            {
                pictureBox9.Top += speed;
            }

            if (pictureBox11.Top >= 500)
            {
                x = r.Next(0, 350);
                if (pictureBox9.Bounds != pictureBox11.Bounds && pictureBox9.Bounds != pictureBox13.Bounds)
                {
                    pictureBox11.Location = new Point(x, 0);
                }
            }
            else
            {
                pictureBox11.Top += speed;
            }

            if (pictureBox13.Top >= 500)
            {
                x = r.Next(0, 350);
                if (pictureBox9.Bounds != pictureBox11.Bounds && pictureBox9.Bounds != pictureBox13.Bounds)
                {
                    pictureBox13.Location = new Point(x, 0);
                }
            }
            else
            {
                pictureBox13.Top += speed;
            }
        }
        void moveLine(int speed)
        {
            pictureBox1.Top += speed;
            pictureBox2.Top += speed;
            pictureBox3.Top += speed;
            pictureBox4.Top += speed;
            pictureBox5.Top += speed;

            if (pictureBox5.Top >= 500)
            {
                pictureBox5.Top = 0;
            }
            else
            {
                pictureBox5.Top += speed;
            }
            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }
            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }
            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }
            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }
        }

        private void pictureBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (mineCar.Left > 0)
                {
                    mineCar.Left += -8;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (mineCar.Right < 390)
                {
                    mineCar.Left += 8;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (highspeed < 21)
                {
                    highspeed++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (highspeed > 0)
                {
                    highspeed--;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            over.Visible = false;
        }
        void gameOver()
        {
            if (mineCar.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
            if (mineCar.Bounds.IntersectsWith(pictureBox11.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
            if (mineCar.Bounds.IntersectsWith(pictureBox13.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
            }
        }
        void coins(int speed)
        {
            if (Coin1.Top >= 500)
            {
                x = r.Next(0, 350);
                if (Coin1.Bounds != Coin2.Bounds && Coin1.Bounds != Coin3.Bounds)
                {
                    Coin1.Location = new Point(x, 0);
                }
            }
            else
            {
                Coin1.Top += speed;
            }

            if (Coin2.Top >= 500)
            {
                x = r.Next(0, 350);
                if (Coin2.Bounds != Coin1.Bounds && Coin2.Bounds != Coin3.Bounds)
                {
                    Coin2.Location = new Point(x, 0);
                }
            }
            else
            {
                Coin2.Top += speed;
            }

            if (Coin3.Top >= 500)
            {
                x = r.Next(0, 350);
                if (Coin3.Bounds != Coin1.Bounds && Coin3.Bounds != Coin2.Bounds)
                {
                    Coin3.Location = new Point(x, 0);
                }
            }
            else
            {
                Coin3.Top += speed;
            }

        }
        void coinCounterLabel()
        {
            x = r.Next(0, 350);
            if (mineCar.Bounds.IntersectsWith(Coin1.Bounds))
            {
                coinsInLabel++;
                CoinCounter.Text = "Coins = " + coinsInLabel.ToString();
                Coin1.Location = new Point(x, 0);

            }
            if (mineCar.Bounds.IntersectsWith(Coin2.Bounds))
            {
                coinsInLabel++;
                CoinCounter.Text = "Coins = " + coinsInLabel.ToString();
                Coin2.Location = new Point(x, 0);

            }
            if (mineCar.Bounds.IntersectsWith(Coin3.Bounds))
            {
                coinsInLabel++;
                CoinCounter.Text = "Coins = " + coinsInLabel.ToString();
                Coin3.Location = new Point(x, 0);

            }
        }
    }
}
