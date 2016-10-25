using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"MOUSEWIP";

            string database = "SchoolBus";
            string username = "sa";
            string password = "htpvtkn4878856";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
