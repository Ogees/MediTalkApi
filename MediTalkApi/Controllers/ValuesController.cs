using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace MediTalkApi.Controllers
{
    public class ValuesController : ApiController
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=" + HostingEnvironment.MapPath(@"~/App_Data/data.db"));
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {

            string record = "";
            string query = $"SELECT * FROM meditalk_data WHERE id IS '{id}'";

            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        record = (string)dr["illness"];
                    }
                }
            }
            conn.Close();
            return (id.ToString() + " : " + record);
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            //using (StreamWriter sw = new StreamWriter("test.txt", true))
            //{
            //    sw.Write("worked");
            //}

            return "Worked";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
