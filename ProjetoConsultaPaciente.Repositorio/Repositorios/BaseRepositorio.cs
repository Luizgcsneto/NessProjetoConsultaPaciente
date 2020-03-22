//using ProjetoConsultaPaciente.Dominio.Contratos;
using ProjetoConsultaPaciente.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoConsultaPaciente.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        public BaseRepositorio()
        {

        }

        public void Adicionar(TEntity entity)
        {
            
        }

        public void Atualizar(TEntity entity)
        {
           
        }

        /* public TEntity ObterPorID(int id)
         {

         }

         public IEnumerable<TEntity> ObterTodos()
         {

         }
         */
        public void Remover(TEntity entity)
        {
            
        }

        public void Dispose()
        {

        }

        public TEntity ObterPorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
