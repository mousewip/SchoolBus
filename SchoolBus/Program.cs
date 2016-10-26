using SchoolBus.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class Program
    {
        static void Main(string[] args)
        {
            //           ReadFromFile rff = new ReadFromFile();
            //           ReadFromFile.ReadData();
            //           InsertData.PutAllTableToDatabase(rff.Bus, rff.Station, rff.Distance);


            //Variable test = ReadDatabase.ConnectData();
            //xemThuCacMang(test.Bus, test.Station, test.Distance, test.MaxNode);

           

            XuLy xl = new XuLy();

            xl.TotalTime = 2400;
            xl.run2();
            Console.ReadKey();


        }

        static void xemThuCacMang(List<Bus> bus, List<Stations> station, Distance[,] distance, int maxValue)
        {
            foreach (var p in bus)
            {
                Console.WriteLine(p.Id + "   " + p.Seat);
            }
            Console.WriteLine("===================================================");

            foreach (var p in station)
            {
                Console.WriteLine(p.Id + "   " + p.SoSV + "   " + p.Status);
            }
            Console.WriteLine("===================================================");

            for (int i = 0; i < maxValue; i++)
            {
                for (int j = 0; j < maxValue; j++)
                    Console.Write(distance[i, j].KhoanCach + "  ");
                Console.WriteLine();
            }
        }
    }
}
