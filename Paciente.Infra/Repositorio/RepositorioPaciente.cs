using Paciente.Dominio.Entidade;
using Paciente.Dominio.IRepositorio;
using Paciente.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Infra.Repositorio
{
    public class RepositorioPaciente : RepositorioGenerico<PacienteEntidade>, IRepositorioPaciente
    {
        public RepositorioPaciente(BancoContext bancoContext) : base(bancoContext)
        {
        }

        public PacienteEntidade BuscarNome(string nome)
        {
            return DbSet.Where(entidade => entidade.nome == nome).FirstOrDefault();
        }

        public List<PacienteEntidade> BuscarCodigo(string codigo)
        {
            return DbSet.Where(entidade => entidade.codigo == codigo).ToList();
            
        }

        public List<PacienteEntidade> BuscarInativos()
        {
            return DbSet.Where(entidade => entidade.situacao == false).ToList();
        }

        public List<PacienteEntidade> BuscarPorNascimento(DateTime data)
        {
            return DbSet.Where(entidade => entidade.datanascimento == data).ToList();
        }

        public bool VerificacaoDocumentoCpf(string cpf)
        {
            return DbSet.Any(entidade => entidade.cpf == cpf);
        }
        public bool VerificarId(int id)
        {
            return DbSet.Any(entidade => entidade.id == id);
        }
        public bool VerificarNascimento(DateTime nascimento)
        {
            return DbSet.Any(entidade => entidade.datanascimento.Date == nascimento);
        }
    }
}
