using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Data.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoServices _service;

        public SessaoController(SessaoServices service)
        {
            _service = service;
        }

        [HttpPost]

        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _service.AdicionarSessao(sessaoDto);

            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]

        public IActionResult RecuperaSessao()
        {
            List<ReadSessaoDto> readDto = _service.RecuperaSessao();

            if (readDto == null)
            {
                return NotFound();  
            }

            return Ok(readDto);
        }

        [HttpGet("[id]")]
        
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto sessaoDto = _service.RecuperaSessaoPorId(id);

            if(sessaoDto == null)
            {
                return NotFound();
            }

            return Ok(sessaoDto);
        }

        [HttpPut("[id]")]


        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result resultado = _service.AtualizaSessao(id, sessaoDto);

            if(resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("[id]")]

        public IActionResult DeletaSessao(int id)
        {
            Result resultado = _service.RemoveSessao(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
