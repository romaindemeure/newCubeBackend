using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.CommandeFournisseurModel;

// Définition du nom de l'espace via (namespace).
namespace newCubeBackend.CommandeFournisseurController
{
    // La Route de l'API pointe sur api/Utilisateur.
    [Route("api/CommandeFournisseur")]
    [ApiController]
    // Creéation d'une class enfant UtilisateurController qui hérite de ControllerBase.
    public class CommandeFournisseurController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CommandeFournisseurController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Cette méthod est utilisé pour les requettes HTTP de type Get.
        [HttpGet]
        public String Get()
        {
            // Créer une variable query de type string avec notre requette SQL. Ici nous selectionnont tout de la table tableUtilisateur.
            string query = "SELECT * FROM tableCommandeFournisseur";

            // Créer un objet table avec la méthode new DataTable() de type DataTable.
            DataTable table = new DataTable();
            // Creéer une objet nommé myReader de type MySqlDataReader, cette méthod est utilisé pour plutard.
            MySqlDataReader myReader;
            // Creéer une variable pour la connection nommé conn de type MySqlConnection qui utilise DBConnect.GetDBConnection(). Cette méthode est définie dans ../Controllers/DBConnect.cs
            MySqlConnection conn = DBConnect.GetDBConnection();

            // On ouvre le connecteur définine sur la ligne au dessus pour pouvoir avoir accès a la base de donnée
            conn.Open();

            // Creation de la variable cmd de type MySqlCommand. Elle créer une new MySqlCommand avec les parametres query (C'est la commande SQL pour nous avons définie plutôt) et conn (C'est la connection pour avoir accès a la DB)
            // Pour utiliser MySqlCommand, vous avez besoin d'impoter MySql.Data.MySqlClient; en haut de votre code.
            MySqlCommand cmd = new MySqlCommand(query, conn);

            // Avec myReader utiliser cmd définie plutot pour utilisé ExecuteReader();
            myReader = cmd.ExecuteReader();

            // Avec la variable load charger les donnés qu'il y a dans myReader.
            table.Load(myReader);

            // Avec avoir charger les données dans la variable table nous pouvons fermer le reader et le connecteur avec la méthode Close().
            // Il est important de ne pas oublier de Close() le myReader et conn pour ne pas avoir des bugs sur nos données ou connection.
            myReader.Close();
            conn.Close();

            // Utilisé JsonConvert.SerializeObject() qui viens du module Newtonsoft.Json; avec le paramètre table définie plutôt et Formatting.Indented pour avoir une bonne indentation de pour json
            // Cette méthode sauvegarde un json formaté avec nos données dans une variable de type string.
            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            // Nous retournons le JSON que nous avons créer. Nous ne somme pas obligé de retourner quelques-choses avec la méthode HTTP GET. mais c'est mieux de le faire. 
            return json;
        }


        [HttpGet("{id}")]
        public String GetById(int id)
        {
            string query = "SELECT * FROM tableCommandeFournisseur WHERE IdCommandeFournisseur = @Id";

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
        public JsonResult Post(CommandeFournisseur commandeFournisseur)
        {
            // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
            string query = @"INSERT INTO tableCommandeFournisseur(nombreArticleCFournisseur, numeroCommandeCFournisseur, prixHorsTaxeCFournisseur, prixTTCCFournisseur, dateCommandeCFournisseur, reductionCFournisseur, coutLivraisonCFournisseur) 
                            VALUES (@Nombre_Article_CFournisseur, @Numero_Commande_CFournisseur, @Prix_Hors_Taxe_CFournisseur, @Prix_TTC_CFournisseur, @Date_Commande_CFournisseur, @Reduction_CFournisseur, @Cout_Livraison_CFournisseur)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Nombre_Article_CFournisseur", commandeFournisseur.Nombre_Article_CFournisseur);
            cmd.Parameters.AddWithValue("@Numero_Commande_CFournisseur", commandeFournisseur.Numero_Commande_CFournisseur);
            cmd.Parameters.AddWithValue("@Prix_Hors_Taxe_CFournisseur", commandeFournisseur.Prix_Hors_Taxe_CFournisseur);
            cmd.Parameters.AddWithValue("@Prix_TTC_CFournisseur", commandeFournisseur.Prix_TTC_CFournisseur);
            cmd.Parameters.AddWithValue("@Date_Commande_CFournisseur", commandeFournisseur.Date_Commande_CFournisseur);
            cmd.Parameters.AddWithValue("@Reduction_CFournisseur", commandeFournisseur.Reduction_CFournisseur);
            cmd.Parameters.AddWithValue("@Cout_Livraison_CFournisseur", commandeFournisseur.Cout_Livraison_CFournisseur);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from tableCommandeFournisseur where IdCommandeFournisseur = @Id;";

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
        public JsonResult Put(int id, CommandeFournisseur commandeFournisseur)
        {
            var sql = @"UPDATE tableCommandeFournisseur
                        SET nombreArticleCFournisseur = @Nombre_Article_CFournisseur,  
                        numeroCommandeCFournisseur = @Numero_Commande_CFournisseur, 
                        prixHorsTaxeCFournisseur = @Prix_Hors_Taxe_CFournisseur, 
                        prixTTCCFournisseur = @Prix_TTC_CFournisseur, 
                        dateCommandeCFournisseur = @Date_Commande_CFournisseur, 
                        reductionCFournisseur = @Reduction_CFournisseur, 
                        coutLivraisonCFournisseur = @Cout_Livraison_CFournisseur
                        WHERE IdCommandeFournisseur = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Nombre_Article_CFournisseur", commandeFournisseur.Nombre_Article_CFournisseur);
            cmd.Parameters.AddWithValue("@Numero_Commande_CFournisseur", commandeFournisseur.Numero_Commande_CFournisseur);
            cmd.Parameters.AddWithValue("@Prix_Hors_Taxe_CFournisseur", commandeFournisseur.Prix_Hors_Taxe_CFournisseur);
            cmd.Parameters.AddWithValue("@Prix_TTC_CFournisseur", commandeFournisseur.Prix_TTC_CFournisseur);
            cmd.Parameters.AddWithValue("@Date_Commande_CFournisseur", commandeFournisseur.Date_Commande_CFournisseur);
            cmd.Parameters.AddWithValue("@Reduction_CFournisseur", commandeFournisseur.Reduction_CFournisseur);
            cmd.Parameters.AddWithValue("@Cout_Livraison_CFournisseur", commandeFournisseur.Cout_Livraison_CFournisseur);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}


