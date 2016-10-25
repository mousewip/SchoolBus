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

        private double lat;
        private double lon;



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

        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        public double Lon
        {
            get { return lon; }
            set { lon = value; }
        }
    }
}
