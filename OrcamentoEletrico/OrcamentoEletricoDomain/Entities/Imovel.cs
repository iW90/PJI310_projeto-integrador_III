using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrcamentoEletricoDomain.Enums;
using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletricoDomain.Entities
{
    public class Imovel
    {
        public Imovel(int metrosQuadrados, int numeroDePavimentos, PadraoImovel classificacao, int pessoaId)
        {
            MetrosQuadrados = metrosQuadrados;
            NumeroDePavimentos = numeroDePavimentos;
            Classificacao = classificacao;
            PessoaId = pessoaId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public int MetrosQuadrados { get; private set; }

        [Required]
        public int NumeroDePavimentos { get; private set; }

        [Required]
        public PadraoImovel Classificacao { get; private set; }

        public int PessoaId { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa? Pessoa { get; set; }
    }
}