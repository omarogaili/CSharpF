using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Omarogaili
{
    public class Circle : Shape
    {
        private int radie;
        public Circle(Color color, Point center, int radie) : base(color, center) 
        {
            this.Radie = radie;
        }
        public int Radie
        {
            get;
            set;
        }
        public int Diameter
        {
            get
            {
                return radie * 2;
            }
        }
        public double Circumference
        {
            get
            {
                return radie * Math.PI *2;
            }
        }
        public double Area
        {
            get
            {
                return radie* radie * Math.PI *2;
            }
        }
        public override void Draw(Graphics g)
        {
            var pen = new Pen(Color);
            g.DrawEllipse(
                pen,
                Center.X - Radie,
                Center.Y - Radie,
                Radie,
                Radie
                );
        }
    }
}
