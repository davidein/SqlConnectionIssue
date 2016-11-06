using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Testing.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static IConfigurationRoot _configurationRoot = null;

        public ValuesController()
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

            _configurationRoot = builder.Build();
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {

            for (var i = 0; i < 2; i++)
            {

                using (
                    var connection =
                        new SqlConnection(
                            _configurationRoot["ConnectionStrings:DefaultConnection"]
                            )
                    )
                {
                    connection.Open();
                    connection.Close();
                }
            }
            return "Done, now wait for 8 to 10 minutes.";
        }
    }
}
