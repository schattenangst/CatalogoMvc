
namespace CatalogoMvc.Interfaces.ILogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;

    public interface IAlumnoLogic
    {
        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        Task<ICollection<AlumnoEntity>> ObtieneAlumnos();

        /// <summary>
        /// Obtiene el registro de un alumno
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns>Coleccion de alumnos</returns>
        Task<AlumnoEntity> ObtieneAlumno(int idAlumno);

        /// <summary>
        /// Realiza el registro de un nuevo alumno
        /// </summary>
        /// <param name="alumno">Objeto con datos de <see cref="AlumnoEntity"/></param>
        /// <returns>True operación correcta</returns>
        Task<bool> GuardaAlumno(AlumnoEntity alumno);

        /// <summary>
        /// Actualiza información de un alumno
        /// </summary>
        /// <param name="alumno">Objeto con datos de <see cref="AlumnoEntity"/></param>
        /// <returns>True operación correcta</returns>
        Task<bool> ActualizaAlumno(AlumnoEntity alumno);

        /// <summary>
        /// Elimina información de un alumno
        /// </summary>
        /// <param name="idAlumno">Identificador de alumno</param>
        /// <returns>True operación correcta</returns>
        Task<bool> EliminaAlumno(int idAlumno);
    }
}
