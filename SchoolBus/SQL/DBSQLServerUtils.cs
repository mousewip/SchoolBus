﻿using System.Data.SqlClient;

namespace SchoolBus
{
    class DBSQLServerUtils
    {
        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=MOUSEWIP;Initial Catalog=SchoolBus;Persist Security Info=True;User ID=sa;Password=***********;Pooling=False
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
