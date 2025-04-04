using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoInfra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new OrcamentoConfiguration());
        }
    }
}

/*
 * Executar comandos abaixo na raiz do projeto:
 *      \PJI240_projeto-integrador_II\OrcamentoEletrico
 * 
 * Criar um migration (configuração do banco)
 *      dotnet ef migrations add InitialCreate --startup-project ./OrcamentoEletrico/OrcamentoEletrico.csproj -p ./OrcamentoEletricoInfra/OrcamentoEletricoInfra.csproj
 * 
 * Atualizar banco com essa nova configuração:
 *      dotnet ef database update --startup-project ./OrcamentoEletrico/OrcamentoEletrico.csproj -p ./OrcamentoEletricoInfra/OrcamentoEletricoInfra.csproj
 * 
 */
