Funcionalidade: TypeRoom
Testes integrados das funcionalidade relacionadas ao end-point TypeRoom

Esquema do Cenario: Inserir TypeRoom
	Dado que o endpoint do TypeRoom é 'TypeRoom/Create'
	E que o método http do TypeRoom é 'POST'
	E que a description é Stand
	E que o value é 500
	Quando obter o TypeRoom
	Então a resposta do TypeRoom será 201


	Esquema do Cenario: Listar TypeRoom por Id
	Dado que o endpoint do TypeRoom é 'TypeRoom/GetById'
	E que o método http do TypeRoom é 'GET'
	E que o id do TypeRoom é 1
	Quando obter o TypeRoom
	Então a resposta do TypeRoom será 200


	Esquema do Cenario: Listar todos os TypeRoom
	Dado que o endpoint do TypeRoom é 'TypeRoom/GetAll'
	E que o método http do TypeRoom é 'GET'
	Quando obter todos os TypeRoom
	Então a resposta do TypeRoom será 200