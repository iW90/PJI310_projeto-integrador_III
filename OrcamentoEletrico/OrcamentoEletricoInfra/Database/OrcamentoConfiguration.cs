using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoInfra.Database
{
    public class OrcamentoConfiguration : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            // Nome da tabela
            builder.ToTable("Projetos");

            // Configuração da chave primaria
            builder.HasKey(ik => ik.Id);

            // Configuração do Id para ser gerado automaticamente
            builder.Property(i => i.Id)
                   .ValueGeneratedOnAdd();

            // Configuração das propriedades
            builder.Property(i => i.MetrosQuadrados)
                   .IsRequired();

            builder.Property(i => i.NumeroDePavimentos)
                   .IsRequired();

            builder.Property(i => i.Classificacao)
                   .IsRequired();

            // Relacionamento: um Imóvel deve ter uma Pessoa
            builder.HasOne(i => i.Pessoa)               // Referencia a Pessoa
                   .WithMany(p => p.ListaImoveis)       // Relação inversa
                   .HasForeignKey(i => i.PessoaId)      // Chave estrangeira
                   .OnDelete(DeleteBehavior.Cascade);   // Exclui Imóvel se a Pessoa for excluída
        }
    }
}
