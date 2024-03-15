using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Omarogaili
{
    public class Triangle: Shape
    {
        public Triangle(Color color, Point center, float a, float b, float theBaseOfTheTriangle): base (color, center) 
        {
            this.A = a;
            this.B= b;
            this.TheBaseOfTheTriangle = theBaseOfTheTriangle;
        }
        public float A { get; set; }
        public float B { get; set; }
        public float TheBaseOfTheTriangle { get; set; }
        public float PerimeterOfTriangle
        {
            get
            {
                return A+B+TheBaseOfTheTriangle;
            }
        }
        public float semiPerimter
        {
            get
            {
                return PerimeterOfTriangle / 2;
            }
        }
        public double area
        {
            get
            {
                return Math.Sqrt(semiPerimter*
                    (semiPerimter-A)* 
                    (semiPerimter-B)*
                    (semiPerimter -TheBaseOfTheTriangle));
            }
        }
        public override void Draw(Graphics g)
        {
            var pen = new Pen(Color);
            //jag tänker att jag måla först tre kanterna som vi har i en treiangle genom att använda point 
            //så jag säger hur ska center.x och y ska vara i förhållande för base of the tringale och A sidan.
            //sedan tänker jag att skapa en array för dessa tre kanter och målar den array med hjälp av DrawPolygon. 
            var point1 = new Point(Center.X, Center.Y - (int)TheBaseOfTheTriangle / 2);
            var point2 = new Point(Center.X - (int)A / 2, Center.Y + (int)TheBaseOfTheTriangle / 2);
            var point3 = new Point(Center.X + (int)A / 2, Center.Y + (int)TheBaseOfTheTriangle / 2);
            Point[] trianglePoints = { point1, point2, point3 };
            g.DrawPolygon(pen, trianglePoints);
        }

    }
}
