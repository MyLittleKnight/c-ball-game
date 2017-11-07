using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        int speed = 3;
        int slide_speed = 10;
        int vdir = +1;
        bool game_ower = false;
        private void vert_Tick(object sender, EventArgs e)
        {
             if(ball.Top < 0)
             {
                 vdir = 1;
             }
             else if(ball.Top > (this.Height - ball.Height -slide.Height))
             {
                 //lets add game logic
                 if(ball.Left < slide.Left || (ball.Left+ball.Width)>(slide.Left + slide.Width))
                 {
                     vert.Enabled = horz.Enabled = false;
                     MessageBox.Show("Hadeee oldumu şimdi!!!");
                 }




                 vdir = -1;
             }
            
                 ball.Top += (speed*vdir);

             
        }

        int hdir = +1;
        private void horz_Tick(object sender, EventArgs e)
        {
            if (ball.Left < 0)
            {
                hdir = +1;
            }
            else if (ball.Left > (this.Width - ball.Width))
            {
                hdir = -1;
            }
            
            ball.Left += (speed*hdir);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

       //for slider movement.
        bool _left  = false;
        bool _right = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //active 
            if (e.KeyCode == Keys.Right)
            {
                _right = true;
            }
            else if(e.KeyCode == Keys.Left)
            {
                _left = true;
            }
            else if(e.KeyCode == Keys.Space)
            {
                //pause game
                vert.Enabled = horz.Enabled = false;
                panel1.Visible = true;
            }
            else if (e.KeyCode == Keys.Enter && vert.Enabled== false)
            {
                vert.Enabled = horz.Enabled = true;
                panel1.Visible = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //inactive
            if(e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                _left = false; 
                _right = false;//disable all
            }
        }

        private void keyWatch_Tick(object sender, EventArgs e)
        {
            if(_right && slide.Left < (this.Width-slide.Width))
            {
                slide.Left += 10; 
            }
            else if ( _left  && slide.Left > 0)
            {
                slide.Left -= 10;
            }
        }

    }
}
