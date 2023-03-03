-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 03 mars 2023 à 13:47
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
(80, 60),
(81, 60),
(81, 72),
(82, 60),
(84, 60),
(85, 60),
(86, 60),
(88, 60),
(88, 89),
(89, 60);

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
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `film`
--

INSERT INTO `film` (`nofilm`, `titre`, `realisateurs`, `acteurs`, `duree`, `synopsis`, `infofilm`, `imgaffiche`, `nopublic`) VALUES
(2, 'Bienvenue chez les Ch\'tis', 'Dany Boon', 'Dany Boon', '01:46:00', 'Un directeur de la Poste en Provence est, à son détriment, muté à Bergues, petite ville du Nord. Sa famille refusant de l\'accompagner, Philippe ira seul. A sa grande surprise, il découvre un endroit charmant, une équipe chaleureuse et des gens accueillants. Il se lie d\'amitié avec Antoine, le facteur et le carillonneur du village, à la mère possessive et aux amours contrariées.', '3D', 'bvn_chtis.jpg', 10),
(80, 'Les bronzés font du ski', 'Patrice Leconte', 'Michel Blanc, Thierry Lhermitte, Josiane Balasko', '01:30:00', 'La joyeuse troupe d\'amis (plus connu sous le nom des `Bronzés\') se retrouvent aux sports d\'hiver. Les retrouvailles passées, problèmes sentimentaux, mésaventures en altitude et fous rires rythment les vacances des amis pour la vie ! L\'équipe ira même se perdre en montagne.', 'VF, Audiodescription', 'lesbronzes.png', 10),
(81, 'Intouchables', 'Olivier Nakache, Eric Tolédano', 'Omar Sy, François Cluzet, Audrey Fleurot', '01:52:00', 'Tout les oppose et il était peu probable qu\'ils se rencontrent un jour, et pourtant. Philippe, un riche aristocrate devenu tétraplégique après un accident de parapente va engager Driss, un jeune homme d\'origine sénégalaise tout droit sorti de prison, comme auxiliaire de vie à domicile. Pourquoi lui ? Tout simplement parce qu\'il ne regarde pas Philippe avec le même regard de pitié que les autres candidats.', 'VF, Audiodescription', 'intouchables.png', 10),
(82, 'Les Visiteurs', 'Jean-Marie Poiré', 'Jean Reno, Christian Clavier', '01:47:00', 'Le comte de Montmirail et son fidèle écuyer, Jacquouille, sont projetés dans le futur. Ils rencontrent Béatrice, descendante de Montmirail, qui leur explique comment sauver leur château.', 'VF, Audiodescription', 'lesvisiteurs.png', 10),
(84, 'Le dîner de cons', 'Francis Veber', 'Thierry Lhermitte, Jacques Villeret', '01:20:00', 'Tous les mercredis, Pierre Brochant et ses amis organisent un dîner où chacun doit amener un \"con\". Un soir, Brochant rencontre François Pignon, un comptable qui va devenir son \"con\" attitré.', 'VF, Audiodescription', 'ledinerdecons.png', 10),
(85, 'La grande vadrouille', 'Gérard Oury', 'Louis de Funès, Bourvil', '02:12:00', 'Pendant la Seconde Guerre mondiale, un avion anglais est abattu au-dessus de Paris. Deux pilotes, un Français et un Anglais, tombent en parachute dans la ville occupée. Ils sont aidés par deux civils français pour échapper aux nazis.', 'VF, Audiodescription', 'lagrandevadrouille.png', 10),
(86, 'Les aventures de Rabbi Jacob', 'Gérard Oury', 'Louis de Funès, Claude Giraud, Suzy Delair', '01:40:00', 'Un homme d\'affaires raciste se retrouve pris au piège d\'une situation délicate lorsqu\'il est confondu avec un rabbin par des membres de la communauté juive. Il est alors entraîné dans une folle aventure pour éviter d\'être découvert.', 'VF, Audiodescription', 'rabbijacob.png', 10),
(88, 'Les Compères', 'Francis Veber', 'Gérard Depardieu, Pierre Richard', '01:32:00', ' Jean Lucas, un homme d\'affaires, apprend qu\'il a une fille de 17 ans qu\'il n\'a jamais connue. Lorsqu\'elle disparaît, il se tourne vers son ami d\'enfance, François Pignon, pour l\'aider à la retrouver. Mais les choses se compliquent lorsque la police s\'implique et que les deux hommes se retrouvent impliqués dans une affaire de kidnapping.', 'VF, Audiodescription', 'lescomperes.png', 10),
(89, 'Oscar', 'Edouard Molinaro', 'Louis de Funès, Claude Rich', '01:25:00', 'Bertrand, un riche promoteur, mène une vie paisible. Jusqu\'au jour où son homme de confiance, Christian, le fait chanter pour doubler son salaire et obtenir la main de sa fille, dont il est l\'amant. Il lui avoue également qu\'il le vole depuis de nombreuses années. Les choses se compliquent encore quand la maîtresse de Christian se révèle finalement ne pas être Colette, la fille de Bertrand, mais qu\'en revanche, Colette s\'avère être enceinte d\'Oscar, le chauffeur.', 'VF, Audiodescription', 'oscar.png', 10);

-- --------------------------------------------------------

--
-- Structure de la table `genre`
--

DROP TABLE IF EXISTS `genre`;
CREATE TABLE IF NOT EXISTS `genre` (
  `nogenre` int NOT NULL AUTO_INCREMENT,
  `libgenre` varchar(30) NOT NULL,
  PRIMARY KEY (`nogenre`)
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `projection`
--

INSERT INTO `projection` (`noproj`, `dateproj`, `heureproj`, `infoproj`, `nofilm`, `nosalle`) VALUES
(19, '2023-03-16', '10:15:00', 'Version Française', 84, 'B'),
(27, '2023-03-16', '12:00:00', 'Version Française', 86, 'A'),
(28, '2023-03-16', '14:00:00', 'Version Française', 88, 'A'),
(29, '2023-03-16', '16:15:00', 'Version Française', 89, 'A'),
(30, '2023-03-18', '11:15:00', 'Version Française', 80, 'G'),
(31, '2023-03-18', '11:15:00', 'Version Française', 2, 'E'),
(32, '2023-03-18', '14:15:00', 'Version Française', 82, 'E'),
(33, '2023-03-17', '14:15:00', 'Version Française', 85, 'B'),
(34, '2023-03-17', '16:15:00', 'Version Française', 88, 'H'),
(35, '2023-03-17', '18:15:00', 'Version Française', 89, 'H'),
(36, '2023-03-19', '11:15:00', 'Version Originale (ch\'ti) + 3D', 2, 'J'),
(37, '2023-03-19', '13:15:00', 'Version Espagnole', 81, 'K'),
(38, '2023-03-19', '13:30:00', '3D', 88, 'I'),
(39, '2023-03-19', '13:30:00', 'Audiodescription', 85, 'J'),
(40, '2023-03-17', '15:30:00', 'Audiodescription', 81, 'D'),
(41, '2023-03-18', '17:30:00', 'Audiodescription', 80, 'F'),
(42, '2023-03-20', '19:30:00', 'Version Québecoise', 82, 'A'),
(43, '2023-03-20', '17:30:00', 'Version Française', 86, 'C'),
(44, '2023-03-21', '15:30:00', 'Version Française', 84, 'H'),
(45, '2023-03-21', '17:30:00', 'Version Française', 84, 'J');

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
('J', 100),
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
