
namespace CatalogoMvc.Logic.Services
{
    using System.Collections.Generic;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.ILogic;
    using CatalogoMvc.Interfaces.IPersistence;

    public class ProfesorLogic : IProfesorLogic
    {
        private readonly IProfesorRepository profesorRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesorRepository"></param>
        public ProfesorLogic(IProfesorRepository profesorRepository)
        {
            this.profesorRepository = profesorRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public ICollection<ProfesorEntity> ObtieneProfesores(bool edit)
        {
            ICollection<ProfesorEntity> profesores = null;

            profesores = this.profesorRepository.ObtieneProfesores(edit);

            return profesores;
        }
    }
}
