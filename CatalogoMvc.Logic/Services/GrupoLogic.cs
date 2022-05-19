namespace CatalogoMvc.Logic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.ILogic;
    using CatalogoMvc.Interfaces.IPersistence;
    using CatalogoMvc.Model;
    using System.Linq;

    public class GrupoLogic : IGrupoLogic
    {
        #region Fields

        /// <summary>
        /// ruta para el endpoint
        /// </summary>
        private string endpointService = "http://localhost:8000/";

        /// <summary>
        /// Dependencia de clase
        /// </summary>
        private readonly IGrupoRepository grupoRepository;

        /// <summary>
        /// Dependencia de clase
        /// </summary>
        private readonly IApiServices apiServices;

        #endregion Fields

        #region Contructor

        /// <summary>
        /// Constructor de clas
        /// </summary>
        /// <param name="grupoRepository"></param>
        public GrupoLogic(IGrupoRepository grupoRepository, IApiServices apiServices)
        {
            this.grupoRepository = grupoRepository;
            this.apiServices = apiServices;
        }

        #endregion Contructor

        #region Methods

        /// <summary>
        /// Consulta los grupos y profesores asignados
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<GrupoEntity>> ObtieneGrupoProfesor()
        {
            ICollection<GrupoEntity> grupos = null;

            try
            {
                grupos = this.grupoRepository.ObtieneGrupoProfesor();
            }
            catch (Exception)
            {
                throw;
            }

            return grupos;
        }

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        public async Task<ICollection<GrupoEntity>> ObtieneGrupos()
        {
            ICollection<GrupoEntity> grupos = null;

            try
            {
                ResponseMessage<IEnumerable<GroupEntity>> responseGroups = null;
                responseGroups = await this.apiServices.GetRequest<IEnumerable<GroupEntity>>(new Uri($"{this.endpointService}groups"));

                if (responseGroups.Response != null && responseGroups.Response.Count() > 0)
                {
                    grupos = new List<GrupoEntity>();
                    foreach (GroupEntity item in responseGroups.Response)
                    {
                        grupos.Add(new GrupoEntity
                        {
                            IdGrupo = item.Id,
                            Nombre = item.Name,
                            NumeroAlumnos = item.TotalStudents
                        });
                    }
                }
            }
            catch (Exception)
            {
               
            }

            return grupos;
        }

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns>Coleccion de alumnos</returns>
        public async Task<GrupoEntity> ObtieneGrupo(int idGrupo)
        {
            GrupoEntity grupo = null;

            try
            {
                ResponseMessage<GroupEntity> responseGroup = null;
                responseGroup = await this.apiServices.GetRequest<GroupEntity>(new Uri($"{this.endpointService}/{idGrupo}"));

                if (responseGroup.Response != null)
                {

                }

            }
            catch (Exception)
            {
                throw;
            }

            return grupo;
        }


        /// <summary>
        /// Actualiza información de un grupo
        /// </summary>
        /// <param name="grupo">Objeto con datos de <see cref="GrupoEntity"/></param>
        /// <returns>True operación correcta</returns>
        public async Task<bool> ActualizaGrupo(GrupoEntity grupo)
        {
            bool estatus = false;

            try
            {
                if (grupo != null)
                {
                    Grupo nuevoAlumno = new Grupo
                    {
                        IdGrupo = grupo.IdGrupo,
                        Nombre = grupo.Nombre,
                        NumeroAlumnos = grupo.NumeroAlumnos
                    };

                    estatus = this.grupoRepository.ActualizaGrupo(nuevoAlumno);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return estatus;
        }

        /// <summary>
        /// Registra un nuevo grupo
        /// </summary>
        /// <param name="grupo">Información de un grupo</param>
        /// <returns></returns>
        public async Task<bool> CrearGrupo(GrupoEntity grupo)
        {
            bool estatus = false;

            try
            {
                if (grupo != null)
                {
                    Grupo nuevoGrupo = new Grupo
                    {
                        Nombre = grupo.Nombre,
                        IdProfesor = grupo.IdProfesor,
                        NumeroAlumnos = grupo.NumeroAlumnos
                    };

                    estatus = this.grupoRepository.CrearGrupo(nuevoGrupo);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return estatus;
        }
        #endregion Methods
    }
}