namespace CatalogoMvc.Interfaces.IPersistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;

    /// <summary>
    /// 
    /// </summary>
    public interface IProfesorRepository
    {

        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <param name="edit"></param>
        /// <returns>Coleccion de alumnos</returns>
        ICollection<ProfesorEntity> ObtieneProfesores(bool edit);
    }
}
