
namespace CatalogoMvc.Interfaces.ILogic
{
    using System;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        Task<ResponseMessage<T>> GetRequest<T>(Uri requestUri);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ResponseMessage<bool>> PostRequest<T>(Uri requestUri, T request);

        /// <summary>
        /// Realiza una petición PUT
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ResponseMessage<bool>> PutRequest<T>(Uri requestUri, T request);
    }
}
