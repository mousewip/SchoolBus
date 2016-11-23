using System.Data.SqlClient;

namespace SchoolBus
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            //workstation id=SchoolBus.mssql.somee.com;packet size=4096;
            //user id=mousewip_SQLLogin_1;pwd=79cgxexkw1;data source=SchoolBus.mssql.somee.com;
            //persist security info=False;initial catalog=SchoolBus
            string datasource = @"MOUSEWIP";

            string database = "SchoolBus";
            string username = "sa";
            string password = "htpvtkn4878856";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
