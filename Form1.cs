using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form

    {
        Bitmap background;
        Bitmap snow;
        private readonly IList<Snowflake> snowflakes;
        
   
        int speed = 0;
        int n = 0;
        private readonly Timer timer;
        public Form1()
        {
            InitializeComponent();
            snowflakes = new List<Snowflake>();
            background = new Bitmap(Properties.Resources.fon);
            snow = new Bitmap(Properties.Resources.snow);
           AddSnowFlakes();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (var SnowFlake in snowflakes)
            {
                SnowFlake.Y += SnowFlake.size;
             
                if (SnowFlake.Y > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    SnowFlake.Y = -SnowFlake.size;
                }
                if (SnowFlake.Y > 0)
                {
                    Dr();
                }
            }
            timer.Start();
        }
    
        private void AddSnowFlakes()
        {
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                snowflakes.Add(new Snowflake
                {
                    X = rnd.Next(Screen.PrimaryScreen.WorkingArea.Width),
                    Y = rnd.Next(Screen.PrimaryScreen.WorkingArea.Height),
                    size = rnd.Next(5, 15)
                });
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            
                Dr();
            
        }
        private void Dr()
        {
            var scene = new Bitmap(background,
                ClientRectangle.Width,
                ClientRectangle.Height);
            var gr = Graphics.FromImage(scene);
            foreach (var snowflake in snowflakes)
            {
                if (snowflake.Y > 0)
                {
                    gr.DrawImage(snow, new Rectangle(
                        snowflake.X,
                        snowflake.Y,
                        snowflake.size,
                        snowflake.size));
                }
            }
            var g = this.CreateGraphics();
            g.DrawImage(scene, 0, 0);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
                if (n == 0)
                {
                    timer.Start();
                    n++;
                }
                else if (n == 1)
                {
                    timer.Stop();
                    n = 0;
                }
            }
        }
    }

