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

        public static void ConnectData()
        {
            // Lấy ra đối tượng Connection kết nối vào DB.
            SqlConnection conn = DBUtils.GetDBConnection();
            
            conn.Open();
            try
            {
                QueryData.QueryBus(conn);
                QueryData.QueryStationS(conn);
                QueryData.QueryDistance(conn);
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
            Console.Read();
        }

    }
        
}
