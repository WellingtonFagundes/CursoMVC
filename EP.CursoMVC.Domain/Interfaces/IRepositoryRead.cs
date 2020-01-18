using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Interfaces
{
    public interface IRepositoryRead<TEntity>:IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodosPaginado(int size, int reg);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }

   
}
