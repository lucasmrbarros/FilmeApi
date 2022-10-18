using FilmesApi.Data.Dtos.Endereco;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnderecoController : Controller
    {
        private EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpPost]

        public IActionResult CriaEnderco (CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _service.CriaEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]

        public IActionResult RecuperaEnderco()
        {
            List<ReadEnderecoDto> enderecoDto = _service.RecuperarEndercos();

            if (enderecoDto == null)
            {
                return NotFound();
            }

            return Ok(enderecoDto);
        }

        [HttpGet("[id]")]

        public IActionResult RecuperaEnderecoPorId (int id)
        {
            ReadEnderecoDto enderecoDto = _service.RecuperaEnderecoPorId(id);

            if (enderecoDto == null)
            {
                return NotFound();
            }

            return Ok(enderecoDto);
        }

        [HttpPut("[Id]")]

        public IActionResult AtualizaEndereco (int id, UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _service.AtualizaEndereco(id, enderecoDto);

            if(resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("[Id]")]

        public IActionResult DeleteEndereco (int id)
        {
            Result resultado = _service.RemoveEndereco(id);

            if(resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
