using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoConsultaPaciente.Dominio.Contratos;
using ProjetoConsultaPaciente.Dominio.Entidade;
using ProjetoConsultaPaciente.Repositorio.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoConsulta.Web.Controllers
{
    [Route("api/[controller]")]
    public class HospitalController : Controller
    {

        private HospitalRepositorio hospitalRepositorio;

        public HospitalController()
        {
            hospitalRepositorio = new HospitalRepositorio();
        }


        // GET: api/<controller>
        [HttpGet("ListarHospitais")]
        public ActionResult ListarHospitais()
        {
            try
            {

                var listaHospitais = hospitalRepositorio.Listar();


                return Ok(listaHospitais);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("ListarMarcacoesHospital{id}")]
        public ActionResult ListarMarcacoesHospital(string id)
        {
            try
            {
                return Ok(hospitalRepositorio.Buscar(new Guid(id)));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
