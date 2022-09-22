using Paciente.Dominio.Dto;
using Paciente.Dominio.Entidade;
using Paciente.Dominio.IRepositorio;
using Paciente.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Aplicacao.Aplicacao
{
    public class PacienteAplicacao : IPacienteAplicacao
    {
        protected readonly IRepositorioPaciente _repositorioPaciente;

        public PacienteAplicacao(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente;
        }

        public void AdicionarPaciente(PacienteDto dto)
        {
            if (dto.datanascimentoPaciente >= DateTime.Now)
            {
                throw new Exception("data de nascimento não pode ser superior a data atual");
            }
            else if ((_repositorioPaciente.VerificacaoDocumentoCpf(dto.cpfPaciente)) == true)
            {
                throw new Exception("Já existe um paciente com esse CPF cadastrado");
            }
            else
            {
                var entidade = new PacienteEntidade();

                entidade.codigo = dto.codigoPaciente;
                entidade.nome = dto.nomePaciente;
                entidade.sexo = dto.sexoPaciente;
                entidade.datanascimento = dto.datanascimentoPaciente;
                entidade.cpf = dto.cpfPaciente;
                entidade.contato = dto.contato;
                entidade.cep = dto.cepPaciente;
                entidade.situacao = dto.situacaoPaciente;

                _repositorioPaciente.Criar(entidade);
                _repositorioPaciente.SalvarOk();

            }


        }

        public void AtualizarPaciente(PacienteDto dto,int id)
        {
            if (dto.datanascimentoPaciente >= DateTime.Now)
            {
                throw new Exception("data de nascimento não pode ser superior a data atual");
            }
            else if ((_repositorioPaciente.VerificacaoDocumentoCpf(dto.cpfPaciente)) == true)
            {
                throw new Exception("Já existe um paciente com esse CPF cadastrado");
            }
            else
            {
                PacienteEntidade entidade = _repositorioPaciente.BuscarporId(id);
                entidade.codigo = dto.codigoPaciente;
                entidade.nome = dto.nomePaciente;
                entidade.sexo = dto.sexoPaciente;
                entidade.datanascimento = dto.datanascimentoPaciente;
                entidade.cpf = dto.cpfPaciente;
                entidade.cep = dto.cepPaciente;

                _repositorioPaciente.Atualizar(entidade);
                _repositorioPaciente.SalvarOk();
            }
               
        }

        public List<PacienteEntidade> ListarPaciente()
        {
            return _repositorioPaciente.ObterTodos();
        }

        public PacienteEntidade ListarPacienteporId(int id)
        {
            if ((_repositorioPaciente.VerificarId(id) == true))
            {
                return _repositorioPaciente.BuscarporId(id);
            }
            else
            {
                throw new Exception("Desculpa mas esse Paciente não existe");
            }
        }

        public void DeletarPaciente(int id)
        {
            _repositorioPaciente.Deletar(id);
        }

        public List<PacienteEntidade> ListarPacienteporCodigo(string codigo)
        {
            return _repositorioPaciente.BuscarCodigo(codigo);
        }

        public List<PacienteEntidade> ListarPacientesInativos()
        {
            return _repositorioPaciente.BuscarInativos();
        }

        public List<PacienteEntidade> ListarPacienteporNascimento(DateTime nascimento)
        {
            if ((_repositorioPaciente.VerificarNascimento(nascimento)) == true)
            {
                return _repositorioPaciente.BuscarPorNascimento(nascimento);
            }
            else
            {
                throw new Exception("Nenhum Paciente com essa data de nascimento encontrado");
            }
        }
    }
}
