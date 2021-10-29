using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CXP.Utilities
{
     public class DbHelper
    {
        private static readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        static public SqlConnection instance
        {
            get
            {
                return _connection;
            }
        }
    }
}