
namespace CatalogoMvc.Logic.Services
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.ILogic;
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    public class ApiServices : IApiServices
    {
        /// <summary>
        /// Realiza una peticion Get
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<T>> GetRequest<T>(Uri requestUri)
        {
            ResponseMessage<T> responseMessage = null;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(requestUri);
                    T resultResponse = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    responseMessage = new ResponseMessage<T>(resultResponse);
                }
                catch (Exception ex)
                {
                    responseMessage = new ResponseMessage<T>("Error", ex);
                }
            }

            return responseMessage;
        }

        /// <summary>
        /// Realiza una petición POST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<bool>> PostRequest<T>(Uri requestUri, T request)
        {
            ResponseMessage<bool> responseMessage = null;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");

                try
                {
                    string jsonObjectSerialize = GetSerializeObject(request);
                    StringContent stringContent = new StringContent(jsonObjectSerialize, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(requestUri, stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        responseMessage = new ResponseMessage<bool>(true);
                    }
                }
                catch (Exception ex)
                {
                    responseMessage = new ResponseMessage<bool>("Error", ex);
                }
            }

            return responseMessage;
        }

        /// <summary>
        /// Realiza una petición PUT
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<bool>> PutRequest<T>(Uri requestUri, T request)
        {
            ResponseMessage<bool> responseMessage = null;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");

                    try
                    {
                        string jsonObjectSerialize = GetSerializeObject(request);
                        StringContent stringContent = new StringContent(jsonObjectSerialize, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await httpClient.PutAsync(requestUri, stringContent);

                        if (response.IsSuccessStatusCode)
                        {
                            responseMessage = new ResponseMessage<bool>(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        responseMessage = new ResponseMessage<bool>("Error", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage<bool>("Error", ex);
            }

            return responseMessage;
        }

        /// <summary>
        /// Realiza una petición DELETE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<bool>> DeleteRequest<T>(Uri requestUri, T request)
        {
            ResponseMessage<bool> responseMessage = null;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");

                    try
                    {
                        HttpResponseMessage response = await httpClient.DeleteAsync(requestUri);

                        if (response.IsSuccessStatusCode)
                        {
                            responseMessage = new ResponseMessage<bool>(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        responseMessage = new ResponseMessage<bool>("Error", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = new ResponseMessage<bool>("Error", ex);
            }

            return responseMessage;
        }

        /// <summary>
        /// Obtiene la representación serializada de un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSerialize"></param>
        /// <returns></returns>
        private string GetSerializeObject<T>(T objectSerialize)
        {
            string serializeObject = null;

            try
            {
                serializeObject = JsonConvert.SerializeObject(objectSerialize);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return serializeObject;
        }
    }
}
