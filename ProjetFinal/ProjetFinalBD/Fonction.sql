-- Kim Mai Jennifer Lebel
/*Fonction*/

DROP FUNCTION IF EXISTS calculSalaire;
DELIMITER //
CREATE FUNCTION calculSalaire(idEmploye VARCHAR(10)) RETURNS INT
BEGIN
    DECLARE salaire INT;
    SELECT nbHrs*tauxHoraire INTO salaire FROM employe INNER JOIN employeprojet e on employe.matricule = e.matricule WHERE matricule=idEmploye;
 RETURN salaire;
END//
DELIMITER ;

DROP FUNCTION IF EXISTS compteEmployeParProjet;
DELIMITER //
CREATE FUNCTION compteEmployeParProjet(idProjet VARCHAR(12)) RETURNS INT
BEGIN
    DECLARE compte INT;
    SELECT COUNT(*) INTO compte FROM employeprojet WHERE noProjet=idProjet;
 RETURN compte;
END//
DELIMITER ;


DROP FUNCTION IF EXISTS EmployeImplication;
DELIMITER //
CREATE FUNCTION EmployeImplication(idemploye VARCHAR(10)) RETURNS INT
BEGIN
    DECLARE compte INT;
    SELECT COUNT(*) INTO compte FROM employeprojet WHERE matricule=idemploye;
 RETURN compte;
END//
DELIMITER ;

DROP FUNCTION IF EXISTS budgetProjet;
DELIMITER //
CREATE FUNCTION budgetProjet(idProjet VARCHAR(12)) RETURNS DOUBLE
BEGIN
    DECLARE nb DOUBLE;
    SELECT budget INTO nb FROM projet WHERE noProjet=idProjet;
 RETURN nb;
END//
DELIMITER ;

DROP FUNCTION IF EXISTS totalDesSalaires;
DELIMITER //
CREATE FUNCTION totalDesSalaires(idProjet VARCHAR(12)) RETURNS DOUBLE
BEGIN
    DECLARE nb double;
    SELECT totalSalaire INTO nb FROM projet WHERE noProjet=idProjet;
 RETURN nb;
END//
DELIMITER ;