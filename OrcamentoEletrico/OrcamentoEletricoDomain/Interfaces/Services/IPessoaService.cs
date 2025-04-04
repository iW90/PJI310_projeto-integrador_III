using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<int> cadastrarPessoa(Pessoa pessoa);
    }
}
