using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.UserModel;

// Définition du nom de l'espace via (namespace).
namespace newCubeBackend.UtilisateurController
{
    // La Route de l'API pointe sur api/Utilisateur.
    [Route("api/Utilisateur")]
    [ApiController]
    // Creéation d'une class enfant UtilisateurController qui hérite de ControllerBase.
    public class UtilisateurController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UtilisateurController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Cette méthod est utilisé pour les requettes HTTP de type Get.
        [HttpGet]
        public String Get()
        {
            // Créer une variable query de type string avec notre requette SQL. Ici nous selectionnont tout de la table tableUtilisateur.
            string query = "SELECT * FROM tableUtilisateur";

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
            string query = "SELECT * FROM tableUtilisateur WHERE IdUtilisateur = @Id";

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
            string query = @"INSERT INTO tableUtilisateur(prenomUtilisateur, nomUtilisateur, emailUtilisateur, motDePasseUtilisateur, adresseUtilisateur, codePostaleUtilisateur, villeUtilisateur, telephoneUtilisateur, administrateur) 
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
            string query = @"delete from tableUtilisateur where IdUtilisateur = @Id;";

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
                        SET prenomUtilisateur = @Prenom,  
                        nomUtilisateur = @Nom, 
                        emailUtilisateur = @Email, 
                        motDePasseUtilisateur = @Mot_de_passe, 
                        adresseUtilisateur = @Adresse, 
                        codePostaleUtilisateur = @Code_postal, 
                        villeUtilisateur = @Ville, 
                        telephoneUtilisateur = @Numero_de_telephone 
                        WHERE IdUtilisateur = @Id";

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


