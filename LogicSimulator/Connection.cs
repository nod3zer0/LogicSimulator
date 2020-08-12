using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace LogicSimulator
{



    public class Connection
    {


    

        public void AddRange(Connection connection)
        {
            Active.AddRange(connection.Active);
            Passive.AddRange(connection.Passive);
          
        }
        public void RemoveDuplicates()
        {
            Active = Active.Distinct().ToList();
            Passive = Passive.Distinct().ToList();

        }
        public int Id { get; set; }
        public bool Power { get; set; }
        public List<Control> _Active { get; set; }
        public List<Control> Active
        {
            get
            {
                if (_Active == null)
                {
                    _Active = new List<Control>();
                }
                return _Active;
            }
            set
            {
                if (_Active == null)
                {
                    _Active = new List<Control>();
                }
                _Active = value;
            }
        }
        public List<Control> _Passive { get; set; }
        public List<Control> Passive
        {
            get
            {
                if (_Passive == null)
                {
                    _Passive = new List<Control>();
                }
                return _Passive;
            }
            set
            {
                if (_Passive == null)
                {
                    _Passive = new List<Control>();
                }
                _Passive = value;
            }
        }
        private List<Line> _Lines;
        public List<Line> Lines
        {
            get
            {
                if (_Lines == null)
                {
                    _Lines = new List<Line>();
                }
                return _Lines;
            }
            set
            {
                if (_Lines == null)
                {
                    _Lines = new List<Line>();
                }
                _Lines = value;
            }
        }
    }

    //public class ControllComparer : EqualityComparer<List<Control>>
    //{
    //    public override bool Equals(List<Control> x, List<Control> y)
    //    {
    //        return (x.Name == y.Name && x.RenderTransformOrigin == y.RenderTransformOrigin);
    //    }

    //    public override int GetHashCode(List<Control> obj)
    //    {
    //        return obj.Name.GetHashCode() ^ obj.RenderTransformOrigin.GetHashCode();
    //    }
    //}
}
