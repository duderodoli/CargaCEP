using CargaCEP.Aplicacao.Processo;
using CargaCEP.Dominio.Nucleo;
using CargaCEP.Dominio.Processo;
using CargaCEP.Dominio.Repositorio;
using CargaCEP.Repositorio;
using CargaCEP.Repositorio.Base;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;

namespace CargaCEP.IoC
{
    public static class IoCIniciar
    {    

        private static Container container = new Container();

        public static T ObterInstancia<T>()
        {
            return (T)container.GetInstance(typeof(T));
        }

        public static void Iniciar()
        {
            IniciarContainer(container);
        }

        public static void Iniciar(HttpConfiguration global)
        {
            Iniciar(global, IniciarContainer);
        }

        public static void Iniciar(HttpConfiguration global, Action<Container> DelegateIniciarContainer)
        {
            container = new Container();
            DelegateIniciarContainer(container);
            global.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        public static void IniciarContainer(Container container)
        {
            container.Register<IConexaoBase, ConexaoBase>();
            //container.Register<IConexaoSiacLegadoBase, ConexaoBase>();
            //container.Register<IConexaoSiacCorporativoBase, ConexaoBase>();
            //container.Register<IConexaoSupermixIdentityBase, ConexaoBase>();

            RegistrarContainersRepositorio(container);
            RegistrarContainersProcesso(container);
        }

        private static void RegistrarContainersProcesso(Container container)
        {
            container.Register<ICargaCepProcesso, CargaCepProcesso>();
        }

        private static void RegistrarContainersRepositorio(Container container)
        {
            container.Register<IBairroRepositorio, BairroRepositorio>();
            container.Register<ILocalidadeRepositorio, LocalidadeRepositorio>();
            container.Register<ILogradouroRepositorio, LogradouroRepositorio>();

        }
    }
}
