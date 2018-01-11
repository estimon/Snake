using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ussimäng
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.Media.SoundPlayer player2 = new System.Media.SoundPlayer();
        System.Media.SoundPlayer player3 = new System.Media.SoundPlayer();
        Random randFood = new Random();
        Graphics paper;
        Snake snake = new Snake();
        Söök food;
        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;
        int score = 0;

        public Form1()
        {
            player.SoundLocation = "sswav.wav";
            player2.SoundLocation = "untitled.wav";
            player3.SoundLocation = "söömine.wav";
            InitializeComponent();
            food = new Söök(randFood);
            {
                algusmuusika();
            }
        }
        public void algusmuusika()
        {
            player.Play();
            player.PlayLooping();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawSnake(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                tühikLable.Text = "";
                down = false;
                up = false;
                right = false;
                left = false;
            }        

            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            ussLable.Text = Convert.ToString(score);
            if (down) { snake.moveDown(); }
            if (up) { snake.moveUp(); }
            if (right) { snake.moveRight(); }
            if (left) { snake.moveLeft(); }
            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    score += 10;
                    snake.pikkenda();
                    food.foodLocation(randFood);
                }
            }
            pauk();            
            Invalidate();   
        }

        public void pauk()
        {        
            for (int i = 1; i < snake.SnakeRec.Length; i++)
            {                
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    food.foodLocation(randFood);
                    restart();
                }
            }

            if(snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 493)
            {
                food.foodLocation(randFood);
                restart();
            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 490)
            {
                food.foodLocation(randFood);
                restart();               
            }
        }

        public void restart()
        {
            player2.Play();           
            timer1.Enabled = false;
            MessageBox.Show("Mäng läbi! Sinu skoor oli: " + score );
            System.IO.StreamReader sr = new System.IO.StreamReader("Skoor.txt");
            if (Convert.ToInt32(sr.ReadLine()) < Convert.ToInt32(ussLable.Text)) 
            {               
                sr.Close();
                using (System.IO.StreamWriter sw = new StreamWriter("Skoor.txt", false))
                    sw.WriteLine(ussLable.Text);
            }
            
            ussLable.Text = "0";
            score = 0;
            tühikLable.Text = "Vajuta tühikut, et alsutada";
            {
                algusmuusika();
            }
            snake = new Snake();
            Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void highscoreToolStripMenuItem_Click(object sender, EventArgs e)
        {           
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
        }

        private void toolStripStatusLabel3_EnabledChanged(object sender, EventArgs e)
        {          
        }

        private void Highscore_Click(object sender, EventArgs e)
        {
        }
    }
}
