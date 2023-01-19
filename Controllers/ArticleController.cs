using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.ArticleModel;


// Define name of space. 
namespace newCubeBackend.ArticleController
{
    // method Route it's the link of API endpoint.
    [Route("api/Article")]
    [ApiController]
    // Creating a child class ArticleController of ControllerBase
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method it's used for requests HTTP of type Get.
        [HttpGet]
        public String Get()
        {
            // Create query in string with SQL command inside.
            string query = "SELECT * FROM tableArticle";

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
            string query = "SELECT * FROM tableArticle WHERE IdArticle = @Id";

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
        public JsonResult Post(Article article)
        {
            // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
            string query = @"INSERT INTO tableArticle(nomArticle, anneeArticle, prixUnitaireArticle, prixCartonArticle, prixFournisseurArticle, referenceArticle, tvaArticle, domaineArticle, descriptionArticle, familleArticle, coutStockageArticle) 
                            VALUES (@Nom_Article, @Annee_Article, @Prix_Unitaire_Article, @Prix_Carton_Article, @Prix_Fournisseur_Article, @Reference_Article, @TVA_Article, @Domaine_Article, @Description_Article, @Famille_Article, @Cout_Stockage_Article)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Nom_Article", article.Nom_Article);
            cmd.Parameters.AddWithValue("@Annee_Article", article.Annee_Article);
            cmd.Parameters.AddWithValue("@Prix_Unitaire_Article", article.Prix_Unitaire_Article);
            cmd.Parameters.AddWithValue("@Prix_Carton_Article", article.Prix_Carton_Article);
            cmd.Parameters.AddWithValue("@Prix_Fournisseur_Article", article.Prix_Fournisseur_Article);
            cmd.Parameters.AddWithValue("@Reference_Article", article.Reference_Article);
            cmd.Parameters.AddWithValue("@TVA_Article", article.TVA_Article);
            cmd.Parameters.AddWithValue("@Domaine_Article", article.Domaine_Article);
            cmd.Parameters.AddWithValue("@Description_Article", article.Description_Article);
            cmd.Parameters.AddWithValue("@Famille_Article", article.Famille_Article);
            cmd.Parameters.AddWithValue("@Cout_Stockage_Article", article.Cout_Stockage_Article);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from tableArticle where IdArticle = @Id;";

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
        public JsonResult Put(int id, Article article)
        {
            var sql = @"UPDATE tableArticle
                        SET nomArticle = @Nom_Article,  
                        anneeArticle = @Annee_Article, 
                        prixUnitaireArticle = @Prix_Unitaire_Article, 
                        prixCartonArticle = @Prix_Carton_Article, 
                        prixFournisseurArticle = @Prix_Fournisseur_Article, 
                        referenceArticle = @Reference_Article, 
                        tvaArticle = @TVA_Article, 
                        domaineArticle = @Domaine_Article,
                        descriptionArticle = @Description_Article,
                        familleArticle = @Famille_Article,
                        coutStockageArticle = @Cout_Stockage_Article
                        WHERE IdArticle = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nom_Article", article.Nom_Article);
            cmd.Parameters.AddWithValue("@Annee_Article", article.Annee_Article);
            cmd.Parameters.AddWithValue("@Prix_Unitaire_Article", article.Prix_Unitaire_Article);
            cmd.Parameters.AddWithValue("@Prix_Carton_Article", article.Prix_Carton_Article);
            cmd.Parameters.AddWithValue("@Prix_Fournisseur_Article", article.Prix_Fournisseur_Article);
            cmd.Parameters.AddWithValue("@Reference_Article", article.Reference_Article);
            cmd.Parameters.AddWithValue("@TVA_Article", article.TVA_Article);
            cmd.Parameters.AddWithValue("@Domaine_Article", article.Domaine_Article);
            cmd.Parameters.AddWithValue("@Description_Article", article.Description_Article);
            cmd.Parameters.AddWithValue("@Famille_Article", article.Famille_Article);
            cmd.Parameters.AddWithValue("@Cout_Stockage_Article", article.Cout_Stockage_Article);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}