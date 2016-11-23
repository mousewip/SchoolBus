using System;

namespace SchoolBus
{
    class Program
    {
        static void Main(string[] args)
        {
                       //ReadFromFile rff = new ReadFromFile();
                       //ReadFromFile.ReadData();
                       //InsertData.PutAllTableToDatabase(rff.Bus, rff.Station, rff.Distance);

            XuLy xl = new XuLy();

            xl.TotalTime =2400;
            xl.run2();
            Console.ReadKey();
        }
    }
}
