using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;


namespace Doctor1
{
    internal class DBconnection
    {
        public MySqlConnection cn;
        public void Connect()
        {
            string connectionString = "Server=localhost;Database=hospitalms;Uid=root;Pwd=yourpassword;";
            cn = new MySqlConnection(connectionString);
        }
    }
}
