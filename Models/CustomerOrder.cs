using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newCubeBackend.CustomerOrderModel
{
    public class CustomerOrder
    {
        public string? Nombre_article { get; set; }
        public string? Numero_de_commande { get; set; }
        public string? Prix { get; set; }
        public string? Prix_hors_taxe { get; set; }
        public string? Date_commande { get; set; }
        public string? Reduction { get; set; }
        public string? Cout_livraison { get; set; }
    }
}