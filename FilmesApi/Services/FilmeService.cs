using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private Mapper _mapper;
        private AppDbContext _context;

        public FilmeService(Mapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadFilmeDto AdicionarFilme (CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }
        
        public List<ReadFilmeDto> RecuperaCinemas()
        {
            List<Filme> filmes = _context.Filmes.ToList();

            if (filmes == null)
            {
                return null;
            }

            return _mapper.Map<List<ReadFilmeDto>>(filmes);
         }

        public ReadFilmeDto RecuperaFilmePorId(int id)
        {
            Filme filmes = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);

            if(filmes == null)
            {
                return null;
            }
            
            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filmes);
            return filmeDto;
        }

        public Result AtualizaFilmes(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(Filmes => Filmes.Id == id);

            if (filme == null)
            {
                return null;
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteFilmes(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return null;
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
     }
}
