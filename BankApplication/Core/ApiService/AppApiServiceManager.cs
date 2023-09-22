using BankApplication.Core.Contracts.ApiService;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;

namespace BankApplication.Core.ApiService
{
    public class AppApiServiceManager : IAppApiServiceManager
    {
        private readonly HttpClient _httpClient;

        public AppApiServiceManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AppApiResponseDto> GetAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true)
        {
            try
            {
                var result = await SendAsync(requestData, HttpMethod.Get, withAcceptJsonHeader);
                var content = await GetHttpResponse(result);
                return content;
            }
            catch (Exception)
            {
                throw new Exception(requestData.SourceMethod);
            }
        }

        public async Task<AppApiResponseDto> PostAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true)
        {
            try
            {
                var result = await SendAsync(requestData, HttpMethod.Post, withAcceptJsonHeader);
                var content = await GetHttpResponse(result);
                return content;
            }
            catch (Exception)
            {
                throw new Exception(requestData.SourceMethod);
            }
        }

        public async Task<AppApiResponseDto> PutAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true)
        {
            try
            {
                var result = await SendAsync(requestData, HttpMethod.Put, withAcceptJsonHeader);
                var content = await GetHttpResponse(result);
                return content;
            }
            catch (Exception)
            {
                throw new Exception(requestData.SourceMethod);
            }
        }

        public async Task<AppApiResponseDto> PatchAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true)
        {
            try
            {
                var result = await SendAsync(requestData, HttpMethod.Patch, withAcceptJsonHeader);
                var content = await GetHttpResponse(result);
                return content;
            }
            catch (Exception)
            {
                throw new Exception(requestData.SourceMethod);
            }
        }

        public async Task<AppApiResponseDto> DeleteAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true)
        {
            try
            {
                var result = await SendAsync(requestData, HttpMethod.Delete, withAcceptJsonHeader);
                var content = await GetHttpResponse(result);
                return content;
            }
            catch (Exception)
            {
                throw new Exception(requestData.SourceMethod);
            }
        }

        #region Private Methods
        private async Task<HttpResponseMessage> SendAsync(RequestDataDto requestData, HttpMethod method, bool withAcceptJsonHeader = true)
        {
            _httpClient.DefaultRequestHeaders.Clear();

            if (requestData.Credentials != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = GetCredentialsHeader(requestData.Credentials);
            }

            if (requestData.Headers != null)
            {
                foreach (var header in requestData.Headers)
                {
                    if (!header.Key.IsNullOrEmpty() && !header.Value.IsNullOrEmpty())
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
            }

            requestData.UrlBase = CompleteUrlParameters(requestData);

            if (withAcceptJsonHeader)
            {
                _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            }

            var result = method.ToString().ToUpper() switch
            {
                "GET" => await _httpClient.GetAsync(requestData.UrlBase),
                "POST" => await _httpClient.PostAsync(requestData.UrlBase, GetContent(requestData)),
                "PUT" => await _httpClient.PutAsync(requestData.UrlBase, GetContent(requestData)),
                "PATCH" => await _httpClient.PatchAsync(requestData.UrlBase, GetContent(requestData)),
                "DELETE" => await _httpClient.DeleteAsync(requestData.UrlBase),
                _ => throw new NotImplementedException()
            };

            return result;
        }

        private static async Task<AppApiResponseDto> GetHttpResponse(HttpResponseMessage response)
        {
            AppApiResponseDto result = new() { Status = response.StatusCode.ToString() };

            var content = await response.Content.ReadAsStringAsync();
            result.ContentHtmlResponse = response;

            if (response.IsSuccessStatusCode)
            {
                result.Content = content;
            }
            else
            {
                result.ContentError = content;
            }

            return result;
        }

        private static AuthenticationHeaderValue GetCredentialsHeader(CredentialsDto credentials)
        {
            byte[] authentication = Encoding.ASCII.GetBytes($"{credentials.User}:{credentials.Password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authentication));
        }

        private static string CompleteUrlParameters(RequestDataDto requestData)
        {
            requestData.InLineParameters?.ToList().ForEach(d => { requestData.UrlBase = requestData.UrlBase.Replace($"{{{d.Key}}}", d.Value); });

            if (requestData.Parameters != null)
            {
                requestData.UrlBase += string.Format($"?{string.Join("&", requestData.Parameters.Where(v => !string.IsNullOrEmpty(v.Value?.Trim())).Select(k => string.Format($"{k.Key}={k.Value}")))}");
            }

            return requestData.UrlBase;
        }

        private static HttpContent? GetContent(RequestDataDto requestData)
        {
            if (!string.IsNullOrEmpty(requestData.Body))
            {
                return new StringContent(requestData.Body, Encoding.UTF8, "application/json");
            }
            else if (requestData.FormData != null)
            {
                return new FormUrlEncodedContent(requestData.FormData);
            }
            return null;
        }
        #endregion
    }
}
