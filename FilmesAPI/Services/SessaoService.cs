using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Sessao;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(f => f.Id.Equals(id));
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return (sessaoDto);
            }

            return null;
        }

        public List<ReadSessaoDto> RecuperarSessoes()
        {
            List<Sessao> sessaos = _context.Sessoes.ToList();
            if (sessaos == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadSessaoDto>>(sessaos);
        }
    }
}
