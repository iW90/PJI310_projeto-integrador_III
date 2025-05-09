using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoInfra.Database;

namespace OrcamentoEletricoInfra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Cadastra um novo imóvel no banco
        public async Task AddPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        // Busca uma pessoa no banco através da Id
        public async Task<Pessoa?> GetPessoaPorId(int pessoaId)
        {
            return await _context
                .Pessoas
                .FindAsync(pessoaId);
        }

        // Busca uma pessoa no banco através do email
        public async Task<Pessoa?> GetPessoaPorEmail(string email)
        {
            return await _context
                .Pessoas                    
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        // Atualiza lista de imóveis de uma pessoa através da Id
        public async Task AdicionarProjetoPessoa(int pessoaId, Imovel imovel)
        {
            var pessoa = await _context.Pessoas.FindAsync(pessoaId);

            if (pessoa != null)
            {
                pessoa.AdicionarImovel(imovel);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Pessoa não encontrada para cadastro de imóvel");
            }
        }
    }
}
