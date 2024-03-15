using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Omarogaili
{
    public class Square : Shape
    {
        public Square(Color color, Point center, int lengthOfTheSide) : base(color, center) 
        {
            this.LengthOfTheSide = lengthOfTheSide;
        }
        public int LengthOfTheSide { get; set; }
        public int PerimeterOfSquare
        {
            get { return LengthOfTheSide * 4; }
        }
        public int AreaOfSquare
        {
            get { return LengthOfTheSide * LengthOfTheSide; }
        }
        public override void Draw(Graphics g)
        {
            var pen = new Pen(Color);
            g.DrawRectangle(
                pen,
                Center.X - (PerimeterOfSquare / 2),
                Center.Y - (PerimeterOfSquare / 2),
                PerimeterOfSquare,
                PerimeterOfSquare
                );
        }
    }
}
