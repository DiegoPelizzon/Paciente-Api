using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Dominio.Dto
{
    public class PacienteDto
    {
        public string codigoPaciente { get; set; }

        [Required(ErrorMessage ="O campo não pode ficar em branco")]
        [StringLength(40, ErrorMessage ="Nome não pode ter mais que 40 caracteres")]
        public string nomePaciente { get; set; }
        public string sexoPaciente { get; set; }

        [Required(ErrorMessage ="O campo não pode ficar em branco")]
        [Phone (ErrorMessage ="numero de telefone invalido")]
        public string contatoPaciente { get; set; }
        public DateTime datanascimentoPaciente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        [StringLength(11, ErrorMessage = "CPF não pode ter mais ou menos que 11 caracteres", MinimumLength =11)]
        public string cpfPaciente { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        [StringLength(8, ErrorMessage = "CEP não pode ter mais ou menos que 8 caracteres", MinimumLength = 8)]
        public string cepPaciente { get; set; }
        public bool situacaoPaciente { get; set; }
    }
}
