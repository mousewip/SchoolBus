using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class ReadFromFile
    {
        static int maxNode = 0;
        private static List<Bus> bus = new List<Bus>();
        private static List<Stations> station = new List<Stations>();
        private static List<Distance> distance = new List<Distance>();
        private static Dictionary<Bus, List<int>> trace = new Dictionary<Bus, List<int>>();
        private static List<string> loTrinh = new List<string>();
        private static string fileBus = "buses.txt", fileStation = "station.txt", fileDistance = "distance.txt";
        private static string DuongDan = @"D:\IDE\CSharp\SchoolBus\SchoolBus\data\";

        internal List<Bus> Bus
        {
            get
            {
                return bus;
            }

            set
            {
                bus = value;
            }
        }

        internal List<Stations> Station
        {
            get
            {
                return station;
            }

            set
            {
                station = value;
            }
        }

        internal List<Distance> Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

        internal Dictionary<Bus, List<int>> Trace
        {
            get
            {
                return trace;
            }

            set
            {
                trace = value;
            }
        }

        public static void ReadData()
        {
            // read data from file Buses.txt
            string[] kq = File.ReadAllLines(DuongDan + fileBus);
            foreach (var s in kq)
            {
                Bus t = new Bus();
                string[] pt = s.Split('\t');
                t.Id = int.Parse(pt[0]);
                t.Seat = int.Parse(pt[1]);
                bus.Add(t);
            }
         
            Array.Clear(kq, 0, kq.Length);

            // read data from station.txt
            kq = File.ReadAllLines(DuongDan + fileStation);
            foreach (var s in kq)
            {
                maxNode++;
                Stations t = new Stations();
                string[] pt = s.Split('\t');
                t.Id = int.Parse(pt[0]);
                t.Lat = float.Parse(pt[1]);
                t.Lon = float.Parse(pt[2]);
                t.SoSV = int.Parse(pt[3]);
                t.Status = false;
                station.Add(t);
            }
            Array.Clear(kq, 0, kq.Length);

            // read data from distance.txt

            kq = File.ReadAllLines(DuongDan + fileDistance);

            int row = 0, col = 0;
            foreach (var s in kq)
            {
                Distance dis = new Distance();
                string[] pt = s.Split('\t');
                dis.KhoanCach = int.Parse(pt[0]);
                dis.Time = int.Parse(pt[1]);
                distance.Add(dis);
            }
            Array.Clear(kq, 0, kq.Length);
            Console.WriteLine("Read all file successful");
        }
    }
}
