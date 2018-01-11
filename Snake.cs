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
        private int x, y, laius, pikkus;

        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }

        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Green);

            x = 20;
            y = 0;
            laius = 10;
            pikkus = 10;

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, laius, pikkus);
                x -= 10;
            }
        }

        public void drawSnake(Graphics paper)
        {
            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }
        }

        public void drawSnake()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 10;
        }

        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 10;
        }

        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 10;
        }

        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 10;
        }

        public void pikkenda()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, laius, pikkus));
            snakeRec = rec.ToArray();
        }

    }
}
