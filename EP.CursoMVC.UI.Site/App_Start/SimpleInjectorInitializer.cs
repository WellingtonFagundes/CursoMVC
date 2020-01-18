[assembly: WebActivator.PostApplicationStartMethod(typeof(EP.CursoMVC.UI.Site.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace EP.CursoMVC.UI.Site.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using EP.CursoMVC.Infra.CrossCutting.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            //WebRequestLifeStyle compatível com MVC
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            //O SimpleInjector exige que todas as coisas referente a instância ele verifica
            container.Verify();
            
            //DependencyResolver classe do MVC
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //Acesso a camada de Infra de Cross Cutting IOC passando a referência do site
            SimpleInjectorInitializerBootstrapper.Register(container);
        }
    }
}