using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records.NotUsed;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        private CinemaServices _services;
        public CinemaController(CinemaServices services)
        {
            _services = services;
        }
  

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _services.AdcionarCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas()
        {
            List<ReadCinemaDto> readDto = _services.RecuperaCinemas();

            if(readDto == null)
            {
                return NotFound();
            }
            
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int Id)
        {
            ReadCinemaDto readDto = _services.RecuperaCinemasPorId(Id);

            if (readDto == null)
            {
                return NotFound();
            }

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _services.AtualizaCinemas(id, cinemaDto);

            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _services.DeletaCinema(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
