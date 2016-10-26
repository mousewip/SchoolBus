using SchoolBus.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class ReadDatabase
    {

        public static Variable ConnectData()
        {
            Variable item = new Variable();
            // Lấy ra đối tượng Connection kết nối vào DB.
            SqlConnection conn = DBUtils.GetDBConnection();
            Console.WriteLine("Open connection...");

            conn.Open();
            try
            {
                Console.WriteLine("Open connection success");
                item.Bus = QueryData.QueryBus(conn);
                item.Station = QueryData.QueryStationS(conn);
                item.Distance = QueryData.QueryDistance(conn);
                item.MaxNode = QueryData.MaxValue;
                Console.WriteLine("Read data from database success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Đóng kết nối.
                conn.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                conn.Dispose();
            }
            return item;
        }
    }
}
