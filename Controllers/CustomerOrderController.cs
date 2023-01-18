using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.CustomerOrderModel;


// Define name of space. 
namespace newCubeBackend.CustomerOrderController
{
    // method Route it's the link of API endpoint.
    [Route("api/CommandeClient")]
    [ApiController]
    // Creating a child class UserController of ControllerBase
    public class CustomerOrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CustomerOrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method it's used for requests HTTP of type Get.
        [HttpGet]
        public String Get()
        {
            // Create query in string with SQL command inside.
            string query = "SELECT * FROM commandeClient";

            // Create object table with the method new DataTable() of type DataTable.
            DataTable table = new DataTable();
            // Create object named myReader of type MySqlDataReader. This method myReader it's used after.
            MySqlDataReader myReader;
            // Create connection nammed conn of MySqlConnection. he use DBConnect.GetDBConnection(). this method it's Define on ../Controllers/DBConnect.cs
            MySqlConnection conn = DBConnect.GetDBConnection();

            // Open the conn define line above
            conn.Open();

            // Create the variable cmd of type MySqlCommand. He create a new MySqlCommand with paramaters the query (it's the SQL command define above) and (conn it's the connection of DB).
            // For use MySqlCommand, you need to use using MySql.Data.MySqlClient; at up of the file.
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //  With myReader use cmd define above for ExecuteReader(); 
            myReader = cmd.ExecuteReader();
            // From table load the data of myReader.
            table.Load(myReader);

            // After have Load the data in table we can close the reader and the conn.
            myReader.Close();
            conn.Close();

            // Use JsonConvert.SerializeObject() for the module Newtonsoft.Json; with parameter table define above and Formatting.Indented it's for do not see line of data.
            // this method it's save in json of type string
            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            // return it's the last command of the method Get(). he return the json define above.
            return json;
        }


        [HttpGet("{id}")]
        public String GetById(int id)
        {
            string query = "SELECT * FROM commandeClient WHERE IdCommandeClient = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        [HttpPost]
        public JsonResult Post(CustomerOrder customer_order)
        {
            // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
            string query = @"INSERT INTO commandeClient(nombreArticleCClient, numeroCommandeCClient, prixTTCCClient, prixHorsTaxeCClient, dateCommandeCClient, reductionCClient, coutLivraisonCClient) 
                            VALUES (@Nombre_article, @Numero_de_commande, @Prix, @Prix_hors_taxe, @Date_commande, @Reduction, @Cout_livraison)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Nombre_article", customer_order.Nombre_article);
            cmd.Parameters.AddWithValue("@Numero_de_commande", customer_order.Numero_de_commande);
            cmd.Parameters.AddWithValue("@Prix", customer_order.Prix);
            cmd.Parameters.AddWithValue("@Prix_hors_taxe", customer_order.Prix_hors_taxe);
            cmd.Parameters.AddWithValue("@Date_commande", customer_order.Date_commande);
            cmd.Parameters.AddWithValue("@Reduction", customer_order.Reduction);
            cmd.Parameters.AddWithValue("@Cout_livraison", customer_order.Cout_livraison);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from commandeClient where IdCommandeClient = @Id;";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Deleted Successfully");
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, CustomerOrder customer_order)
        {
            var sql = @"UPDATE commandeClient
                        SET nombreArticleCClient = @Nombre_article,  
                        numeroCommandeCClient = @Numero_de_commande, 
                        prixTTCCClient = @Prix, 
                        prixHorsTaxeCClient = @Prix_hors_taxe, 
                        dateCommandeCClient = @Date_commande, 
                        reductionCClient = @Reduction, 
                        coutLivraisonCClient = @Cout_livraison 
                        WHERE IdCommandeClient = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nombre_article", customer_order.Nombre_article);
            cmd.Parameters.AddWithValue("@Numero_de_commande", customer_order.Numero_de_commande);
            cmd.Parameters.AddWithValue("@Prix", customer_order.Prix);
            cmd.Parameters.AddWithValue("@Prix_hors_taxe", customer_order.Prix_hors_taxe);
            cmd.Parameters.AddWithValue("@Date_commande", customer_order.Date_commande);
            cmd.Parameters.AddWithValue("@Reduction", customer_order.Reduction);
            cmd.Parameters.AddWithValue("@Cout_livraison", customer_order.Cout_livraison);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}


