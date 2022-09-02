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
        public int idPaciente { get; set; }
        public string codigoPaciente { get; set; }

        [StringLength(40, ErrorMessage ="Nome não pode ter mais que 40 caracteres")]
        public string nomePaciente { get; set; }
        public string sexoPaciente { get; set; }
        public DateTime datanascimentoPaciente { get; set; }
        public string cpfPaciente { get; set; }
        public string cepPaciente { get; set; }
        public bool situacaoPaciente { get; set; }
    }
}
