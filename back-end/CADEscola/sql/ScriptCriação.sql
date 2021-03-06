CREATE DATABASE CADEscola
GO

USE CADEscola
GO


CREATE TABLE Escolas (
	EscolaId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(150) NOT NULL,
	Telefone VARCHAR(11) NOT NULL
)
GO

CREATE TABLE Turmas (
 TurmaId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
 Nome VARCHAR(20) NOT NULL,
 Sala VARCHAR(10) NOT NULL,
 DataInicio DATETIME2 NOT NULL,
 DataFim DATETIME2 NOT NULL,
 LimiteTurma TINYINT NOT NULL,
 EscolaId UNIQUEIDENTIFIER
)
GO

ALTER TABLE Turmas
ADD CONSTRAINT FK_ESCOLAS_TURMAS FOREIGN KEY (EscolaId)
REFERENCES Escolas (EscolaId);
GO
