using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

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
        public int offsetX { get; }
        public int offsetY { get; }
        public Connection connection { get; set; }
        public bool power { get; set; }
        public List<Line> lines { get; set; }
        public List<IParts> parts { get; set; }
        public IParts input { get; set; }
        public Action<bool, int> Switch { get; set; }


    }
}
