namespace CatalogoMvc.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.IPersistence;
    using CatalogoMvc.Model;
    using CatalogoMvc.Persistence.Context;

    public class AlumnoRepository : ContextPersistence<Alumno>, IAlumnoRepository
    {
        #region Contructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbContext"></param>
        public AlumnoRepository(IApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        #endregion Contructor

        #region Methods

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        public ICollection<AlumnoEntity> ObtieneAlumnos()
        {
            ICollection<AlumnoEntity> entidadAlumnos = null;

            try
            {
                ICollection<Alumno> alumnos = this.FindAllAsync(x => x.Grupo.Profesor);

                if (alumnos != null)
                {
                    entidadAlumnos = new List<AlumnoEntity>();

                    foreach (Alumno alumno in alumnos)
                    {
                        entidadAlumnos.Add(new AlumnoEntity
                        {
                            IdAlumno = alumno.IdAlumno,
                            IdGrupo = alumno.IdGrupo,
                            Nombre = alumno.Nombre,
                            FechaNacimiento = alumno.FechaNacimiento,
                            Edad = alumno.Edad,
                            PadreTutor = alumno.PadreTutor,
                            NombreGrupo = alumno.Grupo?.Nombre,
                            NombreProfesor = alumno.Grupo?.Profesor.Nombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return entidadAlumnos;
        }

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns>Coleccion de alumnos</returns>
        public AlumnoEntity ObtieneAlumno(int idAlumno)
        {
            AlumnoEntity entidadAlumno = null;

            try
            {
                Alumno alumno = this.FindFirstAsync(x => x.IdAlumno == idAlumno);

                if (alumno != null)
                {
                    entidadAlumno = new AlumnoEntity
                    {
                        IdAlumno = alumno.IdAlumno,
                        IdGrupo = alumno.IdGrupo,
                        Nombre = alumno.Nombre,
                        FechaNacimiento = alumno.FechaNacimiento,
                        Edad = alumno.Edad,
                        PadreTutor = alumno.PadreTutor
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return entidadAlumno;
        }


        /// <summary>
        /// Actualiza información de alumno
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public bool ActualizaAlumno(Alumno alumno)
        {
            bool estatus = false;

            try
            {
                Alumno actualizaAlumno = this.FindAsync(x => x.IdAlumno == alumno.IdAlumno);

                if (actualizaAlumno != null)
                {
                    actualizaAlumno.IdGrupo = alumno.IdGrupo;
                    actualizaAlumno.Nombre = alumno.Nombre;
                    actualizaAlumno.PadreTutor = alumno.PadreTutor;
                    actualizaAlumno.FechaNacimiento = alumno.FechaNacimiento;
                    actualizaAlumno.Edad = alumno.Edad;

                    estatus = this.Update(actualizaAlumno);
                }
            }
            catch (Exception ex)
            {

            }

            return estatus;
        }

        /// <summary>
        /// Elimina el registro de un alumno
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public bool EliminaAlumno(int idAlumno)
        {
            bool estatus = false;

            try
            {
                Alumno removeAlumno = this.FindAsync(x => x.IdAlumno == idAlumno);

                if (removeAlumno != null)
                {
                    estatus = this.Remove(removeAlumno) > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return estatus;
        }

        /// <summary>
        /// Guarda un nuevo registro de alumno
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public bool GuardaAlumno(Alumno alumno)
        {
            bool estatus = false;

            try
            {
                Alumno result = this.Create(alumno);
                if (result != null && result.IdAlumno != 0)
                {
                    estatus = true;
                }
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