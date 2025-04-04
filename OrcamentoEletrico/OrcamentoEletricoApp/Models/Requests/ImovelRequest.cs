using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletricoApp.Models.Requests
{
    public class ImovelRequest
    {
        public int PessoaId { get; set; }
        public int MetrosQuadrados { get; set; }
        public int NumeroDePavimentos { get; set; }
        public PadraoImovel Classificacao { get; set; }
    }
}
