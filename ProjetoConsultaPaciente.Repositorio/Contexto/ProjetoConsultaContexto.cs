using Microsoft.EntityFrameworkCore;
using ProjetoConsultaPaciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Repositorio.Contexto
{
    public class ProjetoConsultaContexto : DbContext
    {
        public DbSet<Paciente> pacientes { get; set; }
       

    }
}
