using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }


        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readSessaoDto.Id }, readSessaoDto);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            List<ReadSessaoDto> readSessaoDtos = _sessaoService.RecuperarSessoes();
            if (readSessaoDtos == null) return NotFound();
            return Ok(readSessaoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.RecuperaSessoesPorId(id);
            if (readSessaoDto == null) return NotFound();
            return Ok(readSessaoDto);

        }

    }
}
