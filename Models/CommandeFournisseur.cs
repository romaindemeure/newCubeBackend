using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newCubeBackend.CommandeFournisseurModel
{
    public class CommandeFournisseur
    {
        public string? Nombre_Article_CFournisseur { get; set; }
        public string? Numero_Commande_CFournisseur { get; set; }
        public string? Prix_Hors_Taxe_CFournisseur { get; set; }
        public string? Prix_TTC_CFournisseur { get; set; }
        public string? Date_Commande_CFournisseur { get; set; }
        public string? Reduction_CFournisseur { get; set; }
        public string? Cout_Livraison_CFournisseur { get; set; }
    }
}