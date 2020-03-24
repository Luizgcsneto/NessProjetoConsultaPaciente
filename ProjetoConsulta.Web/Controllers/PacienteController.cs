using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoConsultaPaciente.Dominio.Contratos;
using ProjetoConsultaPaciente.Dominio.Entidade;
using ProjetoConsultaPaciente.Repositorio;
using ProjetoConsultaPaciente.Repositorio.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoConsulta.Web.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        PacienteRepositorio repositorioPaciente;

        public PacienteController()
        {
            repositorioPaciente = new PacienteRepositorio();
        }


        // GET: api/<controller>
        [HttpGet("ListarPacientes")]
        public IActionResult ListarPacientes()
        {
            var ls = new List<Paciente>();

            ls.Add(new Paciente()
            {
                Id = Guid.NewGuid(),
                Nome = "Luiz",
                Password = "12345",
                SobreNome = "Gonzaga",
                Email = "luiz@gmail.com",
                EhAdministrador = false,
                Contato = "34391128"
            });

            return Ok(ls);
        }

        // GET api/<controller>/5
        [HttpGet("BuscarPaciente{id}")]
        public IActionResult BuscarPaciente(String id)
        {
            try
            {
                return Ok(repositorioPaciente.Buscar(new Guid(id)));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [HttpPost("VerificarPaciente")]
        public IActionResult VerificarPaciente([FromBody]Paciente paciente)
        {
            try
            {

                Paciente pacienteBuscar = repositorioPaciente.VerificarPaciente(paciente);

                if (pacienteBuscar == null)
                    return NotFound("Paciente e/ou senha inválidos");
                else
                    return Ok(pacienteBuscar);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("ListarMarcacoesPaciente{id}")]
        public ActionResult ListarMarcacoesPaciente(Guid Id)
        {
            try
            {
                var marcacoes = new List<Marcacao>();

                marcacoes.Add(new Marcacao()
                {
                    DataMarcacao = DateTime.Now,
                    Disponivel = true,
                    Horario = DateTime.Now.TimeOfDay,
                    HospitalId = Id,
                    PacienteId = Guid.NewGuid(),
                    Id = Guid.NewGuid()

                });

                return Ok(new Paciente()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Luiz",
                    Password = "12345",
                    SobreNome = "Gonzaga",
                    Email = "luiz@gmail.com",
                    EhAdministrador = false,
                    Contato = "34391128",
                    Marcacoes = marcacoes
                });
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost("RealizarAgendamento")]
        public IActionResult RealizarAgendamento([FromBody]Marcacao marcacao)
        {
            try
            {
                Paciente p = new Paciente();
                p.Id = (Guid)marcacao.PacienteId;

                repositorioPaciente.RealizarMarcacao(p, marcacao);
                return Ok(marcacao);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("DesfazerAgendamento")]
        public IActionResult DesfazerAgendamento([FromBody] Marcacao marcacao)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
