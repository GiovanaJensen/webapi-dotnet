using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos
{
    public class ReadEnderecoDto
    {
        public int id {get; set;}
        public string Logradouro {get; set;}
        public int Numero {get; set;}
    }
}