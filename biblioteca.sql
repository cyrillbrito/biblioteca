-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 16-Jun-2014 às 13:50
-- Versão do servidor: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `biblioteca`
--
CREATE DATABASE IF NOT EXISTS `biblioteca` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `biblioteca`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `autores`
--

DROP TABLE IF EXISTS `autores`;
CREATE TABLE IF NOT EXISTS `autores` (
  `id_auto` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `nacionalidade` varchar(15) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `data_fale` date DEFAULT NULL,
  PRIMARY KEY (`id_auto`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Extraindo dados da tabela `autores`
--

INSERT INTO `autores` (`id_auto`, `nome`, `nacionalidade`, `data_nasc`, `data_fale`) VALUES
(1, 'Aaron McGruder ', 'Americana', '1973-06-09', NULL),
(2, 'Emilio Costa', 'Portuguesa', '1855-07-20', '1855-07-20'),
(3, 'Ricardo Araujo', 'Portuguesa', '1980-04-21', NULL),
(4, 'Luna Vieira', 'Espanhola', '1926-09-14', '1926-09-14'),
(5, 'Guilherme Sousa', 'Portuguesa', '1955-12-02', NULL),
(6, 'Júlia Matos', 'Portuguesa', '1986-06-30', NULL),
(7, 'Tiago Pires', 'Espanhola', '1990-05-01', NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `categorias`
--

DROP TABLE IF EXISTS `categorias`;
CREATE TABLE IF NOT EXISTS `categorias` (
  `id_cate` int(11) NOT NULL AUTO_INCREMENT,
  `categoria` varchar(15) NOT NULL,
  PRIMARY KEY (`id_cate`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Extraindo dados da tabela `categorias`
--

INSERT INTO `categorias` (`id_cate`, `categoria`) VALUES
(1, 'Aventura'),
(2, 'Drama'),
(3, 'Ação'),
(4, 'Romance'),
(5, 'Dicionário'),
(6, 'Ficção'),
(7, 'Cientificos');

-- --------------------------------------------------------

--
-- Estrutura da tabela `editoras`
--

DROP TABLE IF EXISTS `editoras`;
CREATE TABLE IF NOT EXISTS `editoras` (
  `id_edit` int(11) NOT NULL AUTO_INCREMENT,
  `editora` varchar(45) NOT NULL,
  PRIMARY KEY (`id_edit`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Extraindo dados da tabela `editoras`
--

INSERT INTO `editoras` (`id_edit`, `editora`) VALUES
(1, 'ASA'),
(2, 'Porto Editora'),
(3, 'Editora Algarve'),
(4, 'Lisboa Editora'),
(5, 'Editora Ática'),
(7, 'Editora Rocco');

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionarios`
--

DROP TABLE IF EXISTS `funcionarios`;
CREATE TABLE IF NOT EXISTS `funcionarios` (
  `id_func` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `data_nasc` date DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `morada` varchar(45) DEFAULT NULL,
  `telemovel` varchar(13) DEFAULT NULL,
  `password` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id_func`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Extraindo dados da tabela `funcionarios`
--

INSERT INTO `funcionarios` (`id_func`, `nome`, `data_nasc`, `email`, `morada`, `telemovel`, `password`) VALUES
(1, 'Cyrill Brito', '1995-01-12', 'cyrill.brito@gmail.com', 'Pechão', '919131941', 'qwerty');

-- --------------------------------------------------------

--
-- Estrutura da tabela `leitores`
--

DROP TABLE IF EXISTS `leitores`;
CREATE TABLE IF NOT EXISTS `leitores` (
  `id_leit` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `morada` varchar(45) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `telemovel` varchar(13) DEFAULT NULL,
  `password` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id_leit`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Extraindo dados da tabela `leitores`
--

INSERT INTO `leitores` (`id_leit`, `nome`, `email`, `morada`, `data_nasc`, `telemovel`, `password`) VALUES
(1, 'Luis Coelho', 'lcoelho@hotmail.com', 'Olhão', NULL, '910564896', NULL),
(2, 'Rita Marcelo', 'marle123@gmail.com', 'Pechão', NULL, '914785236', NULL),
(3, 'Ana Gabadinho', 'gabadas@lice.com.pt', 'Faro', NULL, '915648932', NULL),
(4, 'Ricardo Cavaco', 'sovaco@hotmail.com', 'Conceição', NULL, '965472301', NULL),
(5, 'Joana Silva', 'Silver@gmail.com', 'Lisboa', NULL, '932145670', NULL),
(6, 'Ivo Soares', 'ISoares@yahoo.pt', 'Faro', NULL, '914520146', NULL),
(7, 'Marta Ferreira', 'Ferros@gmail.com', 'Olhão', NULL, '921408566', NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `livros`
--

DROP TABLE IF EXISTS `livros`;
CREATE TABLE IF NOT EXISTS `livros` (
  `id_livr` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(45) NOT NULL,
  `n_pagi` int(11) DEFAULT NULL,
  `data_lanc` date DEFAULT NULL,
  `id_edit` int(11) DEFAULT NULL,
  `id_auto` int(11) DEFAULT NULL,
  `id_cate` int(11) DEFAULT NULL,
  `requisitado` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id_livr`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=15 ;

--
-- Extraindo dados da tabela `livros`
--

INSERT INTO `livros` (`id_livr`, `titulo`, `n_pagi`, `data_lanc`, `id_edit`, `id_auto`, `id_cate`, `requisitado`) VALUES
(1, 'A Espada de Shannara', 223, '2009-11-22', 7, 3, 1, 0),
(2, 'Cronicas', 114, '2012-07-09', 4, 4, 4, 1),
(3, 'O sol e a lua', 600, '2013-08-24', 2, 1, 7, 1),
(4, 'Dicionario portugues', 589, '2014-01-01', 1, 2, 5, 1),
(5, 'O outro lado', 436, '2002-05-14', 5, 7, 6, 0),
(6, '15 azuis', 666, '2014-06-09', 1, 5, 2, 0),
(7, 'Capitao coelhos', 333, '2014-06-05', 2, 3, 1, 0),
(8, 'Piratas de california', 489, '2009-03-01', 3, 6, 3, 1),
(9, 'Aventureiros', 789, '2012-09-29', 4, 1, 3, 0),
(10, 'Logica da batata', 546, '2012-11-28', 1, 4, 7, 1),
(11, 'Dicionario Inglês', 555, '2006-04-08', 5, 2, 5, 0),
(12, 'Mestre alibaba', 122, '2008-11-24', 4, 5, 4, 0),
(13, 'Omelete', 909, '2013-12-01', 3, 3, 2, 1),
(14, 'Lolios', 135, '2001-05-31', 7, 4, 6, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `requisita`
--

DROP TABLE IF EXISTS `requisita`;
CREATE TABLE IF NOT EXISTS `requisita` (
  `id_requ` int(11) NOT NULL AUTO_INCREMENT,
  `id_livr` int(11) NOT NULL,
  `id_leit` int(11) NOT NULL,
  `id_func` int(11) NOT NULL,
  `data_requ` date NOT NULL,
  `data_entr` date NOT NULL,
  `data_devo` date DEFAULT NULL,
  PRIMARY KEY (`id_requ`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=21 ;

--
-- Extraindo dados da tabela `requisita`
--

INSERT INTO `requisita` (`id_requ`, `id_livr`, `id_leit`, `id_func`, `data_requ`, `data_entr`, `data_devo`) VALUES
(1, 10, 6, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(2, 4, 2, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(3, 11, 1, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(4, 8, 6, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(5, 1, 1, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(6, 13, 5, 1, '2014-06-14', '2014-06-29', NULL),
(7, 9, 4, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(8, 3, 2, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(9, 12, 3, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(10, 6, 5, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(11, 2, 7, 1, '2014-05-06', '2014-05-25', NULL),
(12, 5, 7, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(13, 7, 1, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(14, 14, 2, 1, '2014-06-14', '2014-06-29', NULL),
(15, 8, 5, 1, '2014-04-07', '2014-05-14', NULL),
(16, 3, 7, 1, '2014-06-14', '2014-06-29', NULL),
(17, 4, 3, 1, '2014-06-01', '2014-07-11', NULL),
(18, 1, 1, 1, '2014-06-14', '2014-06-29', '2014-06-14'),
(19, 10, 5, 1, '2014-06-14', '2014-06-29', NULL),
(20, 11, 4, 1, '2014-06-14', '2014-06-29', '2014-06-14');

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_livros`
--
DROP VIEW IF EXISTS `view_livros`;
CREATE TABLE IF NOT EXISTS `view_livros` (
`id_livr` int(11)
,`titulo` varchar(45)
,`n_pagi` int(11)
,`data_lanc` date
,`id_cate` int(11)
,`categoria` varchar(15)
,`id_auto` int(11)
,`nome` varchar(45)
,`id_edit` int(11)
,`editora` varchar(45)
,`requisitado` tinyint(1)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `view_requisita`
--
DROP VIEW IF EXISTS `view_requisita`;
CREATE TABLE IF NOT EXISTS `view_requisita` (
`id_requ` int(11)
,`id_livr` int(11)
,`titulo` varchar(45)
,`id_leit` int(11)
,`nome` varchar(45)
,`id_func` int(11)
,`nomeFunc` varchar(45)
,`data_requ` date
,`data_entr` date
,`data_devo` date
);
-- --------------------------------------------------------

--
-- Structure for view `view_livros`
--
DROP TABLE IF EXISTS `view_livros`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_livros` AS select `livros`.`id_livr` AS `id_livr`,`livros`.`titulo` AS `titulo`,`livros`.`n_pagi` AS `n_pagi`,`livros`.`data_lanc` AS `data_lanc`,`categorias`.`id_cate` AS `id_cate`,`categorias`.`categoria` AS `categoria`,`autores`.`id_auto` AS `id_auto`,`autores`.`nome` AS `nome`,`editoras`.`id_edit` AS `id_edit`,`editoras`.`editora` AS `editora`,`livros`.`requisitado` AS `requisitado` from (((`livros` join `categorias` on((`livros`.`id_cate` = `categorias`.`id_cate`))) join `autores` on((`livros`.`id_auto` = `autores`.`id_auto`))) join `editoras` on((`livros`.`id_edit` = `editoras`.`id_edit`))) order by 1;

-- --------------------------------------------------------

--
-- Structure for view `view_requisita`
--
DROP TABLE IF EXISTS `view_requisita`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_requisita` AS select `requisita`.`id_requ` AS `id_requ`,`livros`.`id_livr` AS `id_livr`,`livros`.`titulo` AS `titulo`,`leitores`.`id_leit` AS `id_leit`,`leitores`.`nome` AS `nome`,`funcionarios`.`id_func` AS `id_func`,`funcionarios`.`nome` AS `nomeFunc`,`requisita`.`data_requ` AS `data_requ`,`requisita`.`data_entr` AS `data_entr`,`requisita`.`data_devo` AS `data_devo` from (((`requisita` join `livros` on((`requisita`.`id_livr` = `livros`.`id_livr`))) join `leitores` on((`requisita`.`id_leit` = `leitores`.`id_leit`))) join `funcionarios` on((`requisita`.`id_func` = `funcionarios`.`id_func`)));

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
