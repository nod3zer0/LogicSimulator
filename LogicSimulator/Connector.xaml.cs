using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogicSimulator
{
    /// <summary>
    /// Interaction logic for Connector.xaml
    /// </summary>
    public partial class Connector : UserControl, IHolder
    {
        public int offsetX { get; }
        public int offsetY { get; }
        //TranslateTransform tt =
        public List<Line> lines { get; set; }
        public Line line1 { get; set; }
        public Line line2 { get; set; }
        public List<Part> Outputs { get; set; }
        public List<Part> Inputs { get; set; }
        public ReferenceablePoint linePoint { get; set; }

        public Connector()
        {
           
            InitializeComponent();
            Outputs = new List<Part>();
            Inputs = new List<Part>();
            lines = new List<Line>();
            offsetX = 10;
            offsetY = 10;
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
