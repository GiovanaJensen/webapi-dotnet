using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult adicionaFilme([FromBody] Filme filme){
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(retornarFilmePorId), new { id = filme.Id}, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> retornarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 0){
            return filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult retornarFilmePorId(int id){
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            return Ok(filme);
        }
    }
}