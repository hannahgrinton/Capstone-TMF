-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Feb 11, 2020 at 11:38 PM
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
  `address` varchar(100) NOT NULL,
  `city` varchar(50) NOT NULL,
  `province` varchar(2) NOT NULL DEFAULT 'NS',
  `postal` varchar(7) NOT NULL,
  `country` varchar(20) NOT NULL DEFAULT 'Canada'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `addressRels`
--

CREATE TABLE `addressRels` (
  `relationId` int(11) NOT NULL,
  `type` varchar(10) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `addressId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `advertRels`
--

CREATE TABLE `advertRels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `adId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `awards`
--

CREATE TABLE `awards` (
  `awardId` int(11) NOT NULL,
  `recipient` varchar(10) DEFAULT NULL,
  `year` varchar(4) DEFAULT NULL,
  `fundId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `donRels`
--

CREATE TABLE `donRels` (
  `relationId` int(11) NOT NULL,
  `sponsorId` int(11) DEFAULT NULL,
  `donId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `fund`
--

CREATE TABLE `fund` (
  `fundId` int(11) NOT NULL,
  `creator` varchar(100) DEFAULT NULL,
  `dateCreated` date NOT NULL,
  `notes` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `sponsor`
--

CREATE TABLE `sponsor` (
  `sponsorId` int(11) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `phone` varchar(14) NOT NULL,
  `fax` varchar(14) DEFAULT NULL,
  `email` varchar(70) DEFAULT NULL,
  `activity` varchar(10) NOT NULL DEFAULT 'active',
  `notes` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  MODIFY `addressId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `addressRels`
--
ALTER TABLE `addressRels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `advertisement`
--
ALTER TABLE `advertisement`
  MODIFY `adId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `advertRels`
--
ALTER TABLE `advertRels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `awards`
--
ALTER TABLE `awards`
  MODIFY `awardId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `donation`
--
ALTER TABLE `donation`
  MODIFY `donId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `donRels`
--
ALTER TABLE `donRels`
  MODIFY `relationId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `fund`
--
ALTER TABLE `fund`
  MODIFY `fundId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sponsor`
--
ALTER TABLE `sponsor`
  MODIFY `sponsorId` int(11) NOT NULL AUTO_INCREMENT;

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
