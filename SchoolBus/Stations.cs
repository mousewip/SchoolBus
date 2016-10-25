using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class Stations
    {
        private int id;
        private int soSV;
        private bool status;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int SoSV
        {
            get { return soSV; }
            set { soSV = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
