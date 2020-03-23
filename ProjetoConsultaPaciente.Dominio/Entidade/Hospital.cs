using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Hospital
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }

        public virtual ICollection<Marcacao> Marcacoes { get; set; }
    }
}
