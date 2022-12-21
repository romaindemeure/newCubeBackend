using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using WebApplication1.Controllers;
using System.Data;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public String Get()
        {
            string query = "SELECT * FROM Department";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }
    }
}


