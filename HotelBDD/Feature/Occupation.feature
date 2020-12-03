Funcionalidade: Occupation
	Testes integrados das funcionalidades relacionadas ao end-point Occupation


Esquema do Cenario: Create Occupation
	Dado que o endpoint da Occupation é 'Occupation/Create'
	E que o método http da Occupation é 'POST'
	E que o dailyAmount é 2
	E que o date é 2020-12-02T14:03:55.983Z
	E que o client id é 3
	E que o room Id é 3
	Quando obter o occupation
	Então a resposta da Occupation será 201