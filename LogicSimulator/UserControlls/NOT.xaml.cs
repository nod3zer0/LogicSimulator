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
    /// Interaction logic for NOT.xaml
    /// </summary>
    public partial class NOT : UserControl, IHolder
    {
        public int offsetX { get; }
        public int offsetY { get; }
        public ReferenceablePoint linePoint { get; set; }
        public List<Part> Outputs { get; set; }
        public List<Part> Inputs { get; set; }
        public List<Line> lines {get;set; }
        public NOT()
        {
            InitializeComponent();
            Outputs = new List<Part>();
            Inputs = new List<Part>();
            lines = new List<Line>();
            offsetX = 50;
            offsetY = 50;
            Input2.Switch = Switch;
            Output.parts = new List<IParts>();
            Inputs.Add(Input2);
            Outputs.Add(Output);
        }

        public List<IParts> parts { get; set; }
     
        Part Input2 = new Part(10, 10);
        Part Output = new Part(10,100);
        public IParts input { get; set; }

        public event EventHandler InputClicked;
        public event EventHandler OutputClicked;

        public Connection connection { get; set; }
        bool all = false;
        int lastTick = 0;
        public void Switch(bool power, int tick)
        {
            if (lastTick == tick)
            {
                return;
            }
            lastTick = tick;



            foreach (IParts part in Output.parts)
            {
                part.Switch(!power, tick);



            }


        }





        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    ConectorClicked?.Invoke(this, EventArgs.Empty);

        //}      


        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            InputClicked?.Invoke(Input2, EventArgs.Empty);
        }

        private void OutputButton_Click_1(object sender, RoutedEventArgs e)
        {
            OutputClicked?.Invoke(Output, EventArgs.Empty);
        }
    }
}
