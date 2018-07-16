using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace LinuxDockerTest.Controllers
{

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
    [Produces("application/json")]
    [Route("api/PostGreSQL")]
    public class PostGreSQLController : Controller
    {
        [HttpGet]
        public List<Controllers.User> Get()
        {
            List<User> lstUsr = new List<User>();
            string connectionString = "host=fusioncds.cu1rwprqtnt5.us-east-1.rds.amazonaws.com; port=5432; UserName=fusioncdsadmin;Password=fusioncdsadmin; Database=FusionCDSCoreDB;";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(@"select " + '"' + "UserId" + '"' + " , " + '"' + "UserName" + '"' + " from public." + '"' + "FusionCDSUsers" + '"', conn))
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lstUsr.Add(new Controllers.User { UserId = Convert.ToInt32(reader[0].ToString()), UserName = reader[1].ToString() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstUsr;
        }
    }
}