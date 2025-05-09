using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces.Services
{
    public interface IOrcamentoService
    {
        Task<decimal> gerarOrcamento(Imovel imovel);
    }
}
