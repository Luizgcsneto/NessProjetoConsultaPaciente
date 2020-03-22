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

       

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (string.IsNullOrEmpty(nome))
            {
                AdicionarCritica("Por favor informar o Nome do usuário");
            }

            if (string.IsNullOrEmpty(sobreNome))
            {
                AdicionarCritica("Por favor informar o Sobrenome do usuário");
            }

            if (string.IsNullOrEmpty(email))
            {
                AdicionarCritica("Por favor informar o e-mail.");
            }

            if (string.IsNullOrEmpty(senha))
            {
                AdicionarCritica("Por favor informar a senha do usuário");
            }
        }
    }
}
