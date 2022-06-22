using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readFilmeDto = _filmeService.AdicionarFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readFilmeDto.Id }, readFilmeDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin,regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmesPorClassificacao([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readFilmeDtos = _filmeService.RecuperarFilmesPorClassificacao(classificacaoEtaria);
            if (readFilmeDtos != null)
            {
                return Ok(readFilmeDtos);
            }

            return NotFound();
        }

        //[HttpGet]
        //public IActionResult RecuperarFilmes()
        //{
        //    List<Filme> filmes;
        //    filmes = _context.Filmes.ToList();
        //    List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
        //    if (filmes.Any())
        //    {
        //        return Ok(readDto);
        //    }
        //    return NotFound();
        //}

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperarFilmesPorId(id);
            if (readFilmeDto != null)
            {
                return Ok(readFilmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizarFilme(id, filmeDto);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result resultado = _filmeService.DeletarFilme(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
