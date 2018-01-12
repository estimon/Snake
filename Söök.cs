using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Ussimäng
{
    public class Food
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle foodruut;
        

        public Food(Random randFood)
        {
            
            brush = new SolidBrush(Color.Red);
            width = 10;
            height = 10;
            x = randFood.Next(0, 42) * 10;
            y = randFood.Next(0, 41) * 10;
            foodruut = new Rectangle(x, y, width, height);
        }

        public void FoodLocation(Random randFood)
        {
            x = randFood.Next(0, 42) * 10;
            y = randFood.Next(0, 41) * 10;
        }

        public void Drawfood(Graphics paper)
        {
            foodruut.X = x;
            foodruut.Y = y;
            paper.FillRectangle(brush, foodruut);
        }
    }
}
