Funcionalidade: Client
	Testes integrados das funcionalidades relacionadas ao end-point Client

Esquema do Cenario: Inserir Client
	Dado que o endpoint do Cliente é 'Client/Create'
	E que o método http do Cliente é 'POST'
	E que o name é Maria
	E que o CPF é 999.999.999-99
	E que o hashs é OSE3LOCE
	Quando obter o client
	Então a resposta do Cliente será 201


Esquema do Cenario: Listar Client
	Dado que o endpoint do Cliente é 'Client/GetById'
	E que o método http do Cliente é 'GET'
	E que o id do Cliente é 1
	Quando obter o client
	Então a resposta do Cliente será 200