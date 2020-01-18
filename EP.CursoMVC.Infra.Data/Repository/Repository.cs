using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Models;
using EP.CursoMVC.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Infra.Data.Repository
{
    //Repositório Genérico
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected CursoMVCContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new CursoMVCContext();
            DbSet = Db.Set<TEntity>();
        }   
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            SaveChanges();
        }

        public virtual void Remover(Guid id)
        {
            //Pra não acessar duas vezes o banco
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);

            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int size, int reg) 
        {
            //de 10 em 10
            //reg = 0, tam = 10
            //reg = 10, tam = 20
            //reg = 20, tam = 30
            return DbSet.Take(reg).Skip(size);
        }

        public void Dispose()
        {
            Db.Dispose();
        }


    }
}
