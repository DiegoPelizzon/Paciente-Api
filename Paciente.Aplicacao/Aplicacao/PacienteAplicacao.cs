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
            if (dto.datanascimentoPaciente <= DateTime.Now)
            {

                if ((_repositorioPaciente.VerificacaoCpf(dto.cpfPaciente)) == false)
                {

                    var entidade = new PacienteEntidade();

                    entidade.codigo = dto.codigoPaciente;
                    entidade.nome = dto.nomePaciente;
                    entidade.sexo = dto.sexoPaciente;
                    entidade.datanascimento = dto.datanascimentoPaciente;
                    entidade.cpf = dto.cpfPaciente;
                    entidade.cep = dto.cepPaciente;
                    entidade.situacao = dto.situacaoPaciente;

                    _repositorioPaciente.Criar(entidade);
                    _repositorioPaciente.SalvarOk();

                }
                else if ((_repositorioPaciente.VerificacaoCpf(dto.cpfPaciente)) == true)
                {
                    throw new Exception("Já existe um paciente com esse CPF cadastrado");
                }
            }
            else if (dto.datanascimentoPaciente > DateTime.Now)
            {
                throw new Exception("data de nascimento não pode ser superior a data atual");
            }

        }

        public void AtualizarPaciente(int id, string codigo, string nome, string sexo, DateTime datanascimento, string cpf, string cep)
        {
            if (datanascimento <= DateTime.Now)
            {

                if ((_repositorioPaciente.VerificacaoCpf(cpf)) == false)
                {
                    PacienteEntidade entidade = _repositorioPaciente.BuscarporId(id);
                    entidade.codigo = codigo;
                    entidade.nome = nome;
                    entidade.sexo = sexo;
                    entidade.datanascimento = datanascimento;
                    entidade.cpf = cpf;
                    entidade.cep = cep;

                    _repositorioPaciente.Atualizar(entidade);
                    _repositorioPaciente.SalvarOk();
                }
                else if ((_repositorioPaciente.VerificacaoCpf(cpf)) == true)
                {
                    throw new Exception("Já existe um paciente com esse CPF cadastrado");
                }
            }
            else if (datanascimento > DateTime.Now)
            {
                throw new Exception("data de nascimento não pode ser superior a data atual");
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
                throw new Exception("Desculpa mas esse Id não existe");
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
            if ((_repositorioPaciente.verificarnascimento(nascimento))==true) {
                return _repositorioPaciente.BuscarPorNascimento(nascimento);
            }
            else
            {
                throw new Exception("Nenhum Paciente com essa data de nascimento encontrado");
            }
        }
    }
}
