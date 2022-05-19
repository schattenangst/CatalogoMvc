
namespace CatalogoMvc.Interfaces.IPersistence
{
    using System.Collections.Generic;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Model;

    /// <summary>
    /// Interface para realizar operaciones en la capa de datos
    /// </summary>
    public interface IAlumnoRepository
    {
        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        ICollection<AlumnoEntity> ObtieneAlumnos();

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns>Coleccion de alumnos</returns>
        AlumnoEntity ObtieneAlumno(int idAlumno);

        /// <summary>
        /// Realiza el registro de un nuevo alumno
        /// </summary>
        /// <param name="alumno">Objeto con datos de <see cref="Alumno"/></param>
        /// <returns>True operación correcta</returns>
        bool GuardaAlumno(Alumno alumno);

        /// <summary>
        /// Actualiza información de un alumno
        /// </summary>
        /// <param name="alumno">Objeto con datos de <see cref="Alumno"/></param>
        /// <returns>True operación correcta</returns>
        bool ActualizaAlumno(Alumno alumno);

        /// <summary>
        /// Elimina información de un alumno
        /// </summary>
        /// <param name="idAlumno">Identificador de alumno</param>
        /// <returns>True operación correcta</returns>
        bool EliminaAlumno(int idAlumno);
    }
}
