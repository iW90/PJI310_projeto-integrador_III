using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces.Repositories
{
    public interface IOrcamentoRepository
    {
        Task AddImovel(Imovel imovel);
    }
}
