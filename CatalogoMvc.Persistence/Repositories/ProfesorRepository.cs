
namespace CatalogoMvc.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.IPersistence;
    using CatalogoMvc.Model;
    using CatalogoMvc.Persistence.Context;

    /// <summary>
    /// 
    /// </summary>
    public class ProfesorRepository : ContextPersistence<Profesor>, IProfesorRepository
    {
        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbContext"></param>
        public ProfesorRepository(IApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public ICollection<ProfesorEntity> ObtieneProfesores(bool edit)
        {
            ICollection<ProfesorEntity> profesoresEntity = null;

            try
            {
                ICollection<Profesor> profesores = null;

                if (edit)
                {
                    profesores = this.FindAllAsync();
                }
                else
                {
                    profesores = this.FindAllAsync(x => x.Grupos)
                                                                .Where(y => y.Grupos.Count == 0).ToList();
                }

                if (profesores != null)
                {
                    profesoresEntity = new List<ProfesorEntity>();

                    foreach (Profesor profesor in profesores)
                    {
                        profesoresEntity.Add(new ProfesorEntity
                        {
                            IdProfesor = profesor.IdProfesor,
                            Nombre = profesor.Nombre
                        });
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return profesoresEntity;
        }

        #endregion

    }
}
