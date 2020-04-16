-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Apr 14, 2020 at 06:21 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbTMF`
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
  `type` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`addressId`, `firstname`, `lastname`, `address`, `city`, `province`, `postal`, `country`, `type`) VALUES
(10, 'Hannah Margaret', 'Grinton', '113 Fraser Rd', 'Harmony', 'NS', 'B6L 3K9', 'Canada', 'mailing'),
(11, 'Sarah', 'Thompson', '191 Fraser Road', 'Wellington', 'NS', 'B2T4H7', 'Canada', 'business');

-- --------------------------------------------------------

--
-- Table structure for table `addressRels`
--

CREATE TABLE `addressRels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `addressId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `addressRels`
--

INSERT INTO `addressRels` (`relationId`, `sponsorId`, `addressId`) VALUES
(2, 15, 10),
(3, 16, 11);

-- --------------------------------------------------------

--
-- Table structure for table `advertisement`
--

CREATE TABLE `advertisement` (
  `adId` int(11) NOT NULL,
  `date` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL,
  `imgFile` varchar(100) DEFAULT NULL,
  `adSize` varchar(100) NOT NULL,
  `cost` float NOT NULL,
  `paid` float DEFAULT NULL,
  `due` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `advertisement`
--

INSERT INTO `advertisement` (`adId`, `date`, `notes`, `imgFile`, `adSize`, `cost`, `paid`, `due`) VALUES
(2, '0001-01-01', 'test', 'Screen Shot 2019-09-12 at 10.32.36 AM.png', 'half', 130, 130, 0),
(3, '2020-04-14', 'test', 'IMG_1367-scaled.jpg', 'quarter', 200, 100, 100);

-- --------------------------------------------------------

--
-- Table structure for table `advertRels`
--

CREATE TABLE `advertRels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `adId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `advertRels`
--

INSERT INTO `advertRels` (`relationId`, `sponsorId`, `adId`) VALUES
(3, 16, 3),
(4, 16, 2);

-- --------------------------------------------------------

--
-- Table structure for table `awards`
--

CREATE TABLE `awards` (
  `awardId` int(11) NOT NULL,
  `recipient` varchar(100) DEFAULT NULL,
  `year` varchar(4) DEFAULT NULL,
  `fundId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `awards`
--

INSERT INTO `awards` (`awardId`, `recipient`, `year`, `fundId`) VALUES
(1, 'Bob Ross', '1989', 0);

-- --------------------------------------------------------

--
-- Table structure for table `donation`
--

CREATE TABLE `donation` (
  `donId` int(11) NOT NULL,
  `date` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL,
  `receipt` int(1) NOT NULL DEFAULT '0',
  `amount` float NOT NULL,
  `fundId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `donation`
--

INSERT INTO `donation` (`donId`, `date`, `notes`, `receipt`, `amount`, `fundId`) VALUES
(1, '0001-01-01', 'test', 0, 220, 0),
(2, '2020-04-14', 'test', 1, 400, 1);

-- --------------------------------------------------------

--
-- Table structure for table `donRels`
--

CREATE TABLE `donRels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `donId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `donRels`
--

INSERT INTO `donRels` (`relationId`, `sponsorId`, `donId`) VALUES
(2, 16, 2),
(3, 16, 1);

-- --------------------------------------------------------

--
-- Table structure for table `fund`
--

CREATE TABLE `fund` (
  `fundId` int(11) NOT NULL,
  `fundName` varchar(200) NOT NULL,
  `creator` varchar(100) DEFAULT NULL,
  `dateCreated` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `fund`
--

INSERT INTO `fund` (`fundId`, `fundName`, `creator`, `dateCreated`, `notes`) VALUES
(0, 'N/A', 'N/A', '2020-04-04', NULL),
(1, 'Bob Ross Art Fund Edited', 'Bob Ross', '2019-01-09', 'Woohoo Bob Ross');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `role` varchar(200) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `role`, `username`, `password`, `salt`) VALUES
(1, 'The Treasurer', 'bobross', 'Tt+DQ0g1u442pmztd9OJgg9LjKmMuCBtjseQwE/TYFY=', 'tkwlHe2168XQpc+W3TDPbQ=='),
(2, 'CEO', 'marcusmumford', 'testagain', 'onemoretime'),
(3, 'Janitor', 'donaldtrump', '8iLT9mpJCVenqndRpQTXqdJJCwz6VGePxDgUoCf8H5c=', 'RuiW07zpOU3j1dqlT/K1lQ=='),
(5, 'test', 'test', '1+HCuiEzLeEiw5XQkFkaoWIVhcX3zH209oH5N1/z5gY=', '53+OYYebt/NgjewQHtpvZA==');

-- --------------------------------------------------------

--
-- Table structure for table `sponsor`
--

CREATE TABLE `sponsor` (
  `sponsorId` int(11) NOT NULL,
  `company` varchar(200) NOT NULL,
  `phone` varchar(14) NOT NULL,
  `fax` varchar(14) DEFAULT 'N/A',
  `email` varchar(70) DEFAULT NULL,
  `activity` varchar(10) NOT NULL DEFAULT 'active',
  `notes` varchar(250) DEFAULT 'N/A'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sponsor`
--

INSERT INTO `sponsor` (`sponsorId`, `company`, `phone`, `fax`, `email`, `activity`, `notes`) VALUES
(15, 'NSCC Truro Campus', '9028937892', '9028937891', 'trurocampus@nscc.ca', 'active', 'This is a contact for testing purposes - edited'),
(16, 'Booster Juice', '9028937891', NULL, 'boosterjuice@icloud.com', 'active', 'Test item ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`addressId`);

--
-- Indexes for table `addressRels`
--
ALTER TABLE `addressRels`
  ADD PRIMARY KEY (`relationId`),
  ADD KEY `sponsorId` (`sponsorId`),
  ADD KEY `addressId` (`addressId`);

--
-- Indexes for table `advertisement`
--
ALTER TABLE `advertisement`
  ADD PRIMARY KEY (`adId`);

--
-- Indexes for table `advertRels`
--
ALTER TABLE `advertRels`
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
-- Indexes for table `donRels`
--
ALTER TABLE `donRels`
  ADD PRIMARY KEY (`relationId`),
  ADD KEY `sponsorId` (`sponsorId`),
  ADD KEY `donId` (`donId`);

--
-- Indexes for table `fund`
--
ALTER TABLE `fund`
  ADD PRIMARY KEY (`fundId`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

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
  MODIFY `addressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `addressRels`
--
ALTER TABLE `addressRels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `advertisement`
--
ALTER TABLE `advertisement`
  MODIFY `adId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `advertRels`
--
ALTER TABLE `advertRels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `awards`
--
ALTER TABLE `awards`
  MODIFY `awardId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `donation`
--
ALTER TABLE `donation`
  MODIFY `donId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `donRels`
--
ALTER TABLE `donRels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `fund`
--
ALTER TABLE `fund`
  MODIFY `fundId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `sponsor`
--
ALTER TABLE `sponsor`
  MODIFY `sponsorId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `addressRels`
--
ALTER TABLE `addressRels`
  ADD CONSTRAINT `addressrels_ibfk_1` FOREIGN KEY (`sponsorId`) REFERENCES `sponsor` (`sponsorId`),
  ADD CONSTRAINT `addressrels_ibfk_2` FOREIGN KEY (`addressId`) REFERENCES `address` (`addressId`);

--
-- Constraints for table `advertRels`
--
ALTER TABLE `advertRels`
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
-- Constraints for table `donRels`
--
ALTER TABLE `donRels`
  ADD CONSTRAINT `donrels_ibfk_1` FOREIGN KEY (`sponsorId`) REFERENCES `sponsor` (`sponsorId`),
  ADD CONSTRAINT `donrels_ibfk_2` FOREIGN KEY (`donId`) REFERENCES `donation` (`donId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
