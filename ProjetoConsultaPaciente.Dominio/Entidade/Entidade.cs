using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public abstract class Entidade
    {
        public List<String> _mensagemValidacao { get; set; }

        private List<String> mensagemValidacao
        {
            get { return _mensagemValidacao ?? (_mensagemValidacao = new List<String>()); }
        }

        protected void LimparMensagemValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(String mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public abstract void Validate();

        protected bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
        }

       
    } 
}
