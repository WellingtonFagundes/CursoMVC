using DomainValidation.Validation;
using EP.CursoMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Application.Services
{
    public abstract class AppServiceBase
    {
        private readonly IUnitOfWork _uow;

        public AppServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void AdicionarErrosValidacao(ValidationResult validationResult,string erro)
        {
            validationResult.Add(new ValidationError(erro));
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Rollback()
        {
            _uow.Rollback();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        protected bool SaveChanges()
        {
            return _uow.SaveChanges();
        }
    }
}
