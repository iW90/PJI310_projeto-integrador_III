using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrcamentoEletricoDomain.Entities
{
    public class Pessoa
    {
        public Pessoa(string nomeCompleto, string email, string? telefone, string? endereco)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; private set; }

        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        [Phone]
        public string? Telefone { get; private set; }

        public string? Endereco { get; private set; }

        public virtual List<Imovel> ListaImoveis { get; private set; } = new List<Imovel>();

        public void AdicionarImovel(Imovel imovel)
        {
            ArgumentNullException.ThrowIfNull(imovel);
            ListaImoveis.Add(imovel);
        }
    }
}