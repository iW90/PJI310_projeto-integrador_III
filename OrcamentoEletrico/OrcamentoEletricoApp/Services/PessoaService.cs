using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoDomain.Interfaces.Services;

namespace OrcamentoEletricoApp.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ILogger<PessoaService> _logger;
        private readonly IPessoaRepository _repository;

        public PessoaService(ILogger<PessoaService> logger, IPessoaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<int> cadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                var cliente = await _repository.GetPessoaPorEmail(pessoa.Email);

                if (cliente != null)
                {
                    _logger.LogInformation("Usuario ja cadastrado.");
                    return cliente.Id;
                }

                await _repository.AddPessoa(pessoa);

                _logger.LogInformation("Usuario cadastrado com sucesso.");
                return pessoa.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar pessoa.");
                throw new InvalidOperationException("Ocorreu um erro ao tentar cadastrar a pessoa.", ex);
            }
        }
    }
}
