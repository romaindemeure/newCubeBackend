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


CREATE TABLE tableCommandeClient (
  IdCommandeClient int AUTO_INCREMENT,
  nombreArticleCClient varchar(255) NOT NULL,
  numeroCommandeCClient varchar(255) NOT NULL,
  prixTTCClient varchar(255) NOT NULL,
  prixHorsTaxeCClient varchar(255) NOT NULL,
  dateCommandeCClient varchar(255) NOT NULL,
  reductionCClient varchar(255) NOT NULL,
  coutLivraisonCClient varchar(255) NOT NULL,
  -- IdUtilisateur INT,
  -- FOREIGN KEY (IdUtilisateur) REFERENCES tableUtilisateur (IdUtilisateur),
  PRIMARY KEY(IdCommandeClient)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tableArticle (
  IdArticle int AUTO_INCREMENT,
  nomArticle varchar(255) NOT NULL,
  anneeArticle varchar(255) NOT NULL,
  prixUnitaireArticle varchar(255) NOT NULL,
  prixCartonArticle varchar(255) NOT NULL,
  prixFournisseurArticle varchar(255) NOT NULL,
  referenceArticle varchar(255) NOT NULL,
  tvaArticle varchar(255) NOT NULL,
  domaineArticle varchar(255) NOT NULL,
  descriptionArticle varchar(255) NOT NULL,
  familleArticle varchar(255) NOT NULL,
  coutStockageArticle varchar(255) NOT NULL,
  PRIMARY KEY(IdArticle)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tableFournisseur (
  IdFournisseur int AUTO_INCREMENT,
  nomFournisseur varchar(255) NOT NULL,
  emailFournisseur varchar(255) NOT NULL,
  telephoneUtilisateur varchar(255) NOT NULL,
  siretFournisseur varchar(255) NOT NULL,
  coordonneesBancarieFournisseur varchar(255) NOT NULL,
  adresseFournisseur varchar(255) NOT NULL,
  codePostaleUtilisateur varchar(255) NOT NULL,
  villeFournisseur varchar(255) NOT NULL,
  descriptionFournisseur varchar(255) NOT NULL,
  PRIMARY KEY(IdFournisseur)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE commandefournisseur (
  IdCommandeFournisseur int AUTO_INCREMENT,
  nombreArticleCFournisseur varchar(255) NOT NULL,
  numeroCommandeCFournisseur varchar(255) NOT NULL,
  prixHorsTaxeCFournisseur varchar(255) NOT NULL,
  prixTTCCFournisseur varchar(255) NOT NULL,
  dateCommandeCFournisseur varchar(255) NOT NULL,
  reductionCFournisseur varchar(255) NOT NULL,
  coutLivraisonCFournisseur varchar(255) NOT NULL,
  idFournisseurCommande varchar(255) NOT NULL
  PRIMARY KEY(IdCommandeFournisseur)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;