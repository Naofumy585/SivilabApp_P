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
-- Table structure for table `vacante`
--

DROP TABLE IF EXISTS `vacante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vacante` (
  `CvcVacante` varchar(20) NOT NULL,
  `Vigencia` datetime DEFAULT NULL,
  `Tipo_de_vacante` text,
  `Puesto_ofrecido` text,
  `Turno_laboral` text,
  `Salario_M` decimal(12,0) DEFAULT NULL,
  `NO_plazas` int DEFAULT NULL,
  `Tipo_contrato` text,
  `Horarios` bigint DEFAULT NULL,
  `Escolaridad` text,
  `Otras_prestaciones` text,
  `Estado_civil` text,
  `Rango_edad` varchar(50) DEFAULT NULL,
  `Habilidades` text,
  `Sexo` text,
  `Licencia_de_manejo` tinyint(1) DEFAULT NULL,
  `Cartilla` tinyint(1) DEFAULT NULL,
  `Disponible_viaje` tinyint(1) DEFAULT NULL,
  `Disponible_afuera` tinyint(1) DEFAULT NULL,
  `CvcDependencia` varchar(20) DEFAULT NULL,
  `Curp_usuario` varchar(18) DEFAULT NULL,
  `Curp_Solicitante` varchar(18) DEFAULT NULL,
  PRIMARY KEY (`CvcVacante`),
  KEY `Curp_usuario` (`Curp_usuario`),
  KEY `CvcDependencia` (`CvcDependencia`),
  CONSTRAINT `vacante_ibfk_1` FOREIGN KEY (`Curp_usuario`) REFERENCES `usuarios` (`Curp_usuario`),
  CONSTRAINT `vacante_ibfk_2` FOREIGN KEY (`CvcDependencia`) REFERENCES `dependencia` (`CvcDependencia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacante`
--

LOCK TABLES `vacante` WRITE;
/*!40000 ALTER TABLE `vacante` DISABLE KEYS */;
INSERT INTO `vacante` VALUES ('CV001','2024-11-08 00:00:00','Tiempo Completo','Ingeniero de Software','Matutino',30000,10,'Permanente',40,'Universitario','Seguro médico y dental','Casado','25-35','Habilidades en desarrollo de software','Masculino',1,1,1,1,'AUVC030923HTCQZH','AUVC030923HTCQZHA8',NULL),('UNIgejoME       ','2024-11-22 13:28:04','Trabajo Fijo','Inge','Medio Tiempo',4500,2,'Permanente ',8,'Universitario','nose','SOLTERO','20-25','Nose','MASCULINO',1,1,1,1,'AUVC030923HTCQZH','AUVC030923HTCQZHA8',NULL);
/*!40000 ALTER TABLE `vacante` ENABLE KEYS */;
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
