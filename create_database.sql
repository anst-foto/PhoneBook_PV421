--CREATE DATABASE phonebook_db;
--CREATE SCHEMA test;

CREATE TABLE table_persons(
    id SERIAL NOT NULL PRIMARY KEY,
    last_name TEXT NOT NULL,
    first_name TEXT NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TYPE phone_type AS ENUM ('Unknown', 'Mobile', 'Work', 'Home');
CREATE TABLE table_phones(
    id SERIAL NOT NULL PRIMARY KEY,
    type phone_type NOT NULL DEFAULT 'Unknown',
    number TEXT NOT NULL,
    person_id INTEGER NOT NULL,
    FOREIGN KEY (person_id) REFERENCES table_persons(id)
);

INSERT INTO table_persons(last_name, first_name, is_active) 
VALUES ('Kowalski', 'Jan', TRUE),
       ('Nowak', 'Adam', TRUE),
       ('Nowak', 'Anna', TRUE);

INSERT INTO table_phones(type, number, person_id)
VALUES ('Mobile', '123456789', 1),
       ('Mobile', '987654321', 2),
       ('Work', '123456789', 3),
       ('Work', '987654321', 1)


