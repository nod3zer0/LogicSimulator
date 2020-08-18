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
    /// Interaction logic for LightBulb.xaml
    /// </summary>
    public partial class LightBulb : UserControl, IParts, IHolder
    {
        public double offsetX { get; }
        public double offsetY { get; }
        public List<Connector> connectors { get; set; }
        public ReferenceablePoint linePoint { get; set; }
        public event EventHandler ConectorClicked;
        public Connection connection { get; set; }
        public bool power { get; set; }
        public List<Part> Outputs { get; set; }
        public List<Part> Inputs { get; set; }
        public List<IParts> parts { get; set; }
        public IParts input { get; set; }
        int lastTick = 0;
        bool move = false;
        public List<Line> lines { get; set; }
        public LightBulb()
        {
            InitializeComponent();
            lines = new List<Line>();
            Outputs = new List<Part>();
            Inputs = new List<Part>();
            Inputs.Add(Input1);
            Input1.parrent = this;
            connectors = new List<Connector>();
            Input1.lines = new List<Line>();
            Input1.Switch = switch1;

            offsetX = this.Width / 2;
            offsetY = this.Height / 2;
            Input1.offsetX = InputCB.Margin.Top + InputCB.Height / 2;
            Input1.offsetY = InputCB.Margin.Left + InputCB.Width / 2;
            Switch = switch1;
        }
        Part Input1 = new Part(50, 50);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConectorClicked?.Invoke(Input1, EventArgs.Empty);
        }
        public Action<bool, int> Switch { get; set; }

        public void switch1(bool power, int tick)
        {




            if (lastTick == tick)
            {
                return;
            }
            lastTick = tick;
            if (power)
            {
                Bulb.Fill = Brushes.Red;
            }
            else
            {
                Bulb.Fill = Brushes.White;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            move = true;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            //if (move)
            //{

            //    var tt = new TranslateTransform();

            //    this.RenderTransform = tt;
            //    tt.X = Mouse.GetPosition((UIElement)sender).X;
            //    tt.Y = Mouse.GetPosition((UIElement)sender).Y;

            //}
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            move = false;
        }
    }
}
