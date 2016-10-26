using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class Variable
    {
        private int maxNode = 0;
        private List<Stations> station = new List<Stations>();
        private List<Bus> bus = new List<Bus>();
        private Distance[,] distance;
        private Dictionary<int, List<int>> trace = new Dictionary<int, List<int>>();



        public List<Stations> Station
        {
            get{ return station; }

            set{ station = value;}
        }

        public List<Bus> Bus
        {
            get{  return bus; }

            set{ bus = value;}
        }

        public Distance[,] Distance
        {
            get {return distance; }

            set
            {distance = value;}
        }

        public Dictionary<int, List<int>> Trace
        {
            get{ return trace;}
            set{ trace = value;}
        }

        public int MaxNode
        {
            get
            {
                return maxNode;
            }

            set
            {
                maxNode = value;
            }
        }

        public void getData()
        {

        }
    }
}
