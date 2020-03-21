using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Usuario
    {
        public int id { get; set; }
        public String email { get; set; }

        public String senha { get; set; }
        public String nome { get; set; }
        public String sobreNome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
