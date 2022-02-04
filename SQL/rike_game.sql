-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 04 fév. 2022 à 09:23
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `rike_game`
--

-- --------------------------------------------------------

--
-- Structure de la table `gamesaves`
--

DROP TABLE IF EXISTS `gamesaves`;
CREATE TABLE IF NOT EXISTS `gamesaves` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `saveId` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `score` decimal(8,2) NOT NULL,
  `lvlclick` decimal(8,2) NOT NULL,
  `lvlauto` decimal(8,2) NOT NULL,
  `seed` int(11) NOT NULL,
  `design` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `gamesaves`
--

INSERT INTO `gamesaves` (`id`, `saveId`, `score`, `lvlclick`, `lvlauto`, `seed`, `design`, `created_at`, `updated_at`) VALUES
(1, 'AZERTY', '15.00', '3.00', '2.00', 75, 'pineA', NULL, NULL),
(2, 'QSDRFG', '0.00', '0.00', '0.00', 42, 'pineA', '2022-02-03 13:42:25', '2022-02-03 13:42:25'),
(3, 'HJKLMN', '0.00', '0.00', '0.00', 42, 'pineA', '2022-02-03 13:43:13', '2022-02-03 13:43:13'),
(4, 'HJKLMN', '0.00', '0.00', '0.00', 42, 'pineA', '2022-02-03 14:16:46', '2022-02-03 14:16:46'),
(5, 'HJKLMN', '0.00', '0.00', '0.00', 42, 'pineA', '2022-02-03 14:18:15', '2022-02-03 14:18:15'),
(23, 'EKY7Z0', '91.00', '0.00', '0.00', 77, NULL, '2022-02-03 21:18:14', '2022-02-03 21:18:14'),
(48, 'PVL3WH', '39.00', '2.00', '2.00', 65, 'pineA,pineB,pineA', '2022-02-04 01:43:17', '2022-02-04 01:43:17'),
(49, '8FITBJ', '37.00', '2.00', '1.00', 41, 'pineA,pineB', '2022-02-04 01:49:39', '2022-02-04 01:49:39'),
(50, 'XMTEBH', '31.00', '2.00', '1.00', 23, 'pineA,pineC', '2022-02-04 05:35:21', '2022-02-04 05:35:21'),
(51, 'ABBXOG', '0.00', '0.00', '0.00', 22, NULL, '2022-02-04 06:05:32', '2022-02-04 06:05:32'),
(52, 'V6YA8W', '13.00', '0.00', '0.00', 51, NULL, '2022-02-04 08:20:44', '2022-02-04 08:20:44'),
(53, 'EQDYHY', '7.00', '1.00', '1.00', 71, 'pineA', '2022-02-04 08:21:19', '2022-02-04 08:21:19');

-- --------------------------------------------------------

--
-- Structure de la table `migrations`
--

DROP TABLE IF EXISTS `migrations`;
CREATE TABLE IF NOT EXISTS `migrations` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2022_02_03_111409_create_gamesaves_table', 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
