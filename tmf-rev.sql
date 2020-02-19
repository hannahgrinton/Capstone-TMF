-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 18, 2020 at 10:43 PM
-- Server version: 8.0.18
-- PHP Version: 7.2.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tmf-rev`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `addressId` int(11) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `city` varchar(50) NOT NULL,
  `province` varchar(2) NOT NULL DEFAULT 'NS',
  `postal` varchar(7) NOT NULL,
  `country` varchar(20) NOT NULL DEFAULT 'Canada',
  `type` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`addressId`, `firstname`, `lastname`, `address`, `city`, `province`, `postal`, `country`, `type`) VALUES
(1, 'frankie', 'howler', '382 sunmount', 'heretown', 'NS', 's9a7d8', 'Canada', 'business');

-- --------------------------------------------------------

--
-- Table structure for table `addressrels`
--

CREATE TABLE `addressrels` (
  `relationId` int(11) NOT NULL,
  `type` varchar(10) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `addressId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `advertisement`
--

CREATE TABLE `advertisement` (
  `adId` int(11) NOT NULL,
  `date` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL,
  `imgFile` varchar(50) DEFAULT NULL,
  `adSize` varchar(100) NOT NULL,
  `cost` float NOT NULL,
  `paid` float DEFAULT NULL,
  `due` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `advertisement`
--

INSERT INTO `advertisement` (`adId`, `date`, `notes`, `imgFile`, `adSize`, `cost`, `paid`, `due`) VALUES
(1, '2020-02-19', 'take note of this', 'thisImg.png', '200 x 300', 12, 2, 10);

-- --------------------------------------------------------

--
-- Table structure for table `advertrels`
--

CREATE TABLE `advertrels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `adId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `awards`
--

CREATE TABLE `awards` (
  `awardId` int(11) NOT NULL,
  `recipient` varchar(10) DEFAULT NULL,
  `year` varchar(4) DEFAULT NULL,
  `fundId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `awards`
--

INSERT INTO `awards` (`awardId`, `recipient`, `year`, `fundId`) VALUES
(1, 'jam', '2019', 1);

-- --------------------------------------------------------

--
-- Table structure for table `donation`
--

CREATE TABLE `donation` (
  `donId` int(11) NOT NULL,
  `date` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL,
  `receipt` tinyint(1) NOT NULL DEFAULT '0',
  `amount` float NOT NULL,
  `fundId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `donation`
--

INSERT INTO `donation` (`donId`, `date`, `notes`, `receipt`, `amount`, `fundId`) VALUES
(1, '2020-02-19', 'this was donated', 0, 23500, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `donrels`
--

CREATE TABLE `donrels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `donId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `fund`
--

CREATE TABLE `fund` (
  `fundId` int(11) NOT NULL,
  `fundName` varchar(50) NOT NULL,
  `creator` varchar(100) DEFAULT NULL,
  `dateCreated` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `fund`
--

INSERT INTO `fund` (`fundId`, `fundName`, `creator`, `dateCreated`, `notes`) VALUES
(1, 'DreamingBabies', 'jam', '2020-02-05', 'many');

-- --------------------------------------------------------

--
-- Table structure for table `sponsor`
--

CREATE TABLE `sponsor` (
  `sponsorId` int(11) NOT NULL,
  `Company` varchar(128) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `phone` varchar(14) NOT NULL,
  `fax` varchar(14) DEFAULT NULL,
  `email` varchar(70) DEFAULT NULL,
  `activity` varchar(10) NOT NULL DEFAULT 'active',
  `notes` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `sponsor`
--

INSERT INTO `sponsor` (`sponsorId`, `Company`, `firstname`, `lastname`, `phone`, `fax`, `email`, `activity`, `notes`) VALUES
(1, 'MeCorp', 'Iri', 'Descent', '8384849392', '3456234567', 'jam@baby.net', 'active', 'read me, Im important!'),
(2, 'MeCorp', 'Iri', 'Descent', '8384849392', '3456234567', 'jam@baby.net', 'active', 'read me, Im important!');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`addressId`);

--
-- Indexes for table `addressrels`
--
ALTER TABLE `addressrels`
  ADD PRIMARY KEY (`relationId`),
  ADD KEY `sponsorId` (`sponsorId`),
  ADD KEY `addressId` (`addressId`);

--
-- Indexes for table `advertisement`
--
ALTER TABLE `advertisement`
  ADD PRIMARY KEY (`adId`);

--
-- Indexes for table `advertrels`
--
ALTER TABLE `advertrels`
  ADD PRIMARY KEY (`relationId`),
  ADD KEY `sponsorId` (`sponsorId`),
  ADD KEY `adId` (`adId`);

--
-- Indexes for table `awards`
--
ALTER TABLE `awards`
  ADD PRIMARY KEY (`awardId`),
  ADD KEY `fundId` (`fundId`);

--
-- Indexes for table `donation`
--
ALTER TABLE `donation`
  ADD PRIMARY KEY (`donId`),
  ADD KEY `fundId` (`fundId`);

--
-- Indexes for table `donrels`
--
ALTER TABLE `donrels`
  ADD PRIMARY KEY (`relationId`),
  ADD KEY `sponsorId` (`sponsorId`),
  ADD KEY `donId` (`donId`);

--
-- Indexes for table `fund`
--
ALTER TABLE `fund`
  ADD PRIMARY KEY (`fundId`);

--
-- Indexes for table `sponsor`
--
ALTER TABLE `sponsor`
  ADD PRIMARY KEY (`sponsorId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `addressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `addressrels`
--
ALTER TABLE `addressrels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `advertisement`
--
ALTER TABLE `advertisement`
  MODIFY `adId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `advertrels`
--
ALTER TABLE `advertrels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `awards`
--
ALTER TABLE `awards`
  MODIFY `awardId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `donation`
--
ALTER TABLE `donation`
  MODIFY `donId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `donrels`
--
ALTER TABLE `donrels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `fund`
--
ALTER TABLE `fund`
  MODIFY `fundId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sponsor`
--
ALTER TABLE `sponsor`
  MODIFY `sponsorId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `addressrels`
--
ALTER TABLE `addressrels`
  ADD CONSTRAINT `addressrels_ibfk_1` FOREIGN KEY (`sponsorId`) REFERENCES `sponsor` (`sponsorId`),
  ADD CONSTRAINT `addressrels_ibfk_2` FOREIGN KEY (`addressId`) REFERENCES `address` (`addressId`);

--
-- Constraints for table `advertrels`
--
ALTER TABLE `advertrels`
  ADD CONSTRAINT `advertrels_ibfk_1` FOREIGN KEY (`sponsorId`) REFERENCES `sponsor` (`sponsorId`),
  ADD CONSTRAINT `advertrels_ibfk_2` FOREIGN KEY (`adId`) REFERENCES `advertisement` (`adId`);

--
-- Constraints for table `awards`
--
ALTER TABLE `awards`
  ADD CONSTRAINT `awards_ibfk_1` FOREIGN KEY (`fundId`) REFERENCES `fund` (`fundId`);

--
-- Constraints for table `donation`
--
ALTER TABLE `donation`
  ADD CONSTRAINT `fundId` FOREIGN KEY (`fundId`) REFERENCES `fund` (`fundId`);

--
-- Constraints for table `donrels`
--
ALTER TABLE `donrels`
  ADD CONSTRAINT `donrels_ibfk_1` FOREIGN KEY (`sponsorId`) REFERENCES `sponsor` (`sponsorId`),
  ADD CONSTRAINT `donrels_ibfk_2` FOREIGN KEY (`donId`) REFERENCES `donation` (`donId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
