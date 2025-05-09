using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoDomain.Interfaces.Services;
using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletricoApp.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly ILogger<OrcamentoService> _logger;
        private readonly IOrcamentoRepository _orcamentoRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public OrcamentoService(ILogger<OrcamentoService> logger, IOrcamentoRepository orcamentoRepository, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _orcamentoRepository = orcamentoRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<decimal> gerarOrcamento(Imovel imovel)
        {
            try
            {
                var valor = calcularOrcamento(imovel);

                await _orcamentoRepository.AddImovel(imovel);

                await _pessoaRepository.AdicionarProjetoPessoa(imovel.PessoaId, imovel);

                _logger.LogInformation("Cadastro de projeto realizado com sucesso.");
                return valor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar imovel.");
                throw new InvalidOperationException("Ocorreu um erro ao tentar cadastrar o imóvel.", ex);
            }
        }

        public decimal calcularOrcamento(Imovel imovel)
        {
            decimal valorPorMetroQuadrado;

            switch (imovel.Classificacao)
            {
                case PadraoImovel.Baixo:
                    valorPorMetroQuadrado = 8m;
                    break;
                case PadraoImovel.Medio:
                    valorPorMetroQuadrado = 15m;
                    break;
                case PadraoImovel.Alto:
                    valorPorMetroQuadrado = 18m;
                    break;
                default:
                    _logger.LogInformation("Classificação inválida.");
                    throw new ArgumentException("Classificação inválida.");
            }

            _logger.LogInformation("Cálculo de orçamento realizado com sucesso.");
            return imovel.MetrosQuadrados * valorPorMetroQuadrado * imovel.NumeroDePavimentos;
        }
    }
}
