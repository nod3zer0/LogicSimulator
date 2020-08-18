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
            parts = new List<IParts>();
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }
        public IParts parrent { get; set; }
        public Control partControl { get; set; }
        public List<Connector> connectors { get; set; }
        public double offsetX { get; set; }
        public double offsetY { get; set; }
        public Connection connection { get; set; }
        public bool power { get; set; }
        public List<Line> lines { get; set; }
        public ReferenceablePoint linePoint { get; set; }
        public List<IParts> parts { get; set; }
        public List<IParts> InputParts { get; set; }
        public List<Part> Outputs { get; set; }
        public List<Part> Inputs { get; set; }
        public IParts input { get; set; }
        public Action<bool, int> Switch { get; set; }


    }
}
