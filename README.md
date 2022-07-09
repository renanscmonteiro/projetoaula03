# Projeto C# Console Application / SQL Server
Sistema criado para acesso ao SQL Server com Dapper.

## Requisitos necessários:

* VisualStudio2022
* SQl Server

## Script do banco de dados
```sql
	CREATE TABLE [dbo].[PESSOA] (
		[IDPESSOA]       UNIQUEIDENTIFIER NOT NULL,
		[NOME]           NVARCHAR (150)   NOT NULL,
		[CPF]            NVARCHAR (11)    NOT NULL,
		[DATANASCIMENTO] DATE             NOT NULL
	);
```
