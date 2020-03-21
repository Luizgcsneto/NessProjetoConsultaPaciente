using ProjetoConsultaPaciente.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.ObjetoDeValor
{
   public class FormaPagamento
    {
        public int id { get; set; }

        public String nome { get; set; }

        public String descricao { get; set; }

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
