namespace CatalogoMvc.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.IPersistence;
    using CatalogoMvc.Model;
    using CatalogoMvc.Persistence.Context;

    public class GrupoRepository : ContextPersistence<Grupo>, IGrupoRepository
    {
        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbContext"></param>
        public GrupoRepository(IApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Consulta los grupos y profesores asignados
        /// </summary>
        /// <returns></returns>
        public ICollection<GrupoEntity> ObtieneGrupoProfesor()
        {
            ICollection<GrupoEntity> entidadGrupos = null;

            try
            {
                ICollection<Grupo> grupos = this.FindAllAsync(x => x.Profesor);

                if (grupos != null)
                {
                    entidadGrupos = new List<GrupoEntity>();

                    foreach (Grupo grupo in grupos)
                    {
                        entidadGrupos.Add(new GrupoEntity
                        {
                            IdGrupo = grupo.IdGrupo,
                            Nombre = grupo.Nombre,
                            NumeroAlumnos = grupo.NumeroAlumnos,
                            NombreProfesor = grupo?.Profesor.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return entidadGrupos;
        }

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        public ICollection<GrupoEntity> ObtieneGrupos()
        {
            ICollection<GrupoEntity> entidadGrupos = null;

            try
            {
                ICollection<Grupo> grupos = this.FindAllAsync();

                if (grupos != null)
                {
                    entidadGrupos = new List<GrupoEntity>();

                    foreach (Grupo grupo in grupos)
                    {
                        entidadGrupos.Add(new GrupoEntity
                        {
                            IdGrupo = grupo.IdGrupo,
                            Nombre = grupo.Nombre,
                            NumeroAlumnos = grupo.NumeroAlumnos
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return entidadGrupos;
        }

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns>Coleccion de alumnos</returns>
        public GrupoEntity ObtieneGrupo(int idGrupo)
        {
            GrupoEntity entidadGrupo = null;

            try
            {
                Grupo grupo = this.FindFirstAsync(x => x.IdGrupo == idGrupo);

                if (grupo != null)
                {
                    entidadGrupo = new GrupoEntity
                    {
                        IdGrupo = grupo.IdGrupo,
                        Nombre = grupo.Nombre,
                        NumeroAlumnos = grupo.NumeroAlumnos
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return entidadGrupo;
        }

        /// <summary>
        /// Actualiza información de alumno
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public bool ActualizaGrupo(Grupo grupo)
        {
            bool estatus = false;

            try
            {
                Grupo actualizagrupo = this.FindAsync(x => x.IdGrupo == grupo.IdGrupo);

                if (actualizagrupo != null)
                {
                    actualizagrupo.IdGrupo = grupo.IdGrupo;
                    actualizagrupo.Nombre = grupo.Nombre;
                    actualizagrupo.NumeroAlumnos = grupo.NumeroAlumnos;

                    estatus = this.Update(actualizagrupo);
                }
            }
            catch (Exception ex)
            {
            }

            return estatus;
        }

        /// <summary>
        /// Registra un nuevo grupo
        /// </summary>
        /// <param name="grupo">Información de un grupo</param>
        /// <returns></returns>
        public bool CrearGrupo(Grupo grupo)
        {
            bool estatus = false;

            try
            {
                Grupo nuevoGrupo = this.Create(grupo);
                estatus = nuevoGrupo != null;
            }
            catch (Exception ex)
            {

                throw;
            }

            return estatus;
        }
        #endregion Methods
    }
}