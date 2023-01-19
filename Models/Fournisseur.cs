using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newCubeBackend.FournisseurModel
{
    public class Fournisseur
    {
        public string? Nom_Fournisseur { get; set; }
        public string? Email_Fournisseur { get; set; }
        public string? Telephone_Utilisateur { get; set; }
        public string? Siret_Fournisseur { get; set; }
        public string? Coordonnees_Bancarie_Fournisseur { get; set; }
        public string? Adresse_Fournisseur { get; set; }
        public string? Code_Postale_Utilisateur { get; set; }
        public string? Ville_Fournisseur { get; set; }
        public string? Description_Fournisseur { get; set; }
    }
}