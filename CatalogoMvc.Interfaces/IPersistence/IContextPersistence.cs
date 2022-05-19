namespace CatalogoMvc.Interfaces.IPersistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IContextPersistence<T> where T : class
    {
        /// <summary>
        /// Meodo para crear un nuevo registro
        /// </summary>
        /// <param name="entity">Objeto generico</param>
        /// <returns>Resultado de operación</returns>
        T Create(T entity);

        /// <summary>
        /// Remove a register
        /// </summary>
        /// <param name="entity">
        ///     Object will be remove/delete from database
        /// </param>
        /// <returns>Numero de elementos removidos</returns>
        int Remove(T entity);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="entity">Objeto con información para actualizar</param>
        /// <returns>Returna estatus operacion</returns>
        bool Update(T entity);

        /// <summary>
        /// Obtiene un elemento encontrado
        /// </summary>
        /// <param name="expresion">Expresion para búsqueda de elemento</param>
        /// <returns>Retorna elemento encontrado</returns>
        T FindAsync(Expression<Func<T, bool>> expresion);

        /// <summary>
        /// Retorna todos los registros de la bitacora
        /// </summary>
        /// <param name="expresion">Expression lambda</param>
        /// <returns>Colección de registros</returns>
        ICollection<T> FindAllAsync(Expression<Func<T, bool>> expresion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        ICollection<T> FindAllAsync(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Retorna registros por filtro
        /// </summary>
        /// <typeparam name="TKey">Expression Lambda</typeparam>
        /// <param name="pageIndex">Pagina consulta</param>
        /// <param name="pageSize">Tamaño del resultado</param>
        /// <param name="expresion">Expression lambda</param>
        /// <param name="filter">Expression de filtro</param>
        /// <returns>Colección de registros</returns>
        ICollection<T> FindAllAsync<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> expresion, Expression<Func<T, bool>> filter);

        /// <summary>
        /// Retorna registros por rango
        /// </summary>
        /// <typeparam name="TKey">Expression Lambda</typeparam>
        /// <param name="pageIndex">Pagina consulta</param>
        /// <param name="pageSize">Tamaño del resultado</param>
        /// <param name="expresion">Expression lambda</param>
        /// <returns>Colección de registros</returns>
        ICollection<T> FindAllAsync<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> expresion);

        /// <summary>
        /// Find all records
        /// </summary>
        /// <param name="navigationProperties">elementos de filtro</param>
        /// <returns>Colección generica</returns>
        ICollection<T> FindAllAsync(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Get the first record of a table from a filter
        /// </summary>
        /// <param name="filtro">
        ///     Filter function
        /// </param>
        /// <param name="navigationProperties">
        ///     Navigation properties
        /// </param>
        /// <returns>Objeto generico encontrado</returns>
        T FindFirstAsync(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] navigationProperties);
    }
}