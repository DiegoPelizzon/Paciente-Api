using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Dominio.Dto
{
    public class PacienteDto
    {
        public string codigoPaciente { get; set; }
        public string nomePaciente { get; set; }
        public string sexoPaciente { get; set; }
        public DateTime datanascimentoPaciente { get; set; }
        public string cpfPaciente { get; set; }
        public string cepPaciente { get; set; }
        public bool situacaoPaciente { get; set; }
    }
}
