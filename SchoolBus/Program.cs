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
            ReadFromFile rff = new ReadFromFile();
            ReadFromFile.ReadData();
            InsertData.PutAllTableToDatabase(rff.Bus, rff.Station, rff.Distance);


            XuLy xl = new XuLy();
            xl.ReadData();
            xl.TotalTime = 2400;
          
            Console.WriteLine("\n\n");
            xl.run2();
        
            Console.ReadKey();
        }
    }
}
