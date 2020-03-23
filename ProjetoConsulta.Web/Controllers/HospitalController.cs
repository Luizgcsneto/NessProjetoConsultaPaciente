using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoConsultaPaciente.Dominio.Entidade;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoConsulta.Web.Controllers
{
    [Route("api/[controller]")]
    public class HospitalController : Controller
    {
        // GET: api/<controller>
        [HttpGet("ListarHospitais")]
        public ActionResult ListarHospitais()
        {
            try
            {

                var listaHospitais = new List<Hospital>();

                listaHospitais.Add(new Hospital()
                {
                    Id = Guid.NewGuid(),
                    Contato = "813291124",
                    Email = "hospital@gmail.com",
                    Endereco = "Avenida Mascarenhas",
                    Nome = "HR"
                });


                return Ok(listaHospitais);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("ListarMarcacoesHospital{id}")]
        public ActionResult ListarMarcacoesHospital(Guid Id)
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

                return Ok(new Hospital()
                {
                    Id = Guid.NewGuid(),
                    Contato = "813291124",
                    Email = "hospital@gmail.com",
                    Endereco = "Avenida Mascarenhas",
                    Nome = "HR",
                    Marcacoes = marcacoes
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
