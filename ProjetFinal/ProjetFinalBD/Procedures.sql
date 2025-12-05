/*Logan Morin*/

-- 1
DROP PROCEDURE IF EXISTS employe_par_matricule;
DELIMITER //
CREATE PROCEDURE employe_par_matricule(IN _matricule VARCHAR(10))
BEGIN
    SELECT *
    FROM employe
    WHERE matricule=_matricule;
end //
DELIMITER ;

-- 2
DROP PROCEDURE IF EXISTS client_par_id;
DELIMITER //
CREATE PROCEDURE client_par_id(IN _id INT)
BEGIN
    SELECT *
    FROM client
    WHERE id=_id;
END //
DELIMITER ;

-- 3
DROP PROCEDURE IF EXISTS projet_par_no;
DELIMITER //
CREATE PROCEDURE projet_par_no(IN _no VARCHAR(12))
BEGIN
    SELECT *
    FROM projet
    WHERE noProjet=_no;
end //
DELIMITER ;

-- 4
DROP PROCEDURE IF EXISTS projet_par_idClient;
DELIMITER //
CREATE PROCEDURE projet_par_idClient(IN _idClient INT)
BEGIN
    SELECT *
    FROM projet
    WHERE idClient=_idClient;
end //
DELIMITER ;

-- 5
DROP PROCEDURE IF EXISTS employes_de_projet;
DELIMITER //
CREATE PROCEDURE employes_de_projet(IN _no VARCHAR(12))
BEGIN
    SELECT *
    FROM employe
    WHERE matricule IN (SELECT matricule
                        FROM employeprojet
                        WHERE noProjet=_no);
end //
DELIMITER ;