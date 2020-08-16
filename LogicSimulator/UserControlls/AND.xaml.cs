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
    /// Interaction logic for AND.xaml
    /// </summary>
    public partial class AND : UserControl, IHolder
    {
        public int offsetX { get; }
        public int offsetY { get; }
        public ReferenceablePoint linePoint { get; set; }
        public List<Line> lines { get; set; }
        public AND()
        {

            InitializeComponent();
            Outputs = new List<Part>();
            Inputs = new List<Part>();
            lines = new List<Line>();
            offsetX = 50;
            offsetY = 50;
            Input1.lines = new List<Line>();
            Input2.lines = new List<Line>();
            Input1.Switch = SwitchI1;
            Input2.Switch = SwitchI2;
            Input2.offsetX = Input2CB.Margin.Top - Input2CB.Margin.Bottom;
            Input2.offsetY = Input2CB.Margin.Left - Input2CB.Margin.Right;
            Input1.offsetX = Input1CB.Margin.Top - Input1CB.Margin.Bottom;
            Input1.offsetY = Input1CB.Margin.Left - Input1CB.Margin.Right;
            Output.partControl = OutputCB;
            Input1.partControl = Input1CB;
            Input2.partControl = Input2CB;
            Outputs.Add(Output);
            Inputs.Add(Input1);
            Inputs.Add(Input2);
            Output.parts = new List<IParts>();
        }

        public List<IParts> parts { get; set; }
        public List<Part> Outputs { get; set; }
        public List<Part> Inputs { get; set; }
        Part Input2 = new Part(10,10);
        Part Input1 = new Part(10,43);
        Part Output = new Part(21,118);
        public IParts input { get; set; }

        public event EventHandler InputClicked;
        public event EventHandler OutputClicked;

        public Connection connection { get; set; }
        public bool power1 { get; set; }
        public bool power2 { get; set; }
        bool all = false;

        int lastTick1 = 0;
        int lastTick2 = 0;
        public void SwitchI2(bool power2, int tick)
        {
            if (lastTick1 == tick)
            {
                return;
            }
            lastTick1 = tick;
            this.power2 = power2;



            foreach (IParts part in Output.parts)
            {
                part.Switch(power1 & power2, tick);

                if (power1 & power2)
                {
                    image.Source = new BitmapImage(new Uri(@"C:\Users\game1\source\repos\LogicSimulator\LogicSimulator\Active-AND.svg.png"));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri(@"C:\Users\game1\source\repos\LogicSimulator\LogicSimulator\AND.svg.png"));
                }

            }


        }

        public void SwitchI1(bool power1, int tick)
        {
            if (lastTick2 == tick)
            {
                return;
            }
            lastTick2 = tick;
            this.power1 = power1;


            foreach (IParts part in Output.parts)
            {
                part.Switch(power1 & power2, tick);

                if (power1 & power2)
                {
                    image.Source = new BitmapImage(new Uri(@"C:\Users\game1\source\repos\LogicSimulator\LogicSimulator\Active-AND.svg.png"));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri(@"C:\Users\game1\source\repos\LogicSimulator\LogicSimulator\AND.svg.png"));
                }

            }

        }



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    ConectorClicked?.Invoke(this, EventArgs.Empty);

        //}      

        private void Input_Button_1(object sender, RoutedEventArgs e)
        {
            InputClicked?.Invoke(Input1, EventArgs.Empty);
        }

        private void Input_button_2(object sender, RoutedEventArgs e)
        {
            InputClicked?.Invoke(Input2, EventArgs.Empty);
        }

        private void Output_Button(object sender, RoutedEventArgs e)
        {
            OutputClicked?.Invoke(Output, EventArgs.Empty);
        }
    }
}
