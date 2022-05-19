
namespace CatalogoMvc.Entities
{
    using System;

    /// <summary>
    /// Class for response on solution
    /// </summary>
    /// <typeparam name="T">Tipo generico</typeparam>
    public class ResponseMessage<T>
    {
        #region Constructors

        /// <summary>
        /// Create a instance at correct response
        /// </summary>
        /// <param name="response">Respuesta generica</param>
        public ResponseMessage(T response)
        {
            this.Response = response;
        }

        /// <summary>
        /// Create a instance at wrong response
        /// </summary>
        /// <param name="message">Mensaje de respuesta</param>
        public ResponseMessage(string message)
        {
            this.IsError = true;
            this.Message = message;
        }

        /// <summary>
        /// Create a instance at wrong response
        /// </summary>
        /// <param name="message">Message text error</param>
        /// <param name="errorCode">Code error</param>
        public ResponseMessage(string message, int errorCode)
        {
            this.IsError = true;
            this.Message = message;
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Create a instance at exception error throw
        /// </summary>
        /// <param name="message">Message text error</param>
        /// <param name="exception">Exception throw object</param>
        public ResponseMessage(string message, Exception exception)
        {
            this.IsError = true;
            this.Message = message;
            this.Exception = exception;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Represent throw error code
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Message error response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Flag to error
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Generic object to response
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// Exception throw object
        /// </summary>
        public Exception Exception { get; set; }

        #endregion Properties
    }
}
