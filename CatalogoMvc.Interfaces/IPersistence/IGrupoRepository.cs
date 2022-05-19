
namespace CatalogoMvc.Interfaces.IPersistence
{
    using System.Collections.Generic;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Model;

    /// <summary>
    /// Repositorio para entidad Grupo
    /// </summary>
    public interface IGrupoRepository
    {
        /// <summary>
        /// Consulta los grupos y profesores asignados
        /// </summary>
        /// <returns></returns>
        ICollection<GrupoEntity> ObtieneGrupoProfesor();

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        ICollection<GrupoEntity> ObtieneGrupos();

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns>Coleccion de alumnos</returns>
        GrupoEntity ObtieneGrupo(int idGrupo);

        /// <summary>
        /// Actualiza información de alumno
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        bool ActualizaGrupo(Grupo grupo);

        /// <summary>
        /// Registra un nuevo grupo
        /// </summary>
        /// <param name="grupo">Información de un grupo</param>
        /// <returns></returns>
        bool CrearGrupo(Grupo grupo);
    }
}
