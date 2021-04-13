USE artcollection;

CREATE TABLE artists
(
    id INT AUTO_INCREMENT,
    name VARCHAR (255) NOT NULL UNIQUE,
    description VARCHAR (255),
    PRIMARY KEY (id)
);
-- DROP TABLE artists;

-- CREATE TABLE artists(
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) DEFAULT 'This is a description',
--   age INT NOT NULL,

--   PRIMARY KEY (id)
-- );

-- ALTER TABLE artists
-- ADD bio VARCHAR(255) DEFAULT 'Some default val';

-- TRUNCATE TABLE artists
-- to clear out the data and then you can make with correct columns


-- ALTER TABLE artists
-- DROP COLUMN bio;


-- CREATE TABLE paintings
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   year INT NOT NULL,
--   artistId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (artistId)
--     REFERENCES artists (id)
--     ON DELETE CASCADE
-- )