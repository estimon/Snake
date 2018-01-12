using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Ussimäng
{
    public class Snake
    {
        private Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, lenght;

        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }

        public Snake(Random randSnake)
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Black);
            x = randSnake.Next(0, 40) * 10;
            y = randSnake.Next(0, 40) * 10;
            width = 10;
            lenght = 10;

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, lenght);
                x -= 10;
            }
        }

        public void Snakelocation(Random randSnake)
        {
            x = randSnake.Next(0, 40) * 10;
            y = randSnake.Next(0, 40) * 10;
        }

        public void DrawSnakeColor(Graphics paper)
        {
            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }
        }

        public void DrawSnakemoving()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        public void MoveDown()
        {
            DrawSnakemoving();
            snakeRec[0].Y += 10;
        }

        public void MoveUp()
        {
            DrawSnakemoving();
            snakeRec[0].Y -= 10;
        }

        public void MoveRight()
        {
            DrawSnakemoving();
            snakeRec[0].X += 10;
        }

        public void MoveLeft()
        {
            DrawSnakemoving();
            snakeRec[0].X -= 10;
        }


        public void Grow()
        {
            List<Rectangle> Rec = snakeRec.ToList();
            Rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, lenght));
            snakeRec = Rec.ToArray();
        }

    }
}
