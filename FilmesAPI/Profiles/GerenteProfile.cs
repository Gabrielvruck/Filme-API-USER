using AutoMapper;
using FilmesAPI.Data.Dto.Gerente;
using FilmesAPI.Models;
using System.Linq;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();

            //Gerente entidade vai retorna
            //um objeto animo referente ao cinema da maneira que for passado as informacoes

            //Estamos mapeando de um Gerente para um ReadGerenteDto. Para o campo Cinemas, estamos selecionando apenas os campos Id, Nome, Endereco e EnderedoId.
            CreateMap<Gerente, ReadGerenteDto>().ForMember(gerente=> gerente.Cinemas,opts=>opts
            .MapFrom(gerente => gerente.Cinemas.Select(c=> new { 
                c.Id ,c.Nome,c.Endereco,c.EnderecoId
            })));
        }
    }
}
