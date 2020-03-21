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

            if (string.IsNullOrEmpty(nome))
            {
                AdicionarCritica("Informar o nome do produto");
            }

            if (string.IsNullOrEmpty(descricao))
            {
                AdicionarCritica("Informar a descrição do produto");
            }

            if (preco == 0)
            {
                AdicionarCritica("Informar o preço do produto");
            }
        }
    }
}
