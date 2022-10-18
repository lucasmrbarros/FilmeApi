using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Data.Sessao;
using FilmesApi.Models;
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
    public class SessaoServices
    {
        private AppDbContext _context;
        private Mapper _mapper;

        public SessaoServices(AppDbContext context, Mapper map)
        {
            _context = context;
            _mapper = map;
        }
        
        public ReadSessaoDto AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto>RecuperaSessao()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();
            if(sessoes == null)
            {
                return null;
            }

            return _mapper.Map<List<ReadSessaoDto>>(sessoes);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return null;
            }

            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return sessaoDto;
        }

        public Result AtualizaSessao(int id, UpdateSessaoDto sessadoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return null;
            }

            _mapper.Map(sessadoDto, sessao);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result RemoveSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return null;
            }

            _context.Remove(sessao);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
