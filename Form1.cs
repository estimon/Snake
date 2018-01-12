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
        public void StartGame()
        {
            food = new Food(randFood);
            snake = new Snake(randSnake);

        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.Media.SoundPlayer player2 = new System.Media.SoundPlayer();
        System.Media.SoundPlayer player3 = new System.Media.SoundPlayer();
        Random randFood = new Random();
        Random randSnake = new Random();
        Snake snake;
        Graphics paper;  
        Food food;
        
        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;
        int score = 0;
        

        public Form1()
        {
            player.SoundLocation = "sswav.wav";
            player2.SoundLocation = "untitled.wav";
            InitializeComponent();
            food = new Food(randFood);
            snake = new Snake(randSnake);
            
            {
                Backroundmusic();
            }
        }
        public void Backroundmusic()
        {
            player.Play();
            player.PlayLooping();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            snake.Snakelocation(randSnake);
            paper = e.Graphics;
            food.Drawfood(paper);
            snake.DrawSnakeColor(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyData == Keys.Space && right == false)
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            ussLable.Text = Convert.ToString(score);
            if (down) { snake.MoveDown(); }
            if (up) { snake.MoveUp(); }
            if (right) { snake.MoveRight(); }
            if (left) { snake.MoveLeft(); }
            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodruut))
                {
                    score += 10;
                    snake.Grow();
                    food.FoodLocation(randFood);
                }
            }
            Death();            
            Invalidate();   
        }

        public void Death()
        {
            
            using (StreamReader sr = new StreamReader("Skoor.txt"))
                Highscore.Text = sr.ReadLine();
            if (Convert.ToInt32(File.ReadAllText("Skoor.txt")) < Convert.ToInt32(score))
            {
                StreamWriter scorefile = new StreamWriter("Skoor.txt");
                scorefile.Write(score);
                scorefile.Close();
                scorefile.Dispose();
                using (StreamReader sr = new StreamReader("Skoor.txt"))
                    Highscore.Text = sr.ReadLine();
            }


            snake.Snakelocation(randSnake);
            for (int i = 1; i < snake.SnakeRec.Length; i++)
                {
                    if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                    {
                    
                    food.FoodLocation(randFood);
                    Restart();
                    }
                }


            if(snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 490)
            {
                
                food.FoodLocation(randFood);
                
                Restart();
            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 495)
            {
                
                food.FoodLocation(randFood);
                Restart();               
            }
        }

        public void Restart()
        {
            
            player2.Play();           
            timer1.Enabled = false;
            MessageBox.Show("GAME OVER! Your score was: " + score );
            ussLable.Text = "0";
            score = 0;
            tühikLable.Text = "Press SPACE to continue!";
            {
                Backroundmusic();
            }
            {
                StartGame();
            }
            Invalidate();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
