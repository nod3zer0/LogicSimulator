using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogicSimulator
{
   public class ReferenceablePoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public void SetPoint(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        public void SetPoint(ReferenceablePoint point)
        {
            X = point.X;
            Y = point.Y;
        }
    }
}
