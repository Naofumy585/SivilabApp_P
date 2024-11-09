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
-- Table structure for table `entrevista`
--

DROP TABLE IF EXISTS `entrevista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entrevista` (
  `CVC_Cita` varchar(50) DEFAULT NULL,
  `Puesto` text,
  `Hora` time DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Dias_duracion` int DEFAULT NULL,
  `Calle1` text,
  `Calle2` text,
  `Observaciones` text,
  `Folio` varchar(16) NOT NULL,
  `Folico_s` varchar(16) DEFAULT NULL,
  `Curp_usuario` varchar(18) DEFAULT NULL,
  PRIMARY KEY (`Folio`),
  KEY `CVC_Cita` (`CVC_Cita`),
  KEY `Folico_s` (`Folico_s`),
  KEY `Curp_usuario` (`Curp_usuario`),
  CONSTRAINT `entrevista_ibfk_1` FOREIGN KEY (`CVC_Cita`) REFERENCES `citas` (`CVC_Cita`),
  CONSTRAINT `entrevista_ibfk_2` FOREIGN KEY (`Folico_s`) REFERENCES `solicitud` (`Folio`) ON DELETE SET NULL,
  CONSTRAINT `entrevista_ibfk_3` FOREIGN KEY (`Curp_usuario`) REFERENCES `usuarios` (`Curp_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entrevista`
--

LOCK TABLES `entrevista` WRITE;
/*!40000 ALTER TABLE `entrevista` DISABLE KEYS */;
INSERT INTO `entrevista` VALUES (NULL,NULL,'14:13:58',NULL,2,NULL,NULL,'Chamba','WAL802324110714 ',NULL,'AUVC030923HTCQZHA8');
/*!40000 ALTER TABLE `entrevista` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-09  7:27:30
