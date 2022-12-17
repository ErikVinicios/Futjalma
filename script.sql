use master

if (exists(select * from sys.databases where name = 'Futjalma'))
	drop database Futjalma

create database Futjalma

use Futjalma

create table Clube(
	ID int identity primary key,
	Escudo varbinary(max) null,
	Nome varchar(100) not null,
	Fundacao date not null,
	Qnt_Titulos INT DEFAULT 0 not null,
	Qnt_Gols INT DEFAULT 0 not null,
	Qnt_Jogos INT DEFAULT 0 not null,
	Qnt_Vitorias INT DEFAULT 0 not null,
	Qnt_Empates INT DEFAULT 0 not null,
	Qnt_Derrotas INT DEFAULT 0 not null
);

create table Jogador(
	ID int identity primary key,
	Foto varbinary(max) null,
	Nome varchar(120) not null,
	DataNascimento date not null,
);

create table Contratacao(
	ID int identity primary key,
	ClubeID int references Clube(ID) not null,
	JogadorID int references Jogador(ID) not null,
	Camisa int not null,
	Fechamento date not null,
);

create table Campeonato(
	ID int identity primary key,
	Logo varbinary(max) null,
	Nome varchar(100) not null,
	Inicio date not null,
	Fim date not null,
	Premiacao decimal(10, 2) not null,
	Qnt_ClubesParticipantes int default 0 not null,
	Qnt_Jogos INT DEFAULT 0 not null
);

CREATE TABLE InfoCampeonato
(
	ID int identity primary key,
	CampeonatoID int references Campeonato(ID) not null,
	ClubeID int references Clube(ID) not null,
	Qnt_Gols int default 0 not null,
	Qnt_Vitorias int default 0 not null,
	Qnt_Empates int default 0 not null,
	Qnt_Derrotas int default 0 not null,
	Qnt_Pontos int default 0 not null
)

create table Inscricao(
	ID int identity primary key,
	ClubeID int references Clube(ID) not null,
	CampeonatoID int references Campeonato(ID) not null,
);

create table Partida(
	ID int identity primary key,
	CampeonatoID int references Campeonato(ID) not null,
	Clube1ID int references Clube(ID) not null,
	Clube2ID int references Clube(ID) not null,
	Placar1 int not null,
	Placar2 int not null
);

CREATE TRIGGER CampeonatoInscricao
ON Inscricao
FOR INSERT
AS BEGIN
	DECLARE @campeonatoID INT

			SELECT @campeonatoID = CampeonatoID FROM INSERTED

			UPDATE Campeonato SET Qnt_ClubesParticipantes += 1 where ID = @campeonatoID
	END

CREATE TRIGGER trg_PartidaInfoCampeonato
ON Partida
FOR INSERT
AS BEGIN
	DECLARE @campeonatoID INT,
			@clube1ID INT,
			@clube2ID INT,
			@placar1 INT,
			@placar2 INT

			SELECT @campeonatoID = CampeonatoID, @clube1ID = Clube1ID, @clube2ID = Clube2ID, @placar1 = Placar1, @placar2 = Placar2 FROM INSERTED

			UPDATE InfoCampeonato SET Qnt_Gols += @placar1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube1ID
			UPDATE InfoCampeonato SET Qnt_Gols += @placar2 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube2ID

			IF (@placar1 > @placar2)
			BEGIN
				UPDATE InfoCampeonato SET Qnt_Vitorias += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube1ID
				UPDATE InfoCampeonato SET Qnt_Pontos += 3 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube1ID
				UPDATE InfoCampeonato SET Qnt_Derrotas += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube2ID
			END
			ELSE IF (@placar1 < @placar2)
			BEGIN
				UPDATE InfoCampeonato SET Qnt_Vitorias += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube2ID
				UPDATE InfoCampeonato SET Qnt_Pontos += 3 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube2ID
				UPDATE InfoCampeonato SET Qnt_Derrotas += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube1ID
			END
			ELSE
			BEGIN
				UPDATE InfoCampeonato SET Qnt_Empates += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube1ID
				UPDATE InfoCampeonato SET Qnt_Pontos += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube1ID
				UPDATE InfoCampeonato SET Qnt_Empates += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube2ID
				UPDATE InfoCampeonato SET Qnt_Pontos += 1 WHERE CampeonatoID = @campeonatoID AND ClubeID = @clube2ID
			END
	END

CREATE TRIGGER trg_InscricaoInfoCampeonato
ON Inscricao
FOR INSERT
AS BEGIN
	DECLARE @clubeID INT,
			@campeonatoID INT

			SELECT @clubeID = ClubeID, @campeonatoID = CampeonatoID FROM INSERTED

			INSERT InfoCampeonato(CampeonatoID, ClubeID) VALUES (@campeonatoID, @clubeID)
	END

CREATE TRIGGER trg_CampeonatoPartida
ON Partida
FOR INSERT
AS BEGIN
	DECLARE @campeonatoID INT

			SELECT @campeonatoID = CampeonatoID FROM INSERTED

			UPDATE Campeonato SET Qnt_Jogos += 1 WHERE ID = @campeonatoID
	END

CREATE TRIGGER trg_ClubePartida
ON Partida
FOR INSERT
AS BEGIN
	DECLARE @clube1ID INT,
			@clube2ID INT,
			@placar1 INT,
			@placar2 INT

			SELECT @clube1ID = Clube1ID, @clube2ID = Clube2ID, @placar1 = Placar1, @placar2 = Placar2 FROM INSERTED

			UPDATE Clube SET Qnt_Gols += @placar1, Qnt_Jogos += 1 WHERE ID = @clube1ID
			UPDATE Clube SET Qnt_Gols += @placar2, Qnt_Jogos += 1 WHERE ID = @clube2ID

			IF (@placar1 > @placar2)
			BEGIN
				UPDATE Clube SET Qnt_Vitorias += 1 WHERE ID = @clube1ID
				UPDATE Clube SET Qnt_Derrotas += 1 WHERE ID = @clube2ID
			END
			ELSE IF (@placar1 < @placar2)
			BEGIN
				UPDATE Clube SET Qnt_Vitorias += 1 WHERE ID = @clube2ID
				UPDATE Clube SET Qnt_Derrotas += 1 WHERE ID = @clube1ID
			END
			ELSE
			BEGIN
				UPDATE Clube SET Qnt_Empates += 1 WHERE ID = @clube1ID
				UPDATE Clube SET Qnt_Empates += 1 WHERE ID = @clube2ID
			END
	END

select * from Jogador
select * FROM Clube
select * from Campeonato
select * from Contratacao
select * from inscricao
select * from InfoCampeonato
select * FROM Partida