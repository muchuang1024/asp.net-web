using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TrafficExam.Command
{
    public class GetConn
    {
        public static SqlConnection GetConnection(string conn)
        {
            return new SqlConnection(conn);
        }
    }
}
