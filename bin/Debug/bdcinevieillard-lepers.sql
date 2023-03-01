-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 28 fév. 2023 à 23:00
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bdcinevieillard-lepers`
--

-- --------------------------------------------------------

--
-- Structure de la table `concerner`
--

DROP TABLE IF EXISTS `concerner`;
CREATE TABLE IF NOT EXISTS `concerner` (
  `nofilm` int NOT NULL,
  `nogenre` int NOT NULL,
  PRIMARY KEY (`nofilm`,`nogenre`),
  KEY `fk_nofilm` (`nofilm`),
  KEY `fk_nogenre` (`nogenre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `concerner`
--

INSERT INTO `concerner` (`nofilm`, `nogenre`) VALUES
(2, 51),
(88, 51),
(88, 56),
(88, 60),
(88, 75),
(88, 77);

-- --------------------------------------------------------

--
-- Structure de la table `film`
--

DROP TABLE IF EXISTS `film`;
CREATE TABLE IF NOT EXISTS `film` (
  `nofilm` int NOT NULL AUTO_INCREMENT,
  `titre` varchar(100) NOT NULL,
  `realisateurs` varchar(255) NOT NULL,
  `acteurs` varchar(255) NOT NULL,
  `duree` time NOT NULL,
  `synopsis` text NOT NULL,
  `infofilm` text NOT NULL,
  `imgaffiche` varchar(100) NOT NULL,
  `nopublic` int NOT NULL,
  PRIMARY KEY (`nofilm`),
  KEY `nopublic` (`nopublic`)
) ENGINE=InnoDB AUTO_INCREMENT=118 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `film`
--

INSERT INTO `film` (`nofilm`, `titre`, `realisateurs`, `acteurs`, `duree`, `synopsis`, `infofilm`, `imgaffiche`, `nopublic`) VALUES
(2, 'Bienvenue chez les Ch\'tis', 'Dany Boon', 'Dany Boon', '01:46:00', 'Un directeur de la Poste en Provence est, à son détriment, muté à Bergues, petite ville du Nord. Sa famille refusant de l\'accompagner, Philippe ira seul. A sa grande surprise, il découvre un endroit charmant, une équipe chaleureuse et des gens accueillants. Il se lie d\'amitié avec Antoine, le facteur et le carillonneur du village, à la mère possessive et aux amours contrariées.', '3D', 'bvn_chtis.jpg', 10),
(88, 'Ça serait marant', 'Tom VG', 'Théo Chagrin', '01:30:00', 'Y a des voitures et des couteaux.', 'Oscar du meilleur film', 'Economisez argent.png', 11),
(117, 'test', 'test', 'test', '01:00:00', 'test', 'test', 'noimg.png', 11);

-- --------------------------------------------------------

--
-- Structure de la table `genre`
--

DROP TABLE IF EXISTS `genre`;
CREATE TABLE IF NOT EXISTS `genre` (
  `nogenre` int NOT NULL AUTO_INCREMENT,
  `libgenre` varchar(30) NOT NULL,
  PRIMARY KEY (`nogenre`)
) ENGINE=InnoDB AUTO_INCREMENT=147 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `genre`
--

INSERT INTO `genre` (`nogenre`, `libgenre`) VALUES
(51, 'Action'),
(52, 'Animation'),
(53, 'Arts Martiaux'),
(56, 'Aventure'),
(57, 'Biopic'),
(58, 'Bollywood'),
(59, 'Classique'),
(60, 'Comédie'),
(61, 'Comédie dramatique'),
(62, 'Comédie musicale'),
(63, 'Concert'),
(64, 'Dessin animé'),
(65, 'Divers'),
(70, 'Documentaire'),
(71, 'Drama'),
(72, 'Drame'),
(73, 'Epouvante-horreur'),
(74, 'Erotique'),
(75, 'Espionnage'),
(76, 'Expérimental'),
(77, 'Famille'),
(78, 'Fantastique'),
(79, 'Guerre'),
(83, 'Historique'),
(84, 'Judiciaire'),
(85, 'Movie night'),
(86, 'Musical'),
(87, 'Opera'),
(88, 'Péplum'),
(89, 'Policier'),
(90, 'Romance'),
(91, 'Science fiction'),
(92, 'Show'),
(99, 'Sport event'),
(100, 'Thriller'),
(102, 'Western');

-- --------------------------------------------------------

--
-- Structure de la table `projection`
--

DROP TABLE IF EXISTS `projection`;
CREATE TABLE IF NOT EXISTS `projection` (
  `noproj` int NOT NULL AUTO_INCREMENT,
  `dateproj` date NOT NULL,
  `heureproj` time NOT NULL,
  `infoproj` text CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `nofilm` int NOT NULL,
  `nosalle` varchar(3) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`noproj`),
  KEY `fk_nosalle` (`nosalle`),
  KEY `nofilm` (`nofilm`)
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `projection`
--

INSERT INTO `projection` (`noproj`, `dateproj`, `heureproj`, `infoproj`, `nofilm`, `nosalle`) VALUES
(84, '2023-03-01', '10:00:00', 'VF', 2, 'A'),
(85, '2023-03-01', '10:30:00', 'VF', 2, 'B'),
(86, '2023-03-01', '10:30:00', 'VOSTFR', 88, 'C'),
(88, '2023-03-01', '10:15:00', '3D', 2, 'E');

-- --------------------------------------------------------

--
-- Structure de la table `public`
--

DROP TABLE IF EXISTS `public`;
CREATE TABLE IF NOT EXISTS `public` (
  `nopublic` int NOT NULL AUTO_INCREMENT,
  `libpublic` varchar(50) NOT NULL,
  PRIMARY KEY (`nopublic`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `public`
--

INSERT INTO `public` (`nopublic`, `libpublic`) VALUES
(10, 'Tous publics'),
(11, 'Tous publics avec Avertissement'),
(12, 'Interdit au moins de 12 ans'),
(13, 'Interdit aux moins de 12 ans avec Avertissement'),
(15, 'Interdit aux moins de 16 ans'),
(16, 'Interdit aux moins de 16 ans avec Avertissement'),
(20, 'Interdit aux moins de 18 ans');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
CREATE TABLE IF NOT EXISTS `reservation` (
  `noresa` int NOT NULL AUTO_INCREMENT,
  `mdpresa` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `dateresa` datetime NOT NULL,
  `nomclient` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `nbplacesresa` int NOT NULL,
  `noproj` int NOT NULL,
  PRIMARY KEY (`noresa`),
  KEY `fk_noproj` (`noproj`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `salle`
--

DROP TABLE IF EXISTS `salle`;
CREATE TABLE IF NOT EXISTS `salle` (
  `nosalle` varchar(1) NOT NULL,
  `nbplaces` int NOT NULL,
  PRIMARY KEY (`nosalle`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `salle`
--

INSERT INTO `salle` (`nosalle`, `nbplaces`) VALUES
('A', 400),
('B', 400),
('C', 400),
('D', 300),
('E', 300),
('F', 300),
('G', 200),
('H', 200),
('I', 100),
('K', 100);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `concerner`
--
ALTER TABLE `concerner`
  ADD CONSTRAINT `concerner_ibfk_1` FOREIGN KEY (`nofilm`) REFERENCES `film` (`nofilm`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `concerner_ibfk_2` FOREIGN KEY (`nogenre`) REFERENCES `genre` (`nogenre`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Contraintes pour la table `film`
--
ALTER TABLE `film`
  ADD CONSTRAINT `film_ibfk_1` FOREIGN KEY (`nopublic`) REFERENCES `public` (`nopublic`) ON UPDATE CASCADE;

--
-- Contraintes pour la table `projection`
--
ALTER TABLE `projection`
  ADD CONSTRAINT `projection_ibfk_1` FOREIGN KEY (`nofilm`) REFERENCES `film` (`nofilm`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `projection_ibfk_2` FOREIGN KEY (`nosalle`) REFERENCES `salle` (`nosalle`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Contraintes pour la table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`noproj`) REFERENCES `projection` (`noproj`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
