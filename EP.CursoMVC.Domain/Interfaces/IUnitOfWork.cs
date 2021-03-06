﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
        void Rollback();
        bool SaveChanges();
    }
}
