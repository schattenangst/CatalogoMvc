
namespace WebApplication1
{
    using Autofac;

    using CatalogoMvc.Interfaces.ILogic;
    using CatalogoMvc.Interfaces.IPersistence;
    using CatalogoMvc.Logic.Services;
    using CatalogoMvc.Persistence.Context;
    using CatalogoMvc.Persistence.Repositories;
    using WebApplication1.Controllers;

    public static class ContainerConfig
    {
        /// <summary>
        /// Inicializa el contenedor de dependencias
        /// </summary>
        /// <param name="connectionString">Cadena de conexión</param>
        /// <returns>Instancia para resolver dependencias</returns>
        public static ContainerBuilder Initialize(string connectionString)
        {
            // Register Web API Controllers
            var builder = new ContainerBuilder();

            // Controllers
            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<AlumnosController>().InstancePerRequest();
            builder.RegisterType<GruposController>().InstancePerRequest();

            // Lógica
            builder.RegisterType<AlumnoLogic>().As<IAlumnoLogic>();
            builder.RegisterType<GrupoLogic>().As<IGrupoLogic>();
            builder.RegisterType<ProfesorLogic>().As<IProfesorLogic>();

            // Repositorio
            builder = InitializeRepositoryDependencies(builder, connectionString);

            // Microservice
            builder.RegisterType<ApiServices>().As<IApiServices>();

            return builder;
        }

        /// <summary>
        /// Inicializa el contenedor de dependencias
        /// </summary>
        /// <param name="builder">Constructor de dependencias</param>
        /// <param name="connectionString">Cadena de conexión</param>
        /// <returns>Instancia para resolver dependencias</returns>
        public static ContainerBuilder InitializeRepositoryDependencies(ContainerBuilder builder, string connectionString)
        {
            // Repository
            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter(new TypedParameter(typeof(string), connectionString))
                .InstancePerRequest();

            builder.RegisterType<AlumnoRepository>().As<IAlumnoRepository>().InstancePerRequest();
            builder.RegisterType<GrupoRepository>().As<IGrupoRepository>().InstancePerRequest();
            builder.RegisterType<ProfesorRepository>().As<IProfesorRepository>().InstancePerRequest();

            return builder;
        }

    }
}
