using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Paciente : Entidade
    {
        public System.Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public bool EhAdministrador { get; set; }
        public string Contato { get; set; }
        

        public virtual ICollection<Marcacao> Marcacoes { get; set; }



        public override void Validate()
        {
            LimparMensagemValidacao();

            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarCritica("Por favor informar o Nome do paciente");
            }

            if (string.IsNullOrEmpty(SobreNome))
            {
                AdicionarCritica("Por favor informar o Sobrenome do paciente");
            }

            if (string.IsNullOrEmpty(Email))
            {
                AdicionarCritica("Por favor informar o e-mail.");
            }

            if (string.IsNullOrEmpty(Password))
            {
                AdicionarCritica("Por favor informar a senha do paciente");
            }
        }
    }
}
