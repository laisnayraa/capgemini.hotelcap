Funcionalidade: Occupation
	Testes integrados das funcionalidades relacionadas ao end-point Occupation


Esquema do Cenario: Create Occupation
	Dado que o endpoint é 'Occupation/Create'
	E que o método http é 'POST'
	E que o dailyAmount é 2
	E que o date é 2020-12-02T14:03:55.983Z
	E que o situation é N
	E que o client id é 1
	E que o room Id é 1
	Quando obter o occupation
	Então a resposta será 201