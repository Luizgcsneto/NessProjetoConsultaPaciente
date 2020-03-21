using ProjetoConsultaPaciente.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
   public class Pedido : Entidade
    {
        private int id { get; set; }
        private DateTime dataPedido { get; set; }
        private int usuarioID { get; set; }
        private DateTime dataPrevisaoEntrega { get; set; }
        private String CEP { get; set; }
        private String estado { get; set; }
        private String cidade { get; set; }
        private String enderecoCompleto { get; set; }
        private int numeroEndereco { get; set; }
        private int formaPagamentoID { get; set; }
        private FormaPagamento formaPagamento { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (!ItensPedido.Any())
            {
                AdicionarCritica("Erro - Pedido não pode sem item de pedido!");
            }
               
            if (string.IsNullOrEmpty(CEP))
            {
                AdicionarCritica("Crítica - CEP não pode ser vazio");
            }

            if(formaPagamentoID == 0)
            {
                AdicionarCritica("Crítica não foi informado a forma de pagamento");
            }

        }
    }
}
