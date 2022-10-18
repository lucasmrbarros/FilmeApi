using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class CinemaServices
    { 
        private IMapper _mapper;
        private AppDbContext _context;
        
        public CinemaServices(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadCinemaDto AdcionarCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas()
        {
            List<Cinema> Cinemas = _context.Cinemas.ToList();

            if (Cinemas == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadCinemaDto>>(Cinemas);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            
            if (cinema == null)
            {
                return null;
            }

            ReadCinemaDto CinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return CinemaDto;
        }

        public Result AtualizaCinemas(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            Cinema cinemas = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinemas == null)
            {
                return Result.Fail("Cinema não encontrado");
            }

            _context.Remove(cinemas);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
