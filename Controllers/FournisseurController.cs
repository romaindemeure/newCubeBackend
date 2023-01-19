using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.FournisseurModel;


// Define name of space. 
namespace newCubeBackend.FournisseurController
{
    // method Route it's the link of API endpoint.
    [Route("api/Fournisseur")]
    [ApiController]
    // Creating a child class UserController of ControllerBase
    public class FournisseurController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FournisseurController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method it's used for requests HTTP of type Get.
        [HttpGet]
        public String Get()
        {
            // Create query in string with SQL command inside.
            string query = "SELECT * FROM tableFournisseur";

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
            string query = "SELECT * FROM tableFournisseur WHERE IdFournisseur = @Id";

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
        public JsonResult Post(Fournisseur fournisseur)
        {
            // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
            string query = @"INSERT INTO tableFournisseur(nomFournisseur, emailFournisseur, telephoneUtilisateur, siretFournisseur, coordonneesBancarieFournisseur, adresseFournisseur, codePostaleUtilisateur, villeFournisseur, descriptionFournisseur) 
                            VALUES (@Nom_Fournisseur, @Email_Fournisseur, @Telephone_Utilisateur, @Siret_Fournisseur, @Coordonnees_Bancarie_Fournisseur, @Adresse_Fournisseur, @Code_Postale_Utilisateur, @Ville_Fournisseur, @Description_Fournisseur)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Nom_Fournisseur", fournisseur.Nom_Fournisseur);
            cmd.Parameters.AddWithValue("@Email_Fournisseur", fournisseur.Email_Fournisseur);
            cmd.Parameters.AddWithValue("@Telephone_Utilisateur", fournisseur.Telephone_Utilisateur);
            cmd.Parameters.AddWithValue("@Siret_Fournisseur", fournisseur.Siret_Fournisseur);
            cmd.Parameters.AddWithValue("@Coordonnees_Bancarie_Fournisseur", fournisseur.Coordonnees_Bancarie_Fournisseur);
            cmd.Parameters.AddWithValue("@Adresse_Fournisseur", fournisseur.Adresse_Fournisseur);
            cmd.Parameters.AddWithValue("@Code_Postale_Utilisateur", fournisseur.Code_Postale_Utilisateur);
            cmd.Parameters.AddWithValue("@Ville_Fournisseur", fournisseur.Ville_Fournisseur);
            cmd.Parameters.AddWithValue("@Description_Fournisseur", fournisseur.Description_Fournisseur);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from tableFournisseur where IdFournisseur = @Id;";

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
        public JsonResult Put(int id, Fournisseur fournisseur)
        {
            var sql = @"UPDATE tableFournisseur
                        SET nomFournisseur = @Nom_Fournisseur,  
                        emailFournisseur = @Email_Fournisseur, 
                        telephoneUtilisateur = @Telephone_Utilisateur, 
                        siretFournisseur = @Siret_Fournisseur, 
                        coordonneesBancarieFournisseur = @Coordonnees_Bancarie_Fournisseur, 
                        adresseFournisseur = @Adresse_Fournisseur, 
                        codePostaleUtilisateur = @Code_Postale_Utilisateur, 
                        villeFournisseur = @Ville_Fournisseur, 
                        descriptionFournisseur = @Description_Fournisseur 
                        WHERE IdFournisseur = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nom_Fournisseur", fournisseur.Nom_Fournisseur);
            cmd.Parameters.AddWithValue("@Email_Fournisseur", fournisseur.Email_Fournisseur);
            cmd.Parameters.AddWithValue("@Telephone_Utilisateur", fournisseur.Telephone_Utilisateur);
            cmd.Parameters.AddWithValue("@Siret_Fournisseur", fournisseur.Siret_Fournisseur);
            cmd.Parameters.AddWithValue("@Coordonnees_Bancarie_Fournisseur", fournisseur.Coordonnees_Bancarie_Fournisseur);
            cmd.Parameters.AddWithValue("@Adresse_Fournisseur", fournisseur.Adresse_Fournisseur);
            cmd.Parameters.AddWithValue("@Code_Postale_Utilisateur", fournisseur.Code_Postale_Utilisateur);
            cmd.Parameters.AddWithValue("@Ville_Fournisseur", fournisseur.Ville_Fournisseur);
            cmd.Parameters.AddWithValue("@Description_Fournisseur", fournisseur.Description_Fournisseur);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}


