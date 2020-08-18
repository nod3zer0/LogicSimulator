using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            firstPoint = true;
            connections = new List<Connection>();
            connection = new Connection();
            connection.Passive = new List<Control>();
            Lines = new List<Line>();
            powerSupplys = new List<IParts>();
            InitTimer();
        }

        int lastId = 0;
        public Point lastPouint;

        public bool firstPoint;
        IParts output;
        List<IParts> powerSupplys;
        public List<Line> Lines;
        Connection connection;
        List<Connection> connections;

        IHolder MoveHolder;
        //    Control MoveHolder;

        private void Object_MouseLeftButtonDown(object sender, EventArgs e)
        {
            //var x = MoveHolder as Button;
            //if (x != null)
            //{

            //}
            if (DeleteRButton.IsChecked == true)
            {
                var x = sender as IParts;
                if (x != null)
                {
                    ((IParts)sender).lines.ForEach(l => canvas.Children.Remove(l));
                    ((IParts)sender).connectors.ForEach(c => canvas.Children.Remove(c));
                    ((IParts)sender).lines = new List<Line>();
                    if (((IParts)sender).Inputs != null)
                    {
                        ((IParts)sender).Inputs.ForEach(i => i.input.parts.Remove(i));
                    }
                  ((IParts)sender).Outputs.ForEach(o => o.parts.ForEach(p => p.Switch(false, 0)));
                    ((IParts)sender).Outputs.ForEach(o => powerSupplys.Remove(o));


                    canvas.Children.Remove((UIElement)sender);
                }
              
            }
            else
            {
                MoveHolder = (IHolder)sender;
            }

        }
        private void Object_MouseLeftButtonUp(object sender, EventArgs e)
        {
            MoveHolder = null;
        }

        Line TempLine = new Line();
        List<Connector> tempConnectors = new List<Connector>();
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (!firstPoint && LineButton.IsChecked == true)
            {

                canvas.Children.Remove(TempLine);

                TempLine.X1 = Mouse.GetPosition(canvas).X;
                TempLine.Y1 = Mouse.GetPosition(canvas).Y;
                TempLine.X2 = lastPouint.X;


                TempLine.Y2 = lastPouint.Y;

                // Create a red Brush  
                SolidColorBrush redBrush = new SolidColorBrush();
                redBrush.Color = Colors.Red;

                // Set Line's width and color  
                TempLine.StrokeThickness = 4;
                TempLine.Stroke = redBrush;


                // Add line to the Grid.  
                canvas.Children.Add(TempLine);
                Canvas.SetZIndex(TempLine, -10);
            }
            if (MoveHolder == null)
            {
                return;
            }
            //Connector con = new Connector();
            //if (sender.GetType().IsEquivalentTo(con.GetType()))
            //{
            //    if (((Connector)sender).line1 != null && ((Connector)sender).line2 != null)
            //    {
            //        ((Connector)sender).line1.X2 = Mouse.GetPosition(canvas).X;
            //        ((Connector)sender).line1.Y2 = Mouse.GetPosition(canvas).Y;
            //        ((Connector)sender).line2.X1 = Mouse.GetPosition(canvas).X;
            //        ((Connector)sender).line2.Y1 = Mouse.GetPosition(canvas).Y;
            //    }
            //}




            double s = Canvas.GetTop((UIElement)MoveHolder);
            double y = (Mouse.GetPosition(canvas).X);
            double xratio = Canvas.GetTop((UIElement)MoveHolder) - (Mouse.GetPosition(canvas).X);
            double yratio = Canvas.GetLeft((UIElement)MoveHolder) - (Mouse.GetPosition(canvas).Y);
            Canvas.SetLeft((UIElement)MoveHolder, Mouse.GetPosition(canvas).X - MoveHolder.offsetX);
            Canvas.SetTop((UIElement)MoveHolder, Mouse.GetPosition(canvas).Y - MoveHolder.offsetY);



            //foreach (Line line in (MoveHolder).lines)
            //{
            //    line.X2 = Mouse.GetPosition(canvas).X;
            //    line.Y2 = Mouse.GetPosition(canvas).Y;

            //}
            List<Part> temp = new List<Part>();
            // temp.AddRange(MoveHolder.Inputs);
            //temp.AddRange(MoveHolder.Outputs);
            foreach (Part output in MoveHolder.Outputs)
            {
                foreach (Line line in output.lines)
                {

                    line.X2 = ((Control)MoveHolder).TransformToAncestor(canvas).Transform(new Point(output.offsetY, output.offsetX)).X;
                    line.Y2 = ((Control)MoveHolder).TransformToAncestor(canvas).Transform(new Point(output.offsetY, output.offsetX)).Y;
                }
            }
            foreach (Part input in MoveHolder.Inputs)
            {
                foreach (Line line in input.lines)
                {

                    line.X1 = ((Control)MoveHolder).TransformToAncestor(canvas).Transform(new Point(input.offsetY, input.offsetX)).X;
                    line.Y1 = ((Control)MoveHolder).TransformToAncestor(canvas).Transform(new Point(input.offsetY, input.offsetX)).Y;
                }
            }
            //foreach (Part output in MoveHolder.Outputs)
            //{
            //    foreach (Line line in output.lines)
            //    {

            //        line.X2 = ((Control)MoveHolder).TransformToAncestor(canvas).Transform(new Point(output.offsetY, output.offsetX)).X;
            //        line.Y2 = ((Control)MoveHolder).TransformToAncestor(canvas).Transform(new Point(output.offsetY, output.offsetX)).Y;

            //    }
            //}




            var x = MoveHolder as Connector;
            if (x != null)
            {
                if (((Connector)MoveHolder).line1 != null && ((Connector)MoveHolder).line2 != null)
                {
                    ((Connector)MoveHolder).line1.X2 = Mouse.GetPosition(canvas).X;
                    ((Connector)MoveHolder).line1.Y2 = Mouse.GetPosition(canvas).Y;
                    ((Connector)MoveHolder).line2.X1 = Mouse.GetPosition(canvas).X;
                    ((Connector)MoveHolder).line2.Y1 = Mouse.GetPosition(canvas).Y;
                }
            }



            //MoveHolder.RenderTransform = tt;
            //MoveHolder.
            //tt.X = Mouse.GetPosition(canvas).X;//-250
            //tt.Y = Mouse.GetPosition(canvas).Y;//-250
        }

        Line lastLine;
        bool firstLine = false;
        List<Line> tempLines = new List<Line>();
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (LightBulbButton.IsChecked == true)
            {
                LightBulb b = new LightBulb();
                //kliknutí na připojovák
                b.ConectorClicked += input_ConectorClicked;
                //přetahování myší
                b.MouseRightButtonDown += Object_MouseLeftButtonDown;
                b.MouseRightButtonUp += Object_MouseLeftButtonUp;
                //umístění na kurzor myši
                Canvas.SetLeft(b, Mouse.GetPosition(canvas).X);
                Canvas.SetTop(b, Mouse.GetPosition(canvas).Y);
                //přidání do canvas
                canvas.Children.Add(b);


            }
            else if (ButtonRbutton.IsChecked == true)
            {
                Button b = new Button();
                //    b.TransformToAncestor(canvas).Transform(Mouse.GetPosition(canvas));
                b.ConectorClicked += Button_ConectorClicked;
                //přetahování myší

                b.MouseRightButtonDown += Object_MouseLeftButtonDown;
                b.MouseRightButtonUp += Object_MouseLeftButtonUp;
                //b.AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)Object_MouseLeftButtonDown, true);
                //b.AddHandler(UIElement.MouseLeftButtonUpEvent, (RoutedEventHandler)Object_MouseLeftButtonUp, true);

                Canvas.SetLeft(b, Mouse.GetPosition(canvas).X);
                Canvas.SetTop(b, Mouse.GetPosition(canvas).Y);
                powerSupplys.AddRange(b.Outputs);
                canvas.Children.Add(b);
            }
            else if (NOTRButton.IsChecked == true)
            {
                NOT not = new NOT();
                //    b.TransformToAncestor(canvas).Transform(Mouse.GetPosition(canvas));
                not.InputClicked += input_ConectorClicked;
                not.OutputClicked += Button_ConectorClicked;
                //přetahování myší
                not.MouseRightButtonDown += Object_MouseLeftButtonDown;
                not.MouseRightButtonUp += Object_MouseLeftButtonUp;

                Canvas.SetLeft(not, Mouse.GetPosition(canvas).X);
                Canvas.SetTop(not, Mouse.GetPosition(canvas).Y);
                canvas.Children.Add(not);
            }
            else if (ANDRButton.IsChecked == true)
            {
                AND and = new AND();
                //    b.TransformToAncestor(canvas).Transform(Mouse.GetPosition(canvas));
                and.InputClicked += input_ConectorClicked;
                and.OutputClicked += Button_ConectorClicked;

                //přetahování myší
                and.MouseRightButtonDown += Object_MouseLeftButtonDown;
                and.MouseRightButtonUp += Object_MouseLeftButtonUp;

                Canvas.SetLeft(and, Mouse.GetPosition(canvas).X);
                Canvas.SetTop(and, Mouse.GetPosition(canvas).Y);
                canvas.Children.Add(and);
            }
            else if (!firstPoint && LineButton.IsChecked == true)
            {

                Line redLine = new Line();

                Connector con = new Connector();

                Canvas.SetLeft(con, lastPouint.X - ((IHolder)con).offsetX);
                Canvas.SetTop(con, lastPouint.Y - ((IHolder)con).offsetX);

                con.MouseRightButtonDown += Object_MouseLeftButtonDown;
                con.MouseRightButtonUp += Object_MouseLeftButtonUp;
                con.line1 = redLine;
                con.line2 = lastLine;
                if (lastLine != null)
                {
                    canvas.Children.Add(con);
                }

                tempConnectors.Add(con);
                Canvas.SetZIndex(con, 10);
                redLine.X1 = Mouse.GetPosition(canvas).X;
                redLine.Y1 = Mouse.GetPosition(canvas).Y;
                redLine.X2 = lastPouint.X;


                redLine.Y2 = lastPouint.Y;
                lastPouint = Mouse.GetPosition(canvas);
                // Create a red Brush  
                SolidColorBrush redBrush = new SolidColorBrush();
                redBrush.Color = Colors.Red;

                // Set Line's width and color  
                redLine.StrokeThickness = 4;
                redLine.Stroke = redBrush;

                Lines.Add(redLine);
                lastLine = redLine;
                if (firstLine)
                {
                    ((IParts)output).lines.Add(redLine);
                    firstLine = false;
                }
                // Add line to the Grid.  

                canvas.Children.Add(redLine);
                tempLines.Add(redLine);
                Canvas.SetZIndex(redLine, -10);
            }
            //else
            //{
            //    firstPoint = false;
            //    lastPouint = Mouse.GetPosition(canvas);
            //}

        }
        int tick = 0;
        public void Updater()
        {

            if (tick >= 1000)
            {
                tick = 0;
            }
            tick++;


            foreach (IParts x in powerSupplys)
            {
                x.Switch(true, tick);
            }



            //foreach (Connection connection in connections)
            //{

            //    bool power = false;
            //    foreach (Parts part in connection.Passive)
            //    {
            //        power |= part.power;
            //    }

            //    foreach (Parts part in connection.Passive)
            //    {


            //        part.Switch(power);
            //    }
            //}
        }

        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Elapsed += timer1_Tick;
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                Updater();
            }));



        }





        private void input_ConectorClicked(object sender, EventArgs e)
        {
            if (LineButton.IsChecked == false)
            {
                return;
            }
            if (output != null)
            {
                output.parts.Add((IParts)sender);
                ((IParts)sender).input = output;

                if (!firstPoint)
                {

                    //Line redLine = new Line();
                    //redLine.X1 = Mouse.GetPosition(canvas).X;
                    //redLine.Y1 = Mouse.GetPosition(canvas).Y;
                    //redLine.X2 = lastPouint.X;
                    //redLine.Y2 = lastPouint.Y;
                    //lastPouint = Mouse.GetPosition(canvas);
                    //// Create a red Brush  
                    //SolidColorBrush redBrush = new SolidColorBrush();
                    //redBrush.Color = Colors.Red;

                    //// Set Line's width and color  
                    //redLine.StrokeThickness = 4;
                    //redLine.Stroke = redBrush;

                    //// Add line to the Grid.  
                    //canvas.Children.Add(redLine);
                    //lastLine = redLine;
                    //Lines.Add(redLine);
                    //  ((IHolder)sender).lines.Add(redLine);
                    ((Part)sender).parrent.lines.AddRange(tempLines);
                    ((Part)output).parrent.lines.AddRange(tempLines);
                    ((Part)sender).parrent.connectors.AddRange(tempConnectors);
                    ((Part)output).parrent.connectors.AddRange(tempConnectors);
                    ((IParts)sender).lines.Add(lastLine);

                    firstPoint = !firstPoint;

                }

                output = null;

            }
            else if (((IParts)sender).input != null)
            {
                output = ((IParts)sender).input;

                if (!firstPoint)
                {

                    //Line redLine = new Line();
                    //redLine.X1 = Mouse.GetPosition(canvas).X;
                    //redLine.Y1 = Mouse.GetPosition(canvas).Y;
                    //redLine.X2 = lastPouint.X;
                    //redLine.Y2 = lastPouint.Y;
                    //lastPouint = Mouse.GetPosition(canvas);
                    //// Create a red Brush  
                    //SolidColorBrush redBrush = new SolidColorBrush();
                    //redBrush.Color = Colors.Red;

                    //// Set Line's width and color  
                    //redLine.StrokeThickness = 4;
                    //redLine.Stroke = redBrush;

                    //// Add line to the Grid.  
                    //canvas.Children.Add(redLine);

                    //lastLine = redLine;
                    ((Part)sender).InputParts.Add(output);
                    ((Part)sender).parrent.lines.AddRange(tempLines);
                    ((Part)output).parrent.lines.AddRange(tempLines);
                    ((Part)sender).parrent.connectors.AddRange(tempConnectors);
                    ((Part)output).parrent.connectors.AddRange(tempConnectors);
                    ((IHolder)sender).lines.Add(lastLine);

                    Lines.Add(lastLine);


                }
                firstPoint = !firstPoint;
            }



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Updater();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            Lines.ForEach(l => canvas.Children.Remove(l));


            foreach (Connection con in connections)
            {
                //con.Lines.ForEach(l => canvas.Children.Remove(l));

                con.Lines.ForEach(l => l = null);


            }
            connections.ForEach(c => c.Passive.ForEach(p => ((IParts)p).connection = null));
            connections.ForEach(c => c = null);
            connection = null;
            connections.Clear();

        }

        private void Button_ConectorClicked(object sender, EventArgs e)
        {
            if (LineButton.IsChecked == false)
            {
                return;
            }


            if (output == null)
            {
                output = (IParts)sender;
            }
            tempLines = new List<Line>();
            firstPoint = !firstPoint;

            lastPouint = Mouse.GetPosition(canvas);
            lastLine = null;
            firstLine = true;
        }


    }
}
