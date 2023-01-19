using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newCubeBackend.ArticleModel
{
    public class Article
    {
        public string? Nom_Article { get; set; }
        public string? Annee_Article { get; set; }
        public string? Prix_Unitaire_Article { get; set; }
        public string? Prix_Carton_Article { get; set; }
        public string? Prix_Fournisseur_Article { get; set; }
        public string? Reference_Article { get; set; }
        public string? TVA_Article { get; set; }
        public string? Domaine_Article { get; set; }
        public string? Description_Article { get; set; }
        public string? Famille_Article { get; set; }
        public string? Cout_Stockage_Article { get; set; }
    }
}