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
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
