-- Logan Morin

-- 1
/*
 Retourne le nombre de projets par client
 */
SELECT id,
       nom,
       COUNT(p.noProjet) AS nbProjets
FROM client
JOIN projet p on client.id = p.idClient
GROUP BY id;

-- 2
/*
 Retourne les employés qui sont impiqués
 dans un projet
 */
SELECT matricule
FROM employe
WHERE matricule IN (SELECT matricule
                    FROM employeprojet);

-- 3
/*
 Retourne les clients qui sont impliqués
 dans un projet
 */
SELECT *
FROM client
WHERE id IN (SELECT idClient
             FROM projet);

-- 4
/*
 Retourne le salaire maximal de chaque
 projet avec des employés
 */
SELECT p.noProjet,
    MAX(e.tauxHoraire) AS salaireMaximal
FROM projet p
JOIN employeprojet ep on p.noProjet = ep.noProjet
JOIN employe e on e.matricule = ep.matricule
GROUP BY p.noProjet;

-- 5
/*
 Retourne les employés à temps plein
 */
SELECT matricule,
       nom,
       prenom,
       email,
       adresse,
       dateNaissance,
       dateEmbauche,
       tauxHoraire
FROM employe
WHERE statut='Permanent';

-- 6
/*
 Retourne le nombre de projets par employé
 */
SELECT matricule,
       prenom,
       nom,
       (SELECT COUNT(*)
        FROM employeprojet
        WHERE employe.matricule=employeprojet.matricule) AS nbProjets
FROM employe;

-- 7
/*
 Retourne le projet avec
 le plus gros budget de tous
 */
SELECT noProjet,
       MAX(budget) AS budgetMaximal
FROM projet
GROUP BY noProjet
ORDER BY budgetMaximal DESC
LIMIT 1;

-- 8
/*
 Sépare le nom du client en prenom et nom de famille
 */
SELECT id,
    SUBSTR(nom, 1, INSTR(nom, ' ') - 1) AS prenom,
    SUBSTR(nom, INSTR(nom, ' ') + 1) AS nom_de_famille
FROM client;

-- 9
/*
 Réunit les colonnes nom et prenom en nom_complet de l'employe
 */
SELECT matricule,
       CONCAT(prenom,' ',nom) AS nom_complet
FROM employe;

-- 10
/*
 Retourne les projets en cours
 */
SELECT *
FROM projet
WHERE statut='En cours';