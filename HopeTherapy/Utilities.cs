using HopeTherapy.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HopeTherapy
{
    public static class Utilities
    {
        public static readonly SqlDataAccess Sql = new SqlDataAccess(ConfigurationManager.ConnectionStrings["HopeTherapyIMS"].ConnectionString);
    }


}