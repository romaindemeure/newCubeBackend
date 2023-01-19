using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.FournisseurModel;

// Définition du nom de l'espace via (namespace).
namespace newCubeBackend.FournisseurController
{
    // La Route de l'API pointe sur api/Utilisateur.
    [Route("api/Fournisseur")]
    [ApiController]
    // Creéation d'une class enfant UtilisateurController qui hérite de ControllerBase.
    public class FournisseurController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FournisseurController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Cette méthod est utilisé pour les requettes HTTP de type Get.
        [HttpGet]
        public String Get()
        {
            // Créer une variable query de type string avec notre requette SQL. Ici nous selectionnont tout de la table tableUtilisateur.
            string query = "SELECT * FROM tableFournisseur";

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


