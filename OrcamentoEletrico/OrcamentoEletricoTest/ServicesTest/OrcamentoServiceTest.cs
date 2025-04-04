using Moq;
using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoApp.Services;
using static OrcamentoEletricoDomain.Enums.ClassificacaoPadrao;

namespace OrcamentoEletricoApp.Tests
{
    public class OrcamentoServiceTests
    {
        private readonly Mock<ILogger<OrcamentoService>> _mockLogger;
        private readonly Mock<IOrcamentoRepository> _mockOrcamentoRepository;
        private readonly Mock<IPessoaRepository> _mockPessoaRepository;
        private readonly OrcamentoService _orcamentoService;

        public OrcamentoServiceTests()
        {
            _mockLogger = new Mock<ILogger<OrcamentoService>>();
            _mockOrcamentoRepository = new Mock<IOrcamentoRepository>();
            _mockPessoaRepository = new Mock<IPessoaRepository>();
            _orcamentoService = new OrcamentoService(_mockLogger.Object, _mockOrcamentoRepository.Object, _mockPessoaRepository.Object);
        }

        [Fact]
        public async Task GerarOrcamento_ImovelValido_CadastraComSucesso()
        {
            // Arrange
            var imovel = new Imovel(100, 2, PadraoImovel.Medio, 1);


            _mockOrcamentoRepository.Setup(repo => repo.AddImovel(imovel)).Returns(Task.CompletedTask);
            _mockPessoaRepository.Setup(repo => repo.AdicionarProjetoPessoa(imovel.PessoaId, imovel)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _orcamentoService.gerarOrcamento(imovel);

            // Assert
            Assert.Equal(3000m, resultado); // 100m² * 15 * 2
        }

        [Fact]
        public async Task GerarOrcamento_ImovelInvalido_LancaExcecao()
        {
            // Arrange
            var imovel = new Imovel(100, 2, (PadraoImovel)99, 1);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _orcamentoService.gerarOrcamento(imovel));
            Assert.Equal("Ocorreu um erro ao tentar cadastrar o imóvel.", exception.Message);
        }

        [Fact]
        public void CalcularOrcamento_ClassificacaoBaixa_CalculoCorreto()
        {
            // Arrange
            var imovel = new Imovel(100, 2, PadraoImovel.Baixo, 1);

            // Act
            var resultado = _orcamentoService.calcularOrcamento(imovel);

            // Assert
            Assert.Equal(1600m, resultado); // 100m² * 8 * 2
        }

        [Fact]
        public void CalcularOrcamento_ClassificacaoInvalida_LancaExcecao()
        {
            // Arrange
            var imovel = new Imovel(100, 2, (PadraoImovel)99, 1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _orcamentoService.calcularOrcamento(imovel));
            Assert.Equal("Classificação inválida.", exception.Message);
        }
    }
}
