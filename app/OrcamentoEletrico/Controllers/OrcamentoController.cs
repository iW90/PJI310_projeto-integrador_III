using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrcamentoEletricoApp.Models.Requests;
using OrcamentoEletricoApp.Models.Responses;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces.Services;

namespace OrcamentoEletrico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrcamentoController : BaseController
    {
        private readonly IOrcamentoService _orcamentoService;
        private readonly IMapper _mapper;

        public OrcamentoController(IOrcamentoService orcamentoService, IMapper mapper)
        {
            _orcamentoService = orcamentoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gera um novo orçamento.
        /// </summary>
        /// <param name="request">O imovel a ser cadastrado e orçado.</param>
        /// <returns>O status de cadastramento e o valor do orçamento.</returns>
        [HttpPost("gerar-orcamento")]
        public async Task<IActionResult> GerarOrcamento([FromBody] ImovelRequest request)
        {
            try
            {
                // 1. Criação da entidade Imovel
                var imovel = _mapper.Map<Imovel>(request);

                // 2. Cadastra o imóvel e retorna o valor orçado
                var orcamento = await _orcamentoService.gerarOrcamento(imovel);

                var response = new ImovelResponse
                {
                    ValorOrcamento = orcamento
                };

                // 3. Retorna o resultado e o status da operação
                return HandleActionResult(orcamento);
            }
            catch (InvalidOperationException ex)
            {
                return HandleBadRequestResult(ex.Message);
            }
        }
    }
}
