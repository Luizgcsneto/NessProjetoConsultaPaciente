using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Dominio.Entidade
{
   public class ItemPedido
    {
        public int id { get; set; }
        public int produtoID { get; set; }
        public int quantidade { get; set; }
    }
}
