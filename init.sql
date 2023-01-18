CREATE TABLE tableUtilisateur (
  IdUtilisateur int AUTO_INCREMENT,
  prenomUtilisateur varchar(255) NOT NULL,
  nomUtilisateur varchar(255) NOT NULL,
  emailUtilisateur varchar(255) NOT NULL,
  motDePasseUtilisateur varchar(255) NOT NULL,
  adresseUtilisateur varchar(255) NOT NULL,
  codePostaleUtilisateur varchar(255) NOT NULL,
  villeUtilisateur varchar(255) NOT NULL,
  telephoneUtilisateur varchar(255) NOT NULL,
  administrateur tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY(IdUtilisateur)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE commandeClient (
  IdCommandeClient int AUTO_INCREMENT,
  nombreArticleCClient varchar(255) NOT NULL,
  numeroCommandeCClient varchar(255) NOT NULL,
  prixTTCCClient varchar(255) NOT NULL,
  prixHorsTaxeCClient varchar(255) NOT NULL,
  dateCommandeCClient varchar(255) NOT NULL,
  reductionCClient varchar(255) NOT NULL,
  coutLivraisonCClient varchar(255) NOT NULL,
  IdUtilisateur INT,
  FOREIGN KEY (IdUtilisateur) REFERENCES tableUtilisateur (IdUtilisateur),
  PRIMARY KEY(IdCommandeClient)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
