using Paciente.Dominio.Dto;
using Paciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Dominio.IRepositorio
{
    public interface IPacienteAplicacao
    {

        public void AdicionarPaciente(PacienteDto dto);

        public void AtualizarPaciente(PacienteDto dto);

        public List<PacienteEntidade> ListarPaciente();

        public void DeletarPaciente(int id);

        public PacienteEntidade ListarPacienteporId(int id);

        public List<PacienteEntidade> ListarPacienteporNascimento(DateTime nascimento);

        public List<PacienteEntidade> ListarPacientesInativos();

        public List<PacienteEntidade> ListarPacienteporCodigo(string codigo);
    }
}
