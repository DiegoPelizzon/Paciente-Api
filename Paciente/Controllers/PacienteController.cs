using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paciente.Dominio.Dto;
using Paciente.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paciente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {

        protected readonly IPacienteAplicacao _pacienteAplicacao;

        public PacienteController(IPacienteAplicacao pacienteAplicacao)
        {
            _pacienteAplicacao = pacienteAplicacao;
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar(PacienteDto dto)
        {
            try
            {
                _pacienteAplicacao.AdicionarPaciente(dto);
                return Ok("Paciente Cadastrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao adicionar paciente: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public IActionResult Alterar(int id, string codigo, string nome, string sexo, DateTime datanascimento, string cpf, string cep)
        {
            try
            {
                _pacienteAplicacao.AtualizarPaciente(id, codigo, nome, sexo, datanascimento, cpf, cep);
                return Ok("Paciente alterado com sucesso");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao alterar paciente: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Pacientes")]
        public IActionResult ListarTodos()
        {
            try
            {
                var listatodos = _pacienteAplicacao.ListarPaciente();
                return Ok(listatodos);

            }catch(Exception ex)
            {
                return StatusCode(500, "Erro ao listar pacientes" +ex.Message);
            }
        }

        [HttpGet]
        [Route("buscarporcodigo/{codigo}")]
        public IActionResult FiltrarporCodigo(string codigo)
        {
            try
            {
                return Ok(_pacienteAplicacao.ListarPacienteporCodigo(codigo));

            }catch(Exception ex)
            {
                return StatusCode(500, "Erro ao buscar por Codigo: "+ex.Message);
            }
        }

        [HttpGet]
        [Route("buscarpornascimento/{nascimento}")]
        public IActionResult ListarNascimento(DateTime nascimento)
        {
            try
            {
                var listanascimento=_pacienteAplicacao.ListarPacienteporNascimento(nascimento);
                return Ok(listanascimento);

            }catch(Exception ex)
            {
                return StatusCode(500, "Erro ao buscar por nascimento: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("buscarinativos")]
        public IActionResult BuscarInativos()
        {
            try
            {
                var inativos = _pacienteAplicacao.ListarPacientesInativos();
                return Ok(inativos);

            }catch(Exception ex)
            {
                return StatusCode(500, "Erro ao buscar pacientes inativos: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _pacienteAplicacao.DeletarPaciente(id);
                return Ok("Paciente Excluido");

            }catch (Exception ex)
            {
                return StatusCode(500, "Erro ao excluir paciente: " + ex.Message);
            }
        }

    }
}
