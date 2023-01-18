using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newCubeBackend.UserModel
{
    public class User
    {
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Mot_de_passe { get; set; }
        public string? Adresse { get; set; }
        public string? Code_postal { get; set; }
        public string? Ville { get; set; }
        public string? Numero_de_telephone { get; set; }
        public bool Admin { get; set; }
    }
}