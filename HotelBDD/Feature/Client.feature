Funcionalidade: Client
	Testes integrados das funcionalidades relacionadas ao end-point Client

Esquema do Cenario: Inserir Client
	Dado que o endpoint do Client é 'Client/Create'
	E que o método http do Client é 'POST'
	E que o name é "Maria"
	E que o CPF é '999.999.999-99'
	E que o hashs é 'OSE3LOCE'
	Quando obter o client
	Então a resposta do Client será 201


Esquema do Cenario: Listar Client
	Dado que o endpoint do Client é 'Client/GetById'
	E que o método http do Client é 'GET'
	E que o id é 1
	Quando obter o client
	Então a resposta do Client será 200