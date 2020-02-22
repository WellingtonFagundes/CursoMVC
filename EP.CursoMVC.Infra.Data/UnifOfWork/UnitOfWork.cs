using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Infra.Data.UnifOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CursoMVCContext _context;
        
        public UnitOfWork(CursoMVCContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
