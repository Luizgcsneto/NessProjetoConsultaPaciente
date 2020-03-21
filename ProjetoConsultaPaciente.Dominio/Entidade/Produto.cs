using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Produto : Entidade
    {
        private int id { get; set; }

        private String nome { get; set; }

        private String descricao { get; set; }

        private Decimal preco { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
        }
    }
}
