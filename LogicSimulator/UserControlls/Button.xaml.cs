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
using System.Windows.Threading;

namespace LogicSimulator
{
    /// <summary>
    /// Interaction logic for Button.xaml
    /// </summary>
    public partial class Button : UserControl, IParts,  IHolder
    {
        public int offsetX { get; }
        public int offsetY { get; }

        public event EventHandler ConectorClicked;
        public List<Part> Outputs { get; set; }
        public List<Part> Inputs { get; set; }
        public Connection connection { get; set; }
        public List<IParts> parts { get; set; }
        public bool power { get; set; }
        public IParts input { get; set; }
        int lastTick = 0;
        public List<Line> lines { get; set; }
        Part Output = new Part(21, 118);
        public Button()
        {
            InitializeComponent();
            Outputs = new List<Part>();
            Inputs = new List<Part>();
            lines = new List<Line>();
            offsetX = 50;
            offsetY = 50;
            parts = new List<IParts>();
          //  Outputs.Add((Part)this);
            Switch = switch1;
            Output.Switch = switch1;
            Output.parts = new List<IParts>();
        }
        public void switch1(bool p, int tick)
        {
            if (lastTick == tick)
            {
                return;
            }
            lastTick = tick;


            foreach (IParts part in parts)
            {
                part.Switch(power, tick);
            }

        
        }


        public Action<bool, int> Switch { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //     ConectorClicked?.Invoke(this, EventArgs.Empty);
            ConectorClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            power = !power;

           // connection.Power = power;


            if (Tlacitko.Background != Brushes.Red)
            {
                Tlacitko.Background = Brushes.Red;
            }
            else
            {
                Tlacitko.ClearValue(Button.BackgroundProperty);
            }



            //bool p = false;
            //foreach (Parts part in connection.Passive)
            //{
            //    p |= part.power;
            //}

            //foreach (Parts part in connection.Passive)
            //{
            //    part.Switch(p);
            //}
        }
    }
}
