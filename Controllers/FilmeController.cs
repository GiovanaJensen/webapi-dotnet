using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;
using MyFirstWebApi.Data;
using MyFirstWebApi.Data.Dtos;
using AutoMapper;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public FilmeController(DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult adicionaFilme([FromBody] CreateFilmeDto filmeDto){
            var filme = _mapper.Map<Filme>(filmeDto);
            filme.Id = id++;
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(retornarFilmePorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> retornarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 0){
            return _context.Filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult retornarFilmePorId(int id){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            return Ok(filme);
        }

        [HttpPut("{id}")]
        public IActionResult atualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}