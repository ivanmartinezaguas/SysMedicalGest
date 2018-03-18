--USE MASTER
--GO
--CREATE DATABASE GENERADORCODIGO
GO
USE [GENERADORCODIGO];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[ConecionServidores] (
[id] int IDENTITY(1, 1) NOT NULL,
[nombreConeccion] varchar(500) COLLATE Modern_Spanish_CI_AS NULL,
[servidor] varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
[baseDatos] varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
[contrasena] varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
CONSTRAINT [PK_dbo_ConecionServidores_Id]
PRIMARY KEY CLUSTERED ([id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY]
)
ON [PRIMARY];
GO
ALTER TABLE [dbo].[ConecionServidores] SET (LOCK_ESCALATION = TABLE);
GO
ALTER TABLE [dbo].[ConecionServidores] 
ADD  CONSTRAINT [U_dbo_ConecionServidores_Nombre]
UNIQUE NONCLUSTERED ([nombreConeccion] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY]
GO
CREATE VIEW vSysDataBase
as
SELECT name, database_id, create_date  
FROM sys.databases 
where name not in('model','msdb','master','tempdb')