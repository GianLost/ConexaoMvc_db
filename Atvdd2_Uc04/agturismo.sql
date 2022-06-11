-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 18-Fev-2022 às 02:07
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `agturismo`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pacotesturisticos`
--

CREATE TABLE `pacotesturisticos` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(200) DEFAULT NULL,
  `Origem` varchar(100) DEFAULT NULL,
  `Destino` varchar(100) DEFAULT NULL,
  `Atrativos` varchar(100) DEFAULT NULL,
  `Saida` datetime DEFAULT NULL,
  `Retorno` datetime DEFAULT NULL,
  `Usuario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `pacotesturisticos`
--

INSERT INTO `pacotesturisticos` (`Id`, `Nome`, `Origem`, `Destino`, `Atrativos`, `Saida`, `Retorno`, `Usuario`) VALUES
(1, 'Lua de mel em Paris', 'Rio de Janeiro', NULL, 'Apreciação da cultura e culinária local com passeios turisticos pelos principais pontos', '2022-03-01 00:00:00', '2022-04-01 00:00:00', 1),
(2, 'Férias em Dubai', 'São Paulo', 'Duabai', 'Andar de carro esportivo com os Sheiks', '2022-06-04 00:00:00', '2022-07-04 00:00:00', 4),
(4, 'Temporada em Machu Picchu', 'Santa Catarina', 'Machu Picchu', 'Passeio pelas ruínas do império Inca', '2022-03-04 00:00:00', '2022-04-04 00:00:00', 5),
(5, 'Temporada no Grand Canyon', 'Curitiba', 'Arizona', 'Camping de turistas no grand canyon, e caminhadas ecologicas', '2022-06-21 00:00:00', '2022-07-25 00:00:00', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(200) DEFAULT NULL,
  `Login` varchar(40) DEFAULT NULL,
  `Senha` varchar(40) DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Login`, `Senha`, `DataNascimento`) VALUES
(1, 'Gian', 'GianLost', '123456', '1999-11-06 00:00:00'),
(2, 'Carol', 'Carol123', '0123', '1940-02-15 00:00:00'),
(3, 'Rafael', 'RafaelABC', '4444', '1982-10-25 00:00:00'),
(4, 'Amilton', 'AmiltonComA', '221405', '1991-07-13 00:00:00'),
(5, 'Laura', 'Laurinha', '10111213', '1998-12-30 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Usuario` (`Usuario`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD CONSTRAINT `pacotesturisticos_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
