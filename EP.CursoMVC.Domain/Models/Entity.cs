using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Models
{
    //Super classe mãe
    //Só serve para ser herdada não instanciada
    public abstract class Entity
    {
        //Só pode ser acessado por quem herda dela
        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public void AdicionarErroValidacao(string erro,string mensagem)
        {
            ValidationResult.Add(new ValidationError(mensagem));
        }

        public void AdicionarErrosValidacao(ValidationResult validationResult)
        {
            ValidationResult.Add(validationResult);
        }

        public void ZerarListaErros()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool EhValido();
    }
}
