using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
   public class ItemPedido : Entidade
    {
        private int id { get; set; }
        private int produtoID { get; set; }
        private int quantidade { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if(produtoID == 0)
            {
                AdicionarCritica("Não foi informado a referência do produto");
            }

            if(quantidade == 0)
            {
                AdicionarCritica("Não foi informado a quantidade");
            }
        }
    }
}
