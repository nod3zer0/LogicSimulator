using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace LogicSimulator
{
    public interface IParts
    {
        Connection connection { get; set; }
        bool power { get; set; }
        //  void Switch(bool power);
        List<Line> lines { get; set; }
        List<IParts> parts { get; set; }
        IParts input { get; set; }
        Action<bool, int> Switch { get; set; }
    }
}
