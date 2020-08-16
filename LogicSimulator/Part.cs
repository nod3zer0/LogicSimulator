using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace LogicSimulator
{
    public class Part : IParts
    {

        public Part(int offsetX, int offsetY)
        {
            lines = new List<Line>();
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }
        public Control partControl { get; set; }
        public double offsetX { get; set; }
        public double offsetY { get; set; }
        public Connection connection { get; set; }
        public bool power { get; set; }
        public List<Line> lines { get; set; }
        public ReferenceablePoint linePoint { get; set; }
        public List<IParts> parts { get; set; }
        public IParts input { get; set; }
        public Action<bool, int> Switch { get; set; }


    }
}
