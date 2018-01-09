using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Ussimäng
{
    public class Söök
    {
        private int x, y, laius, pikkus;
        private SolidBrush brush;
        public Rectangle foodRec;


        public Söök(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(0, 29) * 10;

            brush = new SolidBrush(Color.Red);

            laius = 10;
            pikkus = 10;

            foodRec = new Rectangle(x, y, laius, pikkus);
        }

        public void foodLocation(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(0, 29) * 10;
        }

        public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;

            paper.FillRectangle(brush, foodRec);
        }
    }
}
