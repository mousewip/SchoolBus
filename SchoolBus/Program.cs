using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class Program
    {
        static void Main(string[] args)
        {
            XuLy xl = new XuLy();
            xl.ReadData();
            xl.TotalTime = 2400;
          
            Console.WriteLine("\n\n");
            xl.run2();
        
            Console.ReadKey();
        }
    }
}
