using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes_Omarogaili
{
    public abstract class Shape
    {
       /* an abstract class 
        * all the shapes we'll have should have those two properties Colors and centers
        * and Draw method is also an abstract so all the shapes'll have thís method to draw them 
        */
        Color color;
        Point center;
        public Shape (Color color, Point center)
        {
            this.Color = color;
            this.Center = center;
        }
        public Color Color
        {
            get; set;
        }
        public Point Center
        {
            get;
            set;
        }

        public abstract void Draw(Graphics g);
    }
}
