using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.UserModel;


// Define name of space. 
namespace newCubeBackend.UserControllers
{
    // method Route it's the link of API endpoint.
    [Route("api/User")]
    [ApiController]
    // Creating a child class UserController of ControllerBase
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method it's used for requests HTTP of type Get.
        [HttpGet]
        public String Get()
        {
            // Create query in string with SQL command inside.
            string query = "SELECT * FROM tableUtilisateur";

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
            string query = "SELECT * FROM tableUtilisateur WHERE id_utilisateur = @Id";

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
        public JsonResult Post(User user)
        {
            // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
            string query = @"INSERT INTO tableUtilisateur(prenom, nom, email, mot_de_passe, adresse, code_postal, ville, numero_de_telephone, admin) 
                            VALUES (@Prenom, @Nom, @Email, @Mot_de_passe, @Adresse, @Code_postal, @Ville, @Numero_de_telephone, @Admin)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Prenom", user.Prenom);
            cmd.Parameters.AddWithValue("@Nom", user.Nom);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Mot_de_passe", user.Mot_de_passe);
            cmd.Parameters.AddWithValue("@Adresse", user.Adresse);
            cmd.Parameters.AddWithValue("@Code_postal", user.Code_postal);
            cmd.Parameters.AddWithValue("@Ville", user.Ville);
            cmd.Parameters.AddWithValue("@Numero_de_telephone", user.Numero_de_telephone);
            cmd.Parameters.AddWithValue("@Admin", user.Admin);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from tableUtilisateur where id_utilisateur = @Id;";

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
        public JsonResult Put(int id, User user)
        {
            var sql = @"UPDATE tableUtilisateur
                        SET prenom = @Prenom,  
                        nom = @Nom, 
                        email = @Email, 
                        mot_de_passe = @Mot_de_passe, 
                        adresse = @Adresse, 
                        code_postal = @Code_postal, 
                        ville = @Ville, 
                        numero_de_telephone = @Numero_de_telephone 
                        WHERE id_utilisateur = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Prenom", user.Prenom);
            cmd.Parameters.AddWithValue("@Nom", user.Nom);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Mot_de_passe", user.Mot_de_passe);
            cmd.Parameters.AddWithValue("@Adresse", user.Adresse);
            cmd.Parameters.AddWithValue("@Code_postal", user.Code_postal);
            cmd.Parameters.AddWithValue("@Ville", user.Ville);
            cmd.Parameters.AddWithValue("@Numero_de_telephone", user.Numero_de_telephone);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}


