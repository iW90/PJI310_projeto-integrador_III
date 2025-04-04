# Modelagem de Dados - UML

- [Ferramenta](https://www.planttext.com)

- Código-fonte
	```
	@startuml
	!theme vibrant

	package - <<Rectangle>>
	{
		class Pessoa ##white
		{
			__ Attributes __
			- Id: int <<PK>>
			- NomeCompleto: string
			- Email: string
			- Telefone: string
			- Endereco: string
			- ListaImoveis: Imovel[]
			__ Methods __
			.. Constructor ..
			+ Pessoa()
		}

		class Imovel ##white
		{
			__ Attributes __
			- Id: int <<PK>>
			- MetrosQuadrados: int
			- NumeroDePavimentos: int
			- Classificacao: PadraoImovel
			- PessoaId: int <<FK>>
			__ Methods __
			.. Constructor ..
			+ Imovel()
		}

		enum PadraoImovel ##white
		{
			Baixo = 1
			Medio = 2
			Alto = 3
		}

		' Relationships
		Pessoa "1" o-- "0..*" Imovel
	}

	@enduml
	```