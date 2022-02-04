-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 04 fév. 2022 à 10:53
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

CREATE DATABASE IF NOT EXISTS `rike_game`;


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
) ENGINE=MyISAM AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `gamesaves`
--

INSERT INTO `gamesaves` (`id`, `saveId`, `score`, `lvlclick`, `lvlauto`, `seed`, `design`, `created_at`, `updated_at`) VALUES
(1, 'AZERTY', '15.00', '3.00', '2.00', 75, 'pineA', NULL, NULL),
(2, 'QSDRFG', '0.00', '0.00', '0.00', 42, 'pineA', '2022-02-03 13:42:25', '2022-02-03 13:42:25'),
(3, 'HJKLMN', '0.00', '0.00', '0.00', 42, 'pineA', '2022-02-03 13:43:13', '2022-02-03 13:43:13'),
(63, 'QTFAJ8', '2.00', '2.00', '2.00', 19, 'pineA,pineA', '2022-02-04 09:51:02', '2022-02-04 09:51:02'),
(62, 'OD1JVT', '1.00', '1.00', '1.00', 19, 'pineA', '2022-02-04 09:50:33', '2022-02-04 09:50:33'),
(61, 'E6ETAV', '9.00', '1.00', '1.00', 30, 'pineA', '2022-02-04 09:42:23', '2022-02-04 09:42:23'),
(57, 'NVJHXQ', '30.00', '0.00', '0.00', 44, 'pineA,pineB,pineC', '2022-02-04 08:44:46', '2022-02-04 08:44:46');

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
