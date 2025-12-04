/*Gestion erreur*/

DELIMITER  //
CREATE PROCEDURE 5orLess()
    BEGIN
        DECLARE CONTINUE HANDLER FOR 1062
            BEGIN
                SELECT 'Ce projet à déjà 5 employés'   ;
            END ;
    END //
DELIMITER ;


DELIMITER  //
CREATE PROCEDURE clientSupression()
    BEGIN
        DECLARE CONTINUE HANDLER FOR 1062
            BEGIN
                SELECT 'suppression impossible, le client a des projets actifs'   ;
            END ;
    END //
DELIMITER ;


DELIMITER  //
CREATE PROCEDURE pasBonMotDePasse()
    BEGIN
        DECLARE CONTINUE HANDLER FOR 1062
            BEGIN
                SELECT 'suppression impossible, le client a des projets actifs'   ;
            END ;
    END //
DELIMITER ;