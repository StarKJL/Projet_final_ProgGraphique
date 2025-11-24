/*KimMai Jennifer Lebel*/
DROP TABLE IF EXISTS Employe;
DROP TABLE IF EXISTS Client;
DROP TABLE IF EXISTS Projet;
DROP TABLE IF EXISTS EmployeProjet;
-- Employés
CREATE TABLE Employe(
matricule VARCHAR(10) PRIMARY KEY ,
nom VARCHAR(255),
prenom VARCHAR(255),
dateNaissance DATE,
email VARCHAR(255),
adresse VARCHAR(255),
dateEmbauche DATE,
tauxHoraire DOUBLE,
photoId VARCHAR(1204),
statut ENUM('Journalier','Permament')
);
-- Client
CREATE TABLE Client (
id INT PRIMARY KEY ,
nom VARCHAR(255),
prenom VARCHAR(255),
adresse VARCHAR(255),
telephone VARCHAR(20),
email VARCHAR(255)
);
-- Projet
CREATE TABLE Projet(
noProjet VARCHAR(12) PRIMARY KEY ,
titre VARCHAR(255),
dateDebut DATE,
description TEXT,
budget DOUBLE,
totalSalaire DOUBLE,
statut ENUM('Terminé','En cours'),
idClient INT,
FOREIGN KEY (idClient) REFERENCES Client(id)
);
-- EmployeProjet
CREATE TABLE EmployeProjet(
id INT AUTO_INCREMENT PRIMARY KEY ,
nbHrs INT,
salaireCumul DOUBLE,
matricule VARCHAR(10),
noProjet VARCHAR(12),
FOREIGN KEY (matricule) REFERENCES Employe(matricule),
FOREIGN KEY (noProjet) REFERENCES Projet(noProjet)
);