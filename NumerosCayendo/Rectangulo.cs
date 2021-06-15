using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerosCayendo
{
    public class Rectangulo
    {
        int x;
        int y;
        int largo;
        int alto;
        Color color;

        public Rectangulo(int x, int y, int largo, int alto, Color color)
        {
            this.X = x;
            this.Y = y;
            this.Largo = largo;
            this.Alto = alto;
            this.color = color;
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Largo { get { return largo; } set { largo = value; } }
        public int Alto { get { return alto; } set { alto = value; } }
        public Color Color { get { return color; } set { color = value; } }
    }
}
