using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class Bus
    {
        private int id;
        private int seat;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Seat
        {
            get { return seat; }
            set { seat = value; }
        }

    }
}
