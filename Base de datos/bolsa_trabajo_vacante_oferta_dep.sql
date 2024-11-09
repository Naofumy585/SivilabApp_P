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
-- Table structure for table `vacante_oferta_dep`
--

DROP TABLE IF EXISTS `vacante_oferta_dep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vacante_oferta_dep` (
  `Cvc_dependencia` varchar(20) NOT NULL,
  `Tipo` text,
  `Modalidad` text,
  `Horas` int DEFAULT NULL,
  `Curp_usuario` varchar(18) DEFAULT NULL,
  `CvcVacante` varchar(20) NOT NULL,
  PRIMARY KEY (`Cvc_dependencia`,`CvcVacante`),
  KEY `Curp_usuario` (`Curp_usuario`),
  KEY `CvcVacante` (`CvcVacante`),
  CONSTRAINT `vacante_oferta_dep_ibfk_1` FOREIGN KEY (`Cvc_dependencia`) REFERENCES `dependencia` (`CvcDependencia`),
  CONSTRAINT `vacante_oferta_dep_ibfk_2` FOREIGN KEY (`Curp_usuario`) REFERENCES `usuarios` (`Curp_usuario`),
  CONSTRAINT `vacante_oferta_dep_ibfk_3` FOREIGN KEY (`CvcVacante`) REFERENCES `vacante` (`CvcVacante`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacante_oferta_dep`
--

LOCK TABLES `vacante_oferta_dep` WRITE;
/*!40000 ALTER TABLE `vacante_oferta_dep` DISABLE KEYS */;
/*!40000 ALTER TABLE `vacante_oferta_dep` ENABLE KEYS */;
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
