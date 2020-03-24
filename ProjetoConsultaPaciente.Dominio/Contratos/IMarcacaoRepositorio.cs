using ProjetoConsultaPaciente.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Contratos
{
    public interface IMarcacaoRepositorio : IBaseRepositorio<Marcacao>
    {
        ICollection<Marcacao> ListarPorHospital(Guid hospitalId);
        ICollection<Marcacao> ListarPorPaciente(Guid pacienteId);

    }
}
