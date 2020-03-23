using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Marcacao
    {
        public System.Guid Id { get; set; }
        public System.DateTime DataMarcacao { get; set; }
        public bool Disponivel { get; set; }
        public System.TimeSpan Horario { get; set; }

        public Guid? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        public Guid HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
