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
-- Table structure for table `solicitud`
--

DROP TABLE IF EXISTS `solicitud`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitud` (
  `Folio` varchar(16) NOT NULL,
  `ApellidoPaterno` text,
  `ApellidoMaterno` text,
  `Nombre_solicitante` text,
  `Rfc` varchar(16) DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL,
  `Estado_migratorio` text,
  `Fecha_Nacimiento` datetime DEFAULT NULL,
  `Escolaridad` text,
  `Genero` text,
  `Telefono` decimal(12,0) DEFAULT NULL,
  `Direccion` text,
  `Cvc_cedula` varchar(12) DEFAULT NULL,
  `Curp_Solicitante` varchar(18) DEFAULT NULL,
  `Curp` varchar(18) DEFAULT NULL,
  `Curp_usuario` varchar(18) DEFAULT NULL,
  PRIMARY KEY (`Folio`),
  UNIQUE KEY `Rfc` (`Rfc`),
  KEY `Curp_usuario` (`Curp_usuario`),
  KEY `solicitud_ibfk_2` (`Curp`),
  CONSTRAINT `solicitud_ibfk_1` FOREIGN KEY (`Curp_usuario`) REFERENCES `usuarios` (`Curp_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitud`
--

LOCK TABLES `solicitud` WRITE;
/*!40000 ALTER TABLE `solicitud` DISABLE KEYS */;
INSERT INTO `solicitud` VALUES ('FOLIO1215','Pérez','González','Juan','JUAGA123455','juan@correo.com','Mexicano','1990-05-15 00:00:00','Licenciatura','Masculino',1234567890,'Calle Falsa 123','CVC12346','AUVC030923HTCQZHA8','UNIgejoME       ','AUVC030923HTCQZHA8'),('FOLIO12315','Pérez','González','Juan','JUAGA1234V55','juan@correo.com','Mexicano','1990-05-15 00:00:00','Licenciatura','Masculino',1234567890,'Calle Falsa 123','CVC12346','AUVC030923HTCQZHA8','UNIgejoME       ','AUVC030923HTCQZHA8'),('FOLIO123156','Pérez','González','Juan','JUAGA1234V855','juan@correo.com','Mexicano','1990-05-15 00:00:00','Licenciatura','Masculino',1234567890,'Calle Falsa 123','CVC12346','AUVC030923HTCQZHA8','UNIgejoME       ','AUVC030923HTCQZHA8'),('FOLIO1234','Pérez','González','Juan','JUAG123456','juan@correo.com','Mexicano','1990-05-15 00:00:00','Licenciatura','Masculino',1234567890,'Calle Falsa 123','CVC123456',NULL,'CV001','AUVC030923HTCQZHA8'),('XXX80XX24110','','','','','Inge','Mexicana','2024-11-08 17:25:19','','',9161659580,'','','','','AUVC030923HTCQZHA8');
/*!40000 ALTER TABLE `solicitud` ENABLE KEYS */;
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
