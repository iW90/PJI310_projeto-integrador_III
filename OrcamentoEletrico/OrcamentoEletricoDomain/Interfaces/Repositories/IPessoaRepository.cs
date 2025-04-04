using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletricoDomain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task AddPessoa(Pessoa pessoa);

        Task<Pessoa?> GetPessoaPorEmail(string email);

        Task<Pessoa?> GetPessoaPorId(int pessoaId);

        Task AdicionarProjetoPessoa(int pessoaId, Imovel imovel);
    }
}
