
namespace CatalogoMvc.Persistence.Context
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using CatalogoMvc.Interfaces.IPersistence;

    public class ContextPersistence<T> : IContextPersistence<T> where T : class
    {
        #region Fields
        /// <summary>
        /// Contexto de Repositorio
        /// </summary>
        protected readonly IApplicationDbContext ApplicationDbContext;

        /// <summary>
        /// Objeto Queryable
        /// </summary>
        private IQueryable<T> query;


        /// <summary>
        /// Variable DbContext
        /// </summary>
        private readonly DbContext context;

        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GenericRepository{T}"/>
        /// </summary>
        /// <param name="applicationDbContext">Parametro dependencia</param>
        public ContextPersistence(IApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Contexto del repositorio
        /// </summary>
        protected ApplicationDbContext Context
        {
            get { return this.ApplicationDbContext as ApplicationDbContext; }
        }

        /// <summary>
        /// Collección de entidades en el contexto
        /// </summary>
        protected DbSet<T> DatabaseSet { get; set; }
        #endregion

        public T Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
            int result = this.Context.SaveChanges();
            return result == 0 ? null : entity;
        }

        /// <summary>
        /// Remove a register
        /// </summary>
        /// <param name="entity">
        ///     Object will be remove/delete from database
        /// </param>
        /// <returns>Numero de elementos removidos</returns>
        public virtual int Remove(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
            var result = this.Context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="entity">Objeto con información para actualizar</param>
        /// <returns>Returna estatus operacion</returns>
        public virtual bool Update(T entity)
        {
            DbEntityEntry entityModified = this.Context.Entry(entity);
            this.DatabaseSet = this.Context.Set<T>();
            this.DatabaseSet.Attach(entity);
            entityModified.State = EntityState.Modified;
            int result = this.Context.SaveChanges();
            return result >= 0;
        }

        public ICollection<T> FindAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> expresion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public ICollection<T> FindAllAsync(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = this.Context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query.Where(filtro).ToList();
        }

        public ICollection<T> FindAllAsync<TKey>(int pageIndex,
                                                int pageSize,
                                                Expression<Func<T, TKey>> expresion,
                                                Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> FindAllAsync<TKey>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<T, TKey>> expresion)
        {
            throw new NotImplementedException();
        }

        public T FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> expresion)
        {
            IQueryable<T> query = this.Context.Set<T>();

            return query.FirstOrDefault(expresion);
        }

        /// <summary>
        /// Find all records
        /// </summary>
        /// <param name="filtro">Filtro principal</param>
        /// <param name="navigationProperties">elementos de filtro</param>
        /// <returns>Colección generica</returns>
        public virtual ICollection<T> FindAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = this.Context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public T FindFirstAsync(System.Linq.Expressions.Expression<Func<T, bool>> filtro, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = this.Context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query.FirstOrDefault(filtro);
        }


        /// <summary>
        /// Implemente Dispose
        /// </summary>
        public void Dispose()
        {
            if (this.ApplicationDbContext != null)
            {
                this.Context.Dispose();
            }

            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}

