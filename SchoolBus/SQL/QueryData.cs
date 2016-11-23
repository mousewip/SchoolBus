using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace SchoolBus.SQL
{
    class QueryData
    {

        private static int maxValue;

        public static int MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                maxValue = value;
            }
        }

        public static List<Bus> QueryBus(SqlConnection conn)
        {
            string sql = "Select MaBus, Seat from BUS";

            // Tạo một đối tượng Command.
            SqlCommand cmd = new SqlCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            List<Bus> bus = new List<Bus>();
            


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        Bus item = new Bus();
                        // Vị trí của cột MaBus trong câu SQL.
                        int maBusIndex = reader.GetOrdinal("MaBus"); // 0
                        int maBus = Convert.ToInt32(reader.GetValue(0));

                        // Cột Seat có index = 1.
                        int seatIndex = reader.GetOrdinal("Seat");// 2
                        int seat = Convert.ToInt32(reader.GetValue(1));

                      

                        item.Id = maBus;
                        item.Seat = seat;
                        bus.Add(item);
                    }
                 
                    
                }
            }

            return bus;
        }


        private static int getMaxVale(SqlConnection conn)
        {

            string sql = "select COUNT(*) as A from STATIONS";

            // Tạo một đối tượng Command.
            SqlCommand cmd = new SqlCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            int temp = 0;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        // Vị trí của cột MaBus trong câu SQL.
                        int demIndex = reader.GetOrdinal("A"); // 0
                        int dem = Convert.ToInt32(reader.GetValue(0));
                        temp = dem;

                    }
                }
            }

            return temp;

        }

        public static Distance[,] QueryDistance(SqlConnection conn)
        {
            string sql = "Select KhoanCach, ThoiGian from DISTANCE";
            // Tạo một đối tượng Command.
            SqlCommand cmd = new SqlCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;

            maxValue = getMaxVale(conn);
            List<Distance> dis = new List<Distance>();
            

            Distance[,] distance = new Distance[maxValue, maxValue];

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        Distance item = new Distance();
                        // Vị trí của cột MaBus trong câu SQL.
                        int khoanCachIndex = reader.GetOrdinal("KhoanCach"); // 0
                        int khoanCach = Convert.ToInt32(reader.GetValue(0));

                        // Cột Seat có index = 1.
                        int thoiGianIndex = reader.GetOrdinal("ThoiGian");// 2
                        int thoiGian = Convert.ToInt32(reader.GetValue(1));


                        item.KhoanCach = khoanCach;
                        item.Time = thoiGian;
                        dis.Add(item);

                    }
                }
            }
            int row = 0, col = 0;
            foreach (var p in dis)
            {
                if (row < maxValue)
                {
                    if (col < maxValue)
                    {
                        distance[row, col] = p;
                        col++;
                    }
                    else
                    {
                        row++;
                        col = 0;
                        distance[row, col] = p;
                        col++;
                    }
                }
            }
            return distance;
        }

        public static List<Stations> QueryStationS(SqlConnection conn)
        {
            string sql = "Select Id, Lat, Lon, SLSV, Status from STATIONS";

            // Tạo một đối tượng Command.
            SqlCommand cmd = new SqlCommand();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            List<Stations> sta = new List<Stations>();
            

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        Stations item = new Stations();
                        // Vị trí của cột MaBus trong câu SQL.
                        int idIndex = reader.GetOrdinal("Id"); // 0
                        int id = Convert.ToInt32(reader.GetValue(0));

                        // Cột Seat có index = 1.
                        int latIndex = reader.GetOrdinal("Lat");// 1
                        double lat = Convert.ToDouble(reader.GetValue(1));

                        int lonIndex = reader.GetOrdinal("Lon");//2
                        double lon = Convert.ToDouble(reader.GetValue(2));

                        int slsvIndex = reader.GetOrdinal("SLSV");//3
                        int slsv = Convert.ToInt32(reader.GetValue(3));

                        int statusIndex = reader.GetOrdinal("Status");//4
                        bool status = Convert.ToBoolean(reader.GetValue(4));
                
                        item.Id = id;
                        item.Lat = lat;
                        item.Lon = lon;
                        item.SoSV = slsv;
                        item.Status = status;
                        sta.Add(item);
                    }
                }
            }
            return sta;
        }
    }
}
