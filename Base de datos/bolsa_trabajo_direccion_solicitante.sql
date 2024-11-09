-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: bolsa_trabajo
-- ------------------------------------------------------
-- Server version	8.0.39

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
-- Table structure for table `direccion_solicitante`
--

DROP TABLE IF EXISTS `direccion_solicitante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `direccion_solicitante` (
  `Folio` varchar(16) NOT NULL,
  `Codigo_postal` bigint DEFAULT NULL,
  `Calle_1` text,
  `Ciudad` text,
  `Colonia` text,
  `Estado` text,
  `No_exterior` bigint DEFAULT NULL,
  PRIMARY KEY (`Folio`),
  CONSTRAINT `direccion_solicitante_ibfk_1` FOREIGN KEY (`Folio`) REFERENCES `solicitud` (`Folio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direccion_solicitante`
--

LOCK TABLES `direccion_solicitante` WRITE;
/*!40000 ALTER TABLE `direccion_solicitante` DISABLE KEYS */;
INSERT INTO `direccion_solicitante` VALUES ('FOLIO12315',123456,'Calle Falsa','Ciudad de México','Colonia Ejemplo','CDMX',456),('FOLIO123156',123456,'Calle Falsa','Ciudad de México','Colonia Ejemplo','CDMX',456),('FOLIO1234',123456,'Calle Falsa','Ciudad de México','Colonia Ejemplo','CDMX',456),('XXX80XX24110',29066,'Septima Poniente','Tuxtla Gutierrez','Barrio San Francisco','Chiapas',1061);
/*!40000 ALTER TABLE `direccion_solicitante` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-09  7:27:31
