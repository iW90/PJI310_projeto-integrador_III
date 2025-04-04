using Moq;
using Microsoft.Extensions.Logging;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoDomain.Interfaces.Services;
using OrcamentoEletricoApp.Services;

namespace OrcamentoEletricoApp.Tests
{
    public class PessoaServiceTest
    {
        private readonly Mock<IPessoaRepository> _mockRepository;
        private readonly Mock<ILogger<PessoaService>> _mockLogger;
        private readonly IPessoaService _pessoaService;

        public PessoaServiceTest()
        {
            _mockRepository = new Mock<IPessoaRepository>();
            _mockLogger = new Mock<ILogger<PessoaService>>();
            _pessoaService = new PessoaService(_mockLogger.Object, _mockRepository.Object);
        }

        [Fact]
        public async Task CadastrarPessoa_UsuarioJaCadastrado_RetornaId()
        {
            // Arrange
            var pessoa = new Pessoa("Nome Completo", "email@example.com", "123456789", "Rua Exemplo");
            _mockRepository.Setup(repo => repo.GetPessoaPorEmail(pessoa.Email)).ReturnsAsync(pessoa);

            // Act
            var result = await _pessoaService.cadastrarPessoa(pessoa);

            // Assert
            Assert.Equal(pessoa.Id, result);
        }

        [Fact]
        public async Task CadastrarPessoa_NovoUsuario_CadastraComSucesso()
        {
            // Arrange
            var pessoa = new Pessoa("Nome Completo", "email@example.com", "123456789", "Rua Exemplo");
            _mockRepository.Setup(repo => repo.GetPessoaPorEmail(pessoa.Email)).ReturnsAsync((Pessoa)null);

            // Act
            var result = await _pessoaService.cadastrarPessoa(pessoa);

            // Assert
            Assert.Equal(pessoa.Id, result);
        }
    }
}
