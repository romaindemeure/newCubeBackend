-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mer. 21 déc. 2022 à 10:08
-- Version du serveur : 10.4.22-MariaDB
-- Version de PHP : 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `cube1`
--

-- --------------------------------------------------------

--
-- Structure de la table `article`
--

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

--
-- Déchargement des données de la table `article`
--

INSERT INTO `article` (`IdArticle`, `nomArticle`, `anneeArticle`, `prixUnitaireArticle`, `prixCartonArticle`, `prixFournisseurArticle`, `referenceArticle`, `tvaArticle`, `domaineArticle`, `descriptionArticle`, `familleArticle`, `coutStockageArticle`, `IdFournisseurCE`) VALUES
(1, 'Vin1', '2000', 12, 48, 5, 'rf10002000', 10, 'Brest métropole', 'UN très bon vin qui facilite les résultats en musculation', 'rouge', 0, 1),
(2, 'Vin2', '2000', 12, 48, 5, 'rf10022000', 10, 'Brest métropole', 'UN très bon vin qui facilite les résultats en musculation', 'rouge', 0, 1),
(3, 'Vin3', '2000', 12, 48, 5, 'rf10032000', 10, 'Brest métropole', 'UN très bon vin qui facilite les résultats en musculation', 'rouge', 0, 1),
(4, 'Vin4', '2000', 12, 48, 5, 'rf10042000', 10, 'Brest métropole', 'UN très bon vin qui facilite les résultats en musculation', 'rouge', 0, 1),
(5, 'Vin5', '2000', 12, 48, 5, 'rf10052000', 10, 'Brest métropole', 'UN très bon vin qui facilite les résultats en musculation', 'rouge', 0, 1);

-- --------------------------------------------------------

--
-- Structure de la table `commandeclient`
--

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

-- --------------------------------------------------------

--
-- Structure de la table `commandefournisseur`
--

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

-- --------------------------------------------------------

--
-- Structure de la table `fournisseur`
--

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

--
-- Déchargement des données de la table `fournisseur`
--

INSERT INTO `fournisseur` (`IdFournisseur`, `nomFournisseur`, `emailFournisseur`, `telephoneFournisseur`, `siretFournisseur`, `coordonneesBancaireFournisseur`, `adresseFournisseur`, `codePostalFournisseur`, `villeFournisseur`, `descriptionFournisseur`) VALUES
(1, 'David', 'david.lansonneur@viacesi.fr', 645806524, '43318512100129', '8564485824863624785245485', '20 rue rolang garos', 29200, 'Brest', 'très beau et fait du bon vin');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

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

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`IdUtilisateur`, `nomUtilisateur`, `prenomUtilisateur`, `emailUtilisateur`, `motDePasseUtilisateur`, `adresseUtilisateur`, `codePostaleUtilisateur`, `villeUtilisateur`, `telephoneUtilisateur`, `administrateur`) VALUES
(1, 'a', 'a', 'a', 'a', 'a', 29200, 'a', 0, 1),
(2, 'savary', 'wayan', 'wayan.savary@gmail.com', 'wayan', 'wayan', 29200, 'wayan', 0, 0);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`IdArticle`),
  ADD KEY `idFournisseurCE` (`IdFournisseurCE`);

--
-- Index pour la table `commandeclient`
--
ALTER TABLE `commandeclient`
  ADD PRIMARY KEY (`IdCommandeClient`),
  ADD KEY `idArticleCommendeClient` (`idArticleCommendeClient`);

--
-- Index pour la table `commandefournisseur`
--
ALTER TABLE `commandefournisseur`
  ADD PRIMARY KEY (`IdCommandeFournisseur`),
  ADD KEY `idFournisseurCommande` (`idFournisseurCommande`);

--
-- Index pour la table `fournisseur`
--
ALTER TABLE `fournisseur`
  ADD PRIMARY KEY (`IdFournisseur`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`IdUtilisateur`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `article`
--
ALTER TABLE `article`
  MODIFY `IdArticle` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `commandeclient`
--
ALTER TABLE `commandeclient`
  MODIFY `IdCommandeClient` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `commandefournisseur`
--
ALTER TABLE `commandefournisseur`
  MODIFY `IdCommandeFournisseur` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `fournisseur`
--
ALTER TABLE `fournisseur`
  MODIFY `IdFournisseur` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  MODIFY `IdUtilisateur` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `article`
--
ALTER TABLE `article`
  ADD CONSTRAINT `idFournisseurCE` FOREIGN KEY (`IdFournisseurCE`) REFERENCES `fournisseur` (`IdFournisseur`);

--
-- Contraintes pour la table `commandeclient`
--
ALTER TABLE `commandeclient`
  ADD CONSTRAINT `idArticleCommendeClient` FOREIGN KEY (`idArticleCommendeClient`) REFERENCES `article` (`IdArticle`);

--
-- Contraintes pour la table `commandefournisseur`
--
ALTER TABLE `commandefournisseur`
  ADD CONSTRAINT `idFournisseurCommande` FOREIGN KEY (`idFournisseurCommande`) REFERENCES `fournisseur` (`IdFournisseur`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
