using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web1201.Service
{
    public class GuestbooksDBService
    {
        //建立與資料庫的連線字串
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString;
        //建立與資料的連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);



    }
}