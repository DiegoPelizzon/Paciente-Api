using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Dominio.Entidade
{
    [Table("paciente")]
    public class PacienteEntidade
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public DateTime datanascimento { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
        public bool situacao { get; set; }
    }
}
