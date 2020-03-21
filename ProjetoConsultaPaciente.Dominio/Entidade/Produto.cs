using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
    public class Produto
    {
        public int id { get; set; }

        public String nome { get; set; }

        public String descricao { get; set; }

        public Decimal preco { get; set; }     

    }
}
