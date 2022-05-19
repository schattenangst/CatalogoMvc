
namespace CatalogoMvc.Interfaces.ILogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;

    public interface IGrupoLogic
    {
        /// <summary>
        /// Consulta los grupos y profesores asignados
        /// </summary>
        /// <returns></returns>
        Task<ICollection<GrupoEntity>> ObtieneGrupoProfesor();

        /// <summary>
        /// Obtiene registros de grupos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        Task<ICollection<GrupoEntity>> ObtieneGrupos();

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns>Coleccion de alumnos</returns>
        Task<GrupoEntity> ObtieneGrupo(int idGrupo);

        /// <summary>
        /// Actualiza información de grupo
        /// </summary>
        /// <param name="grupo">Objeto con datos de <see cref="GrupoEntity"/></param>
        /// <returns>True operación correcta</returns>
        Task<bool> ActualizaGrupo(GrupoEntity grupo);

        /// <summary>
        /// Registra un nuevo grupo
        /// </summary>
        /// <param name="grupo">Información de un grupo</param>
        /// <returns></returns>
        Task<bool> CrearGrupo(GrupoEntity grupo);
    }
}
