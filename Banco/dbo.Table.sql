CREATE TABLE BANDAS
(
	Nome VARCHAR(60) NOT NULL,
	Album  VARCHAR(60) NOT NULL,
	Faixas INT NOT NULL,
	Musica  VARCHAR(60) NOT NULL
)


select * from BANDAS

UPDATE BANDAS SET FAIXAS = 13 WHERE NOME = 'Bon Jovi' AND ALBUM = 'Crush' 

INSERT INTO BANDAS (Nome, Album, Faixas, Musica) VALUES
('Bon Jovi', 'Crush', 1, 'Its My Life'),
('Bon Jovi', 'Crush', 2, 'Say It Isnt So'),
('Bon Jovi', 'Crush', 3, 'Thank You For Loving Me'),
('Bon Jovi', 'Crush', 4, 'Two Story Town'),
('Bon Jovi', 'Crush', 5, 'Next 100 Years'),
('Bon Jovi', 'Crush', 6, 'Just Older'),
('Bon Jovi', 'Crush', 7, 'Mystery Train'),
('Bon Jovi', 'Crush', 8, 'Save the World'),
('Bon Jovi', 'Crush', 9, 'Captain Crash & The Beauty Queen From Mars'),
('Bon Jovi', 'Crush', 10, 'Shes a Mystery'),
('Bon Jovi', 'Crush', 11, 'I Got the Girl'),
('Bon Jovi', 'Crush', 12, 'One Wild Night'),
('Bon Jovi', 'Crush', 13, 'I Could Make a Living Out of Lovin You')


