-- Logan Morin

-- Client
insert into client (nom, adresse, telephone, email) values ('Urson Devenport', '07 Riverside Lane', '494-788-8569', 'udevenport0@clickbank.net');
insert into client (nom, adresse, telephone, email) values ('Bing Rillatt', '137 Clove Parkway', '618-888-8037', 'brillatt1@cloudflare.com');
insert into client (nom, adresse, telephone, email) values ('Gloria Shelmardine', '9229 Jay Street', '215-226-7620', 'gshelmardine2@rakuten.co.jp');
insert into client (nom, adresse, telephone, email) values ('Clarie Gascoyen', '7100 Annamark Place', '532-843-0775', 'cgascoyen3@ca.gov');
insert into client (nom, adresse, telephone, email) values ('Danita Forster', '413 Di Loreto Parkway', '798-479-0417', 'dforster4@yellowpages.com');
insert into client (nom, adresse, telephone, email) values ('Sherye Chiplin', '32 Maywood Junction', '375-305-2406', 'schiplin5@columbia.edu');
insert into client (nom, adresse, telephone, email) values ('Adolphe Ventum', '666 Steensland Street', '191-462-1753', 'aventum6@newyorker.com');
insert into client (nom, adresse, telephone, email) values ('Hersch Adlam', '334 Reinke Avenue', '424-426-0608', 'hadlam7@spiegel.de');
insert into client (nom, adresse, telephone, email) values ('Mandy Askwith', '19 Novick Pass', '111-925-5319', 'maskwith8@blogspot.com');
insert into client (nom, adresse, telephone, email) values ('Tallulah Finker', '8414 Upham Lane', '737-555-2738', 'tfinker9@hp.com');

-- Projet
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('BBQ Sauce', '2018-03-07', 'A smoky barbecue sauce, ideal for grilling and dipping.', '4645.45', '5510.81','Terminé',120);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Infrared Space Heater', '2006-01-31', 'Energy-efficient infrared heater for home use.', '2600.04', '2711.91','En cours',931);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Orange Ginger Vinaigrette', '2013-01-29', 'Tangy vinaigrette with orange and ginger flavors.', '5515.24', '7261.24','En cours',134);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Electric Stir Fry Pan', '2017-07-08', 'Large stir fry pan with non-stick surface.', '4961.66', '3500.94','Terminé',375);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Suction Cup Hooks', '2025-08-22', 'Reusable suction cup hooks for hanging items.', '4063.09', '5895.60','Terminé',965);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Almond Milk Yogurt', '2006-03-19', 'Creamy yogurt made from almond milk, vegan-friendly.', '9791.60', '5192.41','En cours',120);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Baby Safety Corner Guards', '2023-06-07', 'Soft corner protectors to keep babies safe at home.', '6213.40', '9434.36','En cours',495);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Cinnamon Ice Cream', '2013-08-11', 'Creamy ice cream with a warm cinnamon flavor, perfect for dessert.', '7908.70', '6761.64','Terminé',820);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Toilet Paper (12 rolls)', '2013-09-29', 'Soft and strong toilet paper for everyday use.', '9869.22', '4089.39','En cours',820);
insert into projet (titre, dateDebut, description, budget, totalSalaire,statut,idClient) values ('Hiking Water Bottle with Filter', '2024-11-01', '8oz water bottle with built-in filter for clean drinking water.', '1530.76', '2117.26','En cours',716);

-- Employe
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Munns', 'Matthaeus', '1989-01-12', 'mmunns0@flickr.com', '32061 Susan Park', '2025-11-19', '21.04', 'http://dummyimage.com/239x100.png/ff4444/ffffff','Journalier');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Duetschens', 'Drusie', '1951-03-24', 'dduetschens1@bbc.co.uk', '4 International Lane', '2020-12-20', '18.20', 'http://dummyimage.com/237x100.png/ff4444/ffffff','Permanent');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Daveran', 'Rossy', '1985-12-09', 'rdaveran2@irs.gov', '81 Commercial Drive', '2021-05-13', '15.31', 'http://dummyimage.com/153x100.png/cc0000/ffffff','Journalier');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Kunc', 'Ericka', '1982-08-04', 'ekunc3@twitter.com', '8 Pine View Lane', '2022-09-22', '21.58', 'http://dummyimage.com/234x100.png/cc0000/ffffff','Journalier');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Zanicchelli', 'Margy', '1982-06-22', 'mzanicchelli4@exblog.jp', '25759 Shopko Crossing', '2022-08-22', '19.82', 'http://dummyimage.com/187x100.png/dddddd/000000','Permanent');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Beddows', 'Liz', '1985-10-05', 'lbeddows5@newsvine.com', '22 Oak Alley', '2021-11-21', '15.47', 'http://dummyimage.com/132x100.png/5fa2dd/ffffff','Permanent');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Collet', 'Laina', '1978-12-29', 'lcollet6@angelfire.com', '8623 Old Shore Trail', '2023-12-18', '22.65', 'http://dummyimage.com/186x100.png/5fa2dd/ffffff','Permanent');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Kruschev', 'Ignatius', '1966-04-20', 'ikruschev7@istockphoto.com', '8323 Sutteridge Trail', '2023-06-26', '22.78', 'http://dummyimage.com/249x100.png/dddddd/000000','Permanent');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Bhatia', 'Ardath', '1970-04-23', 'abhatia8@businessweek.com', '31 Hoffman Way', '2021-07-05', '23.03', 'http://dummyimage.com/108x100.png/ff4444/ffffff','Journalier');
insert into employe (nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut) values ('Orlton', 'Iris', '1973-03-22', 'iorlton9@google.de', '58 Red Cloud Street', '2025-02-04', '17.93', 'http://dummyimage.com/218x100.png/ff4444/ffffff','Permanent');

-- EmployeProjet
/*
 id INT AUTO_INCREMENT PRIMARY KEY ,
nbHrs INT,
salaireCumul DOUBLE,
matricule VARCHAR(10),
noProjet VARCHAR(12),
FOREIGN KEY (matricule) REFERENCES Employe(matricule),
FOREIGN KEY (noProjet) REFERENCES Projet(noProjet)
 */