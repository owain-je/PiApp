using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PiApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var result = "";
            var somthing = "new value is ";

            try
            {
                var p = Path.Combine(Directory.GetCurrentDirectory(), "config");
                var builder = new ConfigurationBuilder().SetBasePath(p).AddJsonFile("appsettings.json");

                var Configuration = builder.Build();

                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = Configuration["connection"]
                };
                connection.Open();
                var SomeValue = 0;

                var Pi = new Pi();
                result = Pi.Calculate(id);
                string query = string.Format("INSERT INTO pi_list (value) VALUES({0})",result);
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();


                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return somthing + result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
