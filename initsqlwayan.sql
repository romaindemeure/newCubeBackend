CREATE TABLE `utilisateur` (
  `IdUtilisateur` int(11) NOT NULL,
  `nomUtilisateur` varchar(255) NOT NULL,
  `prenomUtilisateur` varchar(255) NOT NULL,
  `emailUtilisateur` varchar(255) NOT NULL,
  `motDePasseUtilisateur` varchar(255) NOT NULL,
  `adresseUtilisateur` varchar(255) NOT NULL,
  `codePostaleUtilisateur` int(5) NOT NULL,
  `villeUtilisateur` varchar(255) NOT NULL,
  `telephoneUtilisateur` int(15) NOT NULL,
  `administrateur` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `commandeclient` (
  `IdCommandeClient` int(11) NOT NULL,
  `nombreArticleCClient` int(255) NOT NULL,
  `numeroCommandeCClient` int(255) NOT NULL,
  `prixHorsTaxeCClient` int(8) NOT NULL,
  `prixTTCCClient` int(8) NOT NULL,
  `dateCommandeCClient` varchar(4) NOT NULL,
  `reductionCClient` int(8) NOT NULL,
  `coutLivraisonCClient` int(8) NOT NULL,
  `idArticleCommendeClient` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `article` (
  `IdArticle` int(11) NOT NULL,
  `nomArticle` varchar(255) NOT NULL,
  `anneeArticle` varchar(4) NOT NULL,
  `prixUnitaireArticle` int(8) NOT NULL,
  `prixCartonArticle` int(8) NOT NULL,
  `prixFournisseurArticle` int(8) NOT NULL,
  `referenceArticle` varchar(30) NOT NULL,
  `tvaArticle` int(4) NOT NULL,
  `domaineArticle` varchar(255) NOT NULL,
  `descriptionArticle` varchar(255) NOT NULL,
  `familleArticle` varchar(255) NOT NULL,
  `coutStockageArticle` int(8) NOT NULL,
  `IdFournisseurCE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `commandefournisseur` (
  `IdCommandeFournisseur` int(11) NOT NULL,
  `nombreArticleCFournisseur` int(255) NOT NULL,
  `numeroCommandeCFournisseur` int(255) NOT NULL,
  `prixHorsTaxeCFournisseur` int(8) NOT NULL,
  `prixTTCCFournisseur` int(8) NOT NULL,
  `dateCommandeCFournisseur` varchar(4) NOT NULL,
  `reductionCFournisseur` int(8) NOT NULL,
  `coutLivraisonCFournisseur` int(8) NOT NULL,
  `idFournisseurCommande` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `fournisseur` (
  `IdFournisseur` int(11) NOT NULL,
  `nomFournisseur` varchar(255) NOT NULL,
  `emailFournisseur` varchar(255) NOT NULL,
  `telephoneFournisseur` int(15) NOT NULL,
  `siretFournisseur` varchar(14) NOT NULL,
  `coordonneesBancaireFournisseur` varchar(34) NOT NULL,
  `adresseFournisseur` varchar(255) NOT NULL,
  `codePostalFournisseur` int(5) NOT NULL,
  `villeFournisseur` varchar(255) NOT NULL,
  `descriptionFournisseur` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;