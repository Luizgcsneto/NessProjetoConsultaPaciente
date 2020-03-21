using ProjetoConsultaPaciente.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.ObjetoDeValor
{
   public class FormaPagamento
    {
        private int id { get; set; }

        private String nome { get; set; }

        private String descricao { get; set; }

        public bool ehBoleto
        {
            get { return id == (int)TipoFormaPagamentoEnum.Boleto; }
        }

        public bool ehCartao
        {
            get { return id == (int)TipoFormaPagamentoEnum.CartaoCredito; }
        }

        public bool ehDeposito
        {
            get { return id == (int)TipoFormaPagamentoEnum.Deposito; }
        }

        public bool NaoDefinido
        {
            get { return id == (int)TipoFormaPagamentoEnum.NaoDefinido; }
        }
    }
}
