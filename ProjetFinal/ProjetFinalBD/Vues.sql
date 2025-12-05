-- Kim Mai Jennifer Lebel
/*Vues*/

DROP VIEW IF EXISTS EmployeComplet;
CREATE VIEW EmployeComplet AS
SELECT nbHrs, salaireCumul,noProjet, e.matricule, nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut
FROM employeprojet
INNER JOIN employe e on employeprojet.matricule = e.matricule;

DROP VIEW IF EXISTS ClientProjet;
CREATE VIEW ClientProjet AS
SELECT noProjet, titre, dateDebut, description, budget, totalSalaire, statut,
       (SELECT nom
        FROM client
        WHERE id = projet.idClient) nom_client
FROM projet;

DROP VIEW IF EXISTS nomEmployeProjetTitre;
CREATE VIEW nomEmployeProjetTitre AS
SELECT id, nbHrs, salaireCumul, (SELECT CONCAT(prenom,' ',nom) FROM employe WHERE employe.matricule= employeprojet.matricule) AS nomEmploye, (SELECT titre FROM projet WHERE projet.noProjet=employeprojet.noProjet ) AS titreProjet
FROM employeprojet;


DROP VIEW IF EXISTS projetnonAssigner;
CREATE VIEW projetnonAssigner AS
SELECT projet.noProjet, projet.titre, projet.dateDebut, projet.description, projet.budget, projet.totalSalaire, projet.statut, projet.idClient
FROM projet
INNER JOIN employeprojet e on projet.noProjet = e.noProjet
WHERE compteEmployeParProjet(projet.noProjet)=0;

DROP VIEW IF EXISTS ChargeTravail;
CREATE VIEW ChargeTravail AS
SELECT employe.matricule, nom, prenom, COUNT(e.noProjet) AS nbProjets
FROM Employe
INNER JOIN employeprojet e on employe.matricule = e.matricule
GROUP BY e.matricule, nom, prenom;