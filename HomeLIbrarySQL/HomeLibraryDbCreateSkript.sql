CREATE DATABASE HomeLibraryDB;
GO

USE HomeLibraryDB

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	NameBook NVARCHAR(50) NOT NULL UNIQUE,
	Datebirth DATE NOT NULL,
    Author NVARCHAR(50) NOT NULL,
	Contents XML 
)
