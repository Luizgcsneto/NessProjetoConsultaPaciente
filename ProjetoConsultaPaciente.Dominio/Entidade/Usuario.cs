using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Usuario : Entidade
    {
        private int id { get; set; }
        private String email { get; set; }
        private String senha { get; set; }
        private String nome { get; set; }
        private String sobreNome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

        }
    }
}
