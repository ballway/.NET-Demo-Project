-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: mike_library
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `author` (
  `AUTHOR_ID` varchar(255) NOT NULL,
  `FLAG_NUMBER` int NOT NULL,
  `DISPLAY_NAME` varchar(255) NOT NULL,
  PRIMARY KEY (`AUTHOR_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
INSERT INTO `author` VALUES ('alice',1,'愛莉絲'),('michael',1,'王麥克');
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `author_book_edge`
--

DROP TABLE IF EXISTS `author_book_edge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `author_book_edge` (
  `AUTHOR_ID` varchar(255) NOT NULL,
  `BOOK_ID` varchar(255) NOT NULL,
  PRIMARY KEY (`AUTHOR_ID`,`BOOK_ID`),
  KEY `FK_AUTHOR_BOOK_EDGE_2` (`BOOK_ID`),
  CONSTRAINT `FK_AUTHOR_BOOK_EDGE_1` FOREIGN KEY (`AUTHOR_ID`) REFERENCES `author` (`AUTHOR_ID`),
  CONSTRAINT `FK_AUTHOR_BOOK_EDGE_2` FOREIGN KEY (`BOOK_ID`) REFERENCES `book` (`BOOK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author_book_edge`
--

LOCK TABLES `author_book_edge` WRITE;
/*!40000 ALTER TABLE `author_book_edge` DISABLE KEYS */;
INSERT INTO `author_book_edge` VALUES ('michael','google-seo-book'),('alice','japan-travel-book');
/*!40000 ALTER TABLE `author_book_edge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `BOOK_ID` varchar(255) NOT NULL,
  `FLAG_NUMBER` int NOT NULL,
  `DISPLAY_NAME` varchar(255) NOT NULL,
  `LASTMODIFIED_DATETIME` datetime DEFAULT NULL,
  PRIMARY KEY (`BOOK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES ('google-seo-book',1,'Google SEO 內容行銷實戰課','1753-01-01 00:00:00'),('japan-travel-book',1,'2023 日本旅遊攻略','1753-01-01 00:00:00');
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `CATEGORY_ID` varchar(255) NOT NULL,
  `FLAG_NUMBER` int NOT NULL,
  `DISPLAY_NAME` varchar(255) NOT NULL,
  `PARENT_ID` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CATEGORY_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES ('business',1,'商業理財',NULL),('e-commerce',1,'電子商務','business'),('literature',1,'文學',NULL),('travel',1,'旅遊',NULL);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category_book_edge`
--

DROP TABLE IF EXISTS `category_book_edge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category_book_edge` (
  `CATEGORY_ID` varchar(255) NOT NULL,
  `BOOK_ID` varchar(255) NOT NULL,
  PRIMARY KEY (`CATEGORY_ID`,`BOOK_ID`),
  KEY `FK_CATEGORY_BOOK_EDGE_2` (`BOOK_ID`),
  CONSTRAINT `FK_CATEGORY_BOOK_EDGE_1` FOREIGN KEY (`CATEGORY_ID`) REFERENCES `category` (`CATEGORY_ID`),
  CONSTRAINT `FK_CATEGORY_BOOK_EDGE_2` FOREIGN KEY (`BOOK_ID`) REFERENCES `book` (`BOOK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category_book_edge`
--

LOCK TABLES `category_book_edge` WRITE;
/*!40000 ALTER TABLE `category_book_edge` DISABLE KEYS */;
INSERT INTO `category_book_edge` VALUES ('e-commerce','google-seo-book'),('travel','japan-travel-book');
/*!40000 ALTER TABLE `category_book_edge` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-03  9:39:13
