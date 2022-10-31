using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.DTO.Usuario
{
    public class UsuarioCadastroDTO
    {
        [Required]
        [DisplayName("Nome do usuário")]
        [MaxLength(50, ErrorMessage ="Número de caracteres não pode ultrapassar 50")]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [DisplayName("Email do usuário")]
        [MaxLength(50, ErrorMessage = "Número de caracteres não pode ultrapassar 50")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DisplayName("Senha do usuário")]
        public string Senha { get; set; } = string.Empty;
    }

}