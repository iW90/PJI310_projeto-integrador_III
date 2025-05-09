using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoInfra.Database
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            // Nome da tabela
            builder.ToTable("Clientes");

            // Configuração da chave primária
            builder.HasKey(pk => pk.Id);

            // Configuração do Id para ser gerado automaticamente
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            // Configuração das propriedades
            builder.Property(p => p.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Telefone)
                   .HasMaxLength(20);

            builder.Property(p => p.Endereco)
                   .HasMaxLength(200);

            // Relacionamento: uma Pessoa pode ter zero ou mais Imóveis
            builder.HasMany(p => p.ListaImoveis)        // Lista de imóveis
                   .WithOne(i => i.Pessoa)              // Relação inversa definida na classe Imovel
                   .HasForeignKey(i => i.PessoaId)      // Chave estrangeira
                   .OnDelete(DeleteBehavior.Cascade);   // Exclui Imóveis se a Pessoa for excluída
        }
    }
}
