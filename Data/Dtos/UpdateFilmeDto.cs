using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApi.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        public string Titulo {get; set;}
        [Required(ErrorMessage = "O gênero do filmeé obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
        public string Genero {get; set;}
        [Required]
        [Range(70,600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duracao {get; set;}
    }
}