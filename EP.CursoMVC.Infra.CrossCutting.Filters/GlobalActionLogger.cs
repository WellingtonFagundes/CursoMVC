using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EP.CursoMVC.Infra.CrossCutting.Filters
{
    public class GlobalActionLogger: ActionFilterAttribute
    {
        //LOG de Auditoria
        //Para capturar erro de qualquer projeto Web MVC não precisando
        //criar em cada projeto um filter específico
        //Funciona com try catch
        /*
         * Usar:
         * try 
         * {
         * 
         * }catch (Exception e)
         * {
         * 
         * 
         * }
         * Somente se for algo específico senão esse filter já serve esta parte
       */
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                // Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                // -> Gravar log do erro no BD
                // -> Email para o admim
                // -> Retornar o cod de erro amigável

                // SEMPRE USE ASYNC AQUI DENTRO -> (para não travar a thread e continuar a execução)
                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
