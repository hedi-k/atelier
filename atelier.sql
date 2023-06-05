-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3308
-- Généré le : dim. 21 mai 2023 à 16:00
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
-- Base de données : `atelier`
--

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `idmotif` int NOT NULL,
  `datefin` datetime DEFAULT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `i_fk_absence_motif1` (`idmotif`),
  KEY `i_fk_absence_personnel1` (`idpersonnel`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `idmotif`, `datefin`) VALUES
(1, '2022-06-27 03:55:20', 3, '2022-07-25 04:05:08'),
(6, '2022-06-07 00:23:48', 4, '2022-07-27 22:43:03'),
(10, '2022-06-15 08:18:00', 3, '2022-07-23 20:39:32'),
(5, '2022-06-18 15:13:27', 3, '2022-07-23 06:44:11'),
(3, '2022-05-03 03:25:26', 2, '2022-06-18 06:20:50'),
(10, '2022-05-05 08:18:42', 1, '2022-06-06 10:32:54'),
(1, '2022-05-17 03:38:39', 3, '2022-06-19 10:44:25'),
(5, '2022-05-04 11:03:39', 1, '2022-06-09 18:33:20'),
(4, '2022-05-24 16:29:53', 1, '2022-06-12 04:48:30'),
(2, '2022-05-30 15:56:55', 3, '2022-06-11 04:16:49'),
(6, '2022-05-24 08:02:20', 2, '2022-06-10 11:48:26'),
(7, '2022-05-12 04:32:13', 2, '2022-06-27 22:22:39'),
(8, '2022-05-02 03:53:17', 1, '2022-06-10 03:07:30'),
(9, '2022-05-15 06:38:22', 3, '2022-06-14 18:28:38'),
(8, '2022-04-12 03:00:03', 1, '2022-05-09 14:08:35'),
(5, '2022-04-28 20:02:22', 3, '2022-05-01 23:02:19'),
(10, '2022-04-11 15:15:23', 3, '2022-05-06 01:05:52'),
(9, '2022-04-21 05:37:52', 3, '2022-05-28 16:45:53'),
(2, '2022-04-10 06:28:41', 2, '2022-05-28 04:12:17'),
(3, '2022-04-07 05:34:23', 1, '2022-05-16 05:37:16'),
(6, '2022-04-27 22:24:59', 4, '2022-05-03 06:19:54'),
(4, '2022-04-13 05:34:08', 3, '2022-05-04 09:33:14'),
(1, '2022-04-15 16:12:08', 2, '2022-05-16 11:55:48'),
(7, '2022-04-11 00:14:40', 3, '2022-05-07 03:39:41'),
(1, '2022-03-02 22:09:19', 3, '2022-04-04 04:27:59'),
(10, '2022-03-02 07:57:32', 3, '2022-04-28 22:28:51'),
(8, '2022-03-24 15:09:43', 3, '2022-04-27 18:36:00'),
(7, '2022-03-15 00:42:06', 1, '2022-04-27 08:13:53'),
(9, '2022-03-24 13:10:11', 2, '2022-04-04 20:55:05'),
(6, '2022-03-30 00:31:11', 3, '2022-04-15 11:07:52'),
(5, '2022-03-13 21:41:48', 3, '2022-04-25 19:23:54'),
(4, '2022-03-17 23:10:18', 2, '2022-04-16 15:56:33'),
(2, '2022-03-03 11:01:55', 3, '2022-04-12 06:21:33'),
(3, '2022-03-04 16:09:03', 2, '2022-04-02 17:45:25'),
(8, '2022-01-16 16:03:30', 2, '2022-02-28 16:01:41'),
(3, '2022-01-06 12:18:49', 4, '2022-02-23 19:20:42'),
(7, '2022-01-19 06:19:49', 3, '2022-02-09 12:23:11'),
(6, '2022-01-25 08:46:18', 3, '2022-02-07 01:37:30'),
(5, '2022-01-10 17:56:19', 1, '2022-02-27 06:20:07'),
(1, '2022-01-14 13:00:33', 3, '2022-02-12 10:02:13'),
(9, '2022-01-31 09:39:20', 2, '2022-02-11 17:04:23'),
(10, '2022-01-02 13:00:01', 4, '2022-02-12 09:14:17'),
(4, '2022-01-27 05:05:07', 4, '2022-02-05 11:08:45'),
(2, '2022-01-15 13:17:13', 3, '2022-02-27 15:58:04'),
(3, '2022-06-19 18:32:44', 2, '2022-07-05 10:50:12'),
(2, '2022-06-04 02:08:45', 4, '2022-07-04 10:28:37'),
(7, '2022-06-05 00:13:57', 1, '2022-07-30 16:16:16'),
(8, '2022-06-21 06:27:47', 3, '2022-07-11 20:25:12'),
(9, '2022-06-16 03:50:16', 3, '2022-07-18 23:33:59'),
(4, '2022-06-01 18:04:06', 1, '2022-07-22 08:23:19');

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `idservice` int NOT NULL,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `i_fk_personnel_service1` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `idservice`, `nom`, `prenom`, `tel`, `mail`) VALUES
(1, 3, 'Harding', 'Angelica', '03 41 40 76 23', 'at.velit.pellentesque@protonmail.com'),
(2, 4, 'Eve', 'Hop', '02 51 78 38 56', 'rhoncus@protonmail.edu'),
(3, 2, 'Harding', 'Cecilia', '05 45 12 97 27', 'sociis.natoque.penatibus@protonmail.net'),
(4, 1, 'Brandon', 'Jordan', '01 69 52 18 21', 'dignissim@hotmail.org'),
(5, 3, 'Harding', 'Hall', '03 24 73 59 92', 'amet@yahoo.edu'),
(6, 2, 'Kyla', 'Hope', '08 27 52 46 41', 'aliquet.magna@aol.ca'),
(7, 3, 'Tara', 'Vera', '02 12 53 12 90', 'ut.dolor.dapibus@yahoo.edu'),
(8, 3, 'Todd', 'Wang', '07 82 50 46 13', 'mus@aol.org'),
(9, 3, 'Buckminster', 'Lyle', '03 13 48 70 14', 'arcu.morbi.sit@outlook.com'),
(10, 4, 'Alfonso', 'Amber', '06 55 98 89 21', 'dolor.fusce@google.couk');

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('unNom', '777edbc5df1182bf2e9d22b5c6dca673a9bb5632');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation'),
(3, 'culturelle'),
(4, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
