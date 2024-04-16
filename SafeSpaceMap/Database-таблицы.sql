CREATE DATABASE SSM;
USE SSM;

CREATE TABLE master (
password BINARY(32) NOT NULL PRIMARY KEY
)
ENGINE=InnoDB;
INSERT INTO master (password)
VALUES
( MD5('safe space manager'));

CREATE TABLE groups (
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(30) NOT NULL
)
ENGINE=InnoDB;
INSERT INTO groups (name)
VALUES
('Другое'),
('Вес'),
('Внешность'),
('Инвалидность'),
('ЛГБТ'),
('Национальность'),
('Пол'),
('Религия'),
('Цвет кожи'),
('ВИЧ+');

CREATE TABLE incident (
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
lati DOUBLE NOT NULL,
longi DOUBLE NOT NULL,
dattim DATETIME NOT NULL,
groupid INT NULL,
cmmnt TEXT NOT NULL,
apprdate DATE NOT NULL,
FOREIGN KEY (groupid)
REFERENCES groups (id)
ON DELETE SET NULL
ON UPDATE CASCADE
)
ENGINE=InnoDB;

CREATE TABLE unchecked  (
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
lati DOUBLE NOT NULL,
longi DOUBLE NOT NULL,
dattim DATETIME NOT NULL,
groupid INT NULL,
cmmnt TEXT NOT NULL,
FOREIGN KEY (groupid)
REFERENCES groups (id)
ON DELETE SET NULL
ON UPDATE CASCADE
)
ENGINE=InnoDB;