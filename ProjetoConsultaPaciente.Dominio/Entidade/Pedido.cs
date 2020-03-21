using ProjetoConsultaPaciente.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
   public class Pedido
    {
        public int id { get; set; }
        public DateTime dataPedido { get; set; }
        public int usuarioID { get; set; }
        public DateTime dataPrevisaoEntrega { get; set; }

        public String CEP { get; set; }
        public String estado { get; set; }
        public String cidade { get; set; }
        public String enderecoCompleto { get; set; }
        public int numeroEndereco { get; set; }
        public int formaPagamentoID { get; set; }
        public FormaPagamento formaPagamento { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }


    }
}
