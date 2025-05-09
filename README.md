# PJI310_projeto-integrador_III

Projeto integrador realizado para a Univesp

## 🧾 OrcamentoEletrico

Sistema para cadastro de pessoas e geração de orçamentos elétricos. Desenvolvido em ASP.NET Core 8.0, com MySQL e hospedado via Railway.

> Acesse em: https://orcamentos-eletricos.up.railway.app/

### 🚀 Tecnologias

- [.NET 8.0](https://dotnet.microsoft.com/)
- [Razor Pages](https://learn.microsoft.com/aspnet/core/razor-pages/)
- [Docker](https://www.docker.com/)
- [MySQL](https://www.mysql.com/)
- [Railway](https://railway.app/)


### 📦 Estrutura

```
.
├── app
│   ├── OrcamentoEletrico/         # Camada de visualização (Razor)
│   │   ├── Controllers/
│   │   ├── Views/
│   │   ├── wwwroot/
│   │   ├── Program.cs
│   │   └── launchSettings.json
│   ├── OrcamentoEletricoApp/      # Camada de aplicação (Regras de Negócio)
│   │   ├── Mapper/
│   │   ├── Models/
│   │   └── Services/
│   ├── OrcamentoEletricoDomain/   # Camada de Domínio (Entidades e interfaces)
│   │   ├── Entities/
│   │   ├── Enums/
│   │   └── Interfaces/
│   ├── OrcamentoEletricoInfra/    # Camada de Infraestrutura (Banco de Dados)
│   │   ├── Database/
│   │   ├── Migrations/
│   │   └── Repositories/
│   └── OrcamentoEletricoTest/     # Camada de Testes Automatizados (unitários)
│       └── ServicesTest/
├── Dockerfile
├── OrcamentoEletrico.sln
└── LICENSE
```