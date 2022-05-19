
namespace CatalogoMvc.Interfaces.IPersistence
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Obtiene objeto DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entidad generica</typeparam>
        /// <returns>Objeto DbSet</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns>Result save</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
