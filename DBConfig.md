# Configuração do banco de dados 

## Localhost:

### Acesso

No arquivo `appsettings.json` (em "OrcamentoEletrico/OrcamentoEletrico") haverá a seguinte linha de código:

```
"DefaultConnectionMySQL": "Server=localhost;Database=OrcamentoEletrico;User=admin;Password=admin;"
```

Substitua o valor "admin" do User e Password pelos correspondentes do seu banco de dados local MySQL:

- `User=SEU_USUARIO;Password=SUA_SENHA;`



### Migrations
 
Executar comandos abaixo na raiz da aplicação (onde fica a solution OrcamentoEletrico.sln):

`\PJI240_projeto-integrador_II\OrcamentoEletrico`


- Criar um migration (configuração do banco)

	```sh
	dotnet ef migrations add InitialCreate --startup-project./OrcamentoEletrico/OrcamentoEletrico.csproj -p ./OrcamentoEletricoInfra/OrcamentoEletricoInfra.csproj
	```

- Atualizar banco com essa nova configuração:

	```sh
	dotnet ef database update --startup-project ./OrcamentoEletrico/OrcamentoEletrico.csproj -p ./OrcamentoEletricoInfra/OrcamentoEletricoInfra.csproj
	```

### Scripts de Testes

```sql
USE OrcamentoEletrico;

SELECT *
FROM clientes
LIMIT 100;

SELECT *
FROM projetos
LIMIT 100;

SELECT *
FROM clientes c
JOIN projetos i ON c.Id = i.PessoaId
WHERE c.Id = 17;
```
