
namespace CatalogoMvc.Interfaces.ILogic
{
    using System.Collections.Generic;
    using CatalogoMvc.Entities;

    /// <summary>
    /// Interface para informacion de profesores
    /// </summary>
    public interface IProfesorLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICollection<ProfesorEntity> ObtieneProfesores(bool edit);
    }
}
