using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
       private FilmeContext _context;
       private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto){
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornarEnderecoPorId), new {Id = endereco.Id}, endereco);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RetornarEnderecos(){
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult RetornarEnderecoPorId(int id){
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null){
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto){
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null){
                _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverEndereco(int id){
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null){
                _context.Remove(endereco);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}