using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        public Point location { get; private set; }

        public void Createfood()
        {
            Random rnd = new Random();
            location = new Point(rnd.Next(0,27), rnd.Next(0, 27));
        }
    }
}
