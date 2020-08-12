using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LogicSimulator
{
    interface IHolder
    {
        //TranslateTransform tt { get; set; }
        List<Line> lines { get; set; }
        List<Part> Inputs { get; set; }
        List<Part> Outputs { get; set; }
        int offsetX { get; }
        int offsetY { get; }
    }
}
