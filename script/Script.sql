create database locale_server;
use locale_server;

CREATE TABLE produit(
    id int auto_increment,
    nom_article varchar(20),
    prixunitaire double,
    quantite double,
    PRIMARY KEY(id)
);

//test datas for localdb
INSERT INTO produit (nom_article, prixunitaire, quantite) VALUES
    ("Pizza",20000,10),
    ("Humbergur",15000,10),
    ("Tacos",20000,20);

CREATE TABLE vente(
    id int auto_increment,
    dateetheure timestamp,
    PRIMARY KEY(id)
);

//test datas for localdb
INSERT INTO vente (dateetheure) VALUES 
    ('2017-01-31 12:12:25'),
    ('2023-06-09 18:52:00');
    

CREATE TABLE details_vente(
    id int auto_increment,
    id_vente int,
    id_produit int,
    quantite double,
    prix_totale double,
    PRIMARY KEY(id),
    FOREIGN KEY (id_vente) REFERENCES vente(id)
);

//test datas for localdb
INSERT INTO details_vente (id_vente,id_produit,quantite,prix_totale) VALUES
    (1,1,2,40000),
    (2,3,1,20000),
    (2,2,3,45000);

CREATE TABLE status_table(
    id int auto_increment,
    status_code int,
    PRIMARY KEY (id)
);
//raha 0 ny status_code dia tsy nisy erreur ilay insertion / raha 1 ilay status_code dia nety ilay insertion






