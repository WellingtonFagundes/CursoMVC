
using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.Services;
using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Services;
using EP.CursoMVC.Infra.Data.Context;
using EP.CursoMVC.Infra.Data.Repository;
using EP.CursoMVC.Infra.Data.UnifOfWork;
using SimpleInjector;

namespace EP.CursoMVC.Infra.CrossCutting.IoC
{
    public class SimpleInjectorInitializerBootstrapper
    {
        //IOC (Inversão de controle): Mesma coisa que injeção de dependência
        //Instalar o mecanismo apenas do SimpleInjector nesse projeto
        //Install-Package SimpleInjector

        public static void Register(Container container)
        {
            //O SimpleInjector que irá fazer as Instâncias na aplicação
            //======================================================
            //Lifestyle.Transient => Uma instância para cada solicitação
            //LifeStyle.Singleton => Uma instância única para a classe (para o servidor) (ex. envio de email)
            //LifeStyle.Scoped => Uma única instância para o request (o ideal para aplicação web ,finalidades evitar o stackoverflow 
            //(estouro de pilha)
            //======================================================

            //Referenciar as camadas
            //======================================================
            //APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            //Infra
            container.Register<IClienteRepository,ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork,UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMVCContext>(Lifestyle.Scoped);

            //======================================================
        }
    }
}
