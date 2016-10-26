using SchoolBus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.SQL
{
    class InsertData
    {

        public static void PutAllTableToDatabase(List<Bus> lBus, List<Stations> lStation, List<Distance> lDis)
        {
            InsertBus(lBus);
            InsertStation(lStation);
            InsertDistance(lDis);
        }


        private static void InsertBus(List<Bus> lBus)
        {

            // Lấy ra kết nối tới cơ sở dữ liệu.
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert BUS (MaBus, Seat) "
                                                 + " values (@mabus, @seat)";
                foreach (Bus b in lBus)
                {

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sql;

                    // Tạo một đối tượng tham số.
                    cmd.Parameters.Add("@mabus", SqlDbType.Int).Value = b.Id;

                    cmd.Parameters.Add("@seat", SqlDbType.Int).Value = b.Seat;
                    

                    // Thực thi câu lệnh (Dùng cho delete, insert, update).
                   cmd.ExecuteNonQuery();
                }

         
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Đóng kết nối
                connection.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                connection.Dispose();
                connection = null;
            }


            Console.Read();

        }

        //===================================================================
        private static void InsertStation(List<Stations> lStation)
        {

            // Lấy ra kết nối tới cơ sở dữ liệu.
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert STATIONS (Id, Lat, Lon, SLSV, Status) "
                                                 + " values (@id, @lat, @lon, @slsv, @status)";
                foreach (Stations b in lStation)
                {

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sql;

                    // Tạo một đối tượng tham số.
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = b.Id;

                    cmd.Parameters.Add("@lat", SqlDbType.Float).Value = b.Lat;

                    cmd.Parameters.Add("@lon", SqlDbType.Float).Value = b.Lon;

                    cmd.Parameters.Add("@slsv", SqlDbType.Int).Value = b.SoSV;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = b.Status;


                    // Thực thi câu lệnh (Dùng cho delete, insert, update).
                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Đóng kết nối
                connection.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                connection.Dispose();
                connection = null;
            }
        }

        //=============================================================
        private static void InsertDistance(List<Distance> lDistance)
        {

            // Lấy ra kết nối tới cơ sở dữ liệu.
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Câu lệnh Insert.
                string sql = "Insert DISTANCE (KhoanCach, ThoiGian) "
                                                 + " values (@khoancach, @thoigian)";
                foreach (Distance b in lDistance)
                {

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sql;

                    // Tạo một đối tượng tham số.
                    cmd.Parameters.Add("@khoancach", SqlDbType.Int).Value = b.KhoanCach;

                    cmd.Parameters.Add("@thoigian", SqlDbType.Int).Value = b.Time;


                    // Thực thi câu lệnh (Dùng cho delete, insert, update).
                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Đóng kết nối
                connection.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                connection.Dispose();
                connection = null;
            }
        }

    }
}
