Funcionalidade: Room
	Testes integrados das funcionalidades relacionadas ao end-point Room

Esquema do Cenario: Obter Room inexistente ou existente
	Dado que o endpoint do Room é 'Room/GetById'
	E que o método http do Room é 'GET'
	E que o id é 3
	Quando obter o Room
	Então a resposta do Room será <resposta>

	Exemplos: 
		| id | resposta |
		| 3  | 200      |
		| 1  | 404      |

Esquema do Cenario: Obter Room por tipo
	Dado que o endpoint do Room é 'Room/GetByTypeRoomId'
	E que o método http do Room é 'GET'
	E que o id é 1
	Quando obter o Room
	Então a resposta do Room será 200

Esquema do Cenario: Criar Room
	Dado que o endpoint do Room é 'Room/Create'
	E que o método http do Room é 'POST'
	E que o andar é 2
	E que o numero do Room é 202
	E que a situation é I
	E que o TypeRoom é 2
	Quando criar o Room
	Então a resposta do Room será 201

Esquema do Cenario: Atualizar Room
	Dado que o endpoint do Room é 'Room/Update'
	E que o método http do Room é 'PATCH'
	E que o id é 3
	E que a situation é D
	Quando atualizar o Room
	Então a resposta do Room será 200