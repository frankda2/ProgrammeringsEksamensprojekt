-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Vært: 127.0.0.1
-- Genereringstid: 07. 06 2020 kl. 19:11:09
-- Serverversion: 10.1.38-MariaDB
-- PHP-version: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `whm_data`
--
CREATE DATABASE IF NOT EXISTS `whm_data` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin;
USE `whm_data`;

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `items`
--

CREATE TABLE `items` (
  `item_id` int(11) NOT NULL,
  `item_no` varchar(64) COLLATE utf8_bin NOT NULL,
  `item_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `Stock` int(11) NOT NULL DEFAULT '0',
  `location_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Data dump for tabellen `items`
--

INSERT INTO `items` (`item_id`, `item_no`, `item_name`, `Stock`, `location_id`) VALUES
(0, '12345678', 'Blyant', 0, 1),
(1, '87654321', 'Lineal', 0, 2),
(3, '1-1-2-3-5-8-13', 'Vinglas', 0, 6),
(4, '3-141592', 'Musemåtte 20x30 cm', 0, 9),
(5, 'A1B2C3', 'Chokoladekiks', 8, 8),
(14, 'HPQ42PKC', 'PZ2 Bit', 72, 12),
(15, 'KLM5784354', 'Steam controller', 1, 18),
(20, 'M1911V3', 'Colt M1911', 2, 20);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `locations`
--

CREATE TABLE `locations` (
  `location_id` int(11) NOT NULL,
  `location_name` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Data dump for tabellen `locations`
--

INSERT INTO `locations` (`location_id`, `location_name`) VALUES
(1, 'A.1'),
(2, 'A.2'),
(3, 'A.3'),
(4, 'A.4'),
(5, 'A.5'),
(6, 'B.1'),
(7, 'B.2'),
(8, 'B.3'),
(9, 'B.4'),
(10, 'B.5'),
(11, 'C.1'),
(12, 'C.2'),
(18, 'Loftet'),
(19, 'A.3\0'),
(20, 'E.47'),
(21, 'I.54');

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`item_id`),
  ADD KEY `lokations_id` (`location_id`);

--
-- Indeks for tabel `locations`
--
ALTER TABLE `locations`
  ADD PRIMARY KEY (`location_id`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `items`
--
ALTER TABLE `items`
  MODIFY `item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Tilføj AUTO_INCREMENT i tabel `locations`
--
ALTER TABLE `locations`
  MODIFY `location_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Begrænsninger for tabel `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`location_id`) REFERENCES `locations` (`location_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
