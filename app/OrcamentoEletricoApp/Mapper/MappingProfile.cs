using AutoMapper;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoApp.Models.Requests;

namespace OrcamentoEletricoApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento para Pessoa
            CreateMap<PessoaRequest, Pessoa>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ConstructUsing(src => new Pessoa(
                    src.NomeCompleto,
                    src.Email,
                    src.Telefone ?? string.Empty,
                    src.Endereco ?? string.Empty));

            CreateMap<Pessoa, PessoaRequest>();

            // Mapeamento para Imovel
            CreateMap<ImovelRequest, Imovel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ConstructUsing(src => new Imovel(
                    src.MetrosQuadrados,
                    src.NumeroDePavimentos,
                    src.Classificacao,
                    src.PessoaId));

            CreateMap<Imovel, ImovelRequest>();
        }
    }
}