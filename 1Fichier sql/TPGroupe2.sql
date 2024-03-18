--SET LANGUAGE ENGLISH
USE master
DROP DATABASE IF EXISTS TPGroup2
CREATE DATABASE TPGroup2
GO
USE TPGroup2

/*Suppression des tables si elles existent */
DROP TABLE IF EXISTS Users
DROP TABLE IF EXISTS Contacts

/*Création de la table Users*/
CREATE TABLE Users(
	Username varchar(25),
	Passwor varchar(25) NOT NULL,
	CONSTRAINT pk_login PRIMARY KEY CLUSTERED (Username)
)

/*Création de la table Contacts*/
CREATE TABLE Contacts(
	Id int IDENTITY (1, 1),
	Prenom varchar(25) NOT NULL, 
	Nom varchar(20) NOT NULL, 
	Tel varchar(13) NOT NULL CHECK (Tel LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'), 
	Favorie bit,
	CONSTRAINT pk_contacts_id PRIMARY KEY CLUSTERED (Id)
)

INSERT Users(Username, Passwor) VALUES ('Admin', 'admin1234')

INSERT Contacts(Prenom, Nom, Tel, Favorie) VALUES ('Atou', 'Diop', '(514)999-9999', 1)
INSERT Contacts (Prenom, Nom, Tel, Favorie) VALUES ('Alex', 'Grégoire', '(514)999-4777', 1)
INSERT Contacts (Prenom, Nom, Tel, Favorie) VALUES ('Modou', 'Ivoir', '(514)999-6777', 0)
INSERT Contacts (Prenom, Nom, Tel, Favorie) VALUES ('Marie', 'Smith', '(514)999-0221', 1)