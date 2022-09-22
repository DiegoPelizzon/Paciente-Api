using Paciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Dominio.IRepositorio
{
    public interface IRepositorioPaciente: IRepositorioGenerico<PacienteEntidade>
    {

        public PacienteEntidade BuscarNome(string nome);

        public List<PacienteEntidade> BuscarInativos();

        public List<PacienteEntidade> BuscarCodigo(string codigo);

        public List<PacienteEntidade> BuscarPorNascimento(DateTime data);

        public bool VerificacaoDocumentoCpf(string cpf);

        public bool VerificarId(int id);

        public bool VerificarNascimento(DateTime nascimento);

        public bool VerificarContato(string contato);


    }
}
