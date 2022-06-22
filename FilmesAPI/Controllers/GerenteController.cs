using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionaGerente(gerenteDto);
            if (readGerenteDto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            List<ReadGerenteDto> readGerenteDtos = _gerenteService.RecuperarGerentes();
            if (readGerenteDtos == null) return NotFound();
            return Ok(readGerenteDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentePorId(id);
            if (readGerenteDto == null)
            {
                return NotFound();
            }
            return Ok(readGerenteDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result resultado = _gerenteService.DeletarGerente(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
