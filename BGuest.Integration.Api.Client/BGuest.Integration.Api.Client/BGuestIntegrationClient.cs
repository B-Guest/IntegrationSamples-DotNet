using BGuest.Integration.Api.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BGuest.Integration.Api.Client
{
    public class BGuestIntegrationClient : IDisposable
    {
        #region Properties

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Api key to be used for all service requests. 
        /// </summary>
        public Guid ApiKey { get; set; }

        /// <summary>
        /// Api secreet to be used for all service requests. 
        /// </summary>
        public string ApiSecret { get; set; }

        #endregion

        public BGuestIntegrationClient(string baseUri, Guid apiKey, string apiSecret)
        {
            BaseUri = new Uri(baseUri);
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        public async Task<List<RequestDto>> GetRequestsAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get BGuest request data.
                var requestApiUrl =
                    $"api/v2/requests?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<List<RequestDto>>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        public async Task<List<RequestDto>> GetIntegratedRequestsAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get BGuest integrated requests data.
                var requestApiUrl =
                    $"api/v2/requests/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<List<RequestDto>>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        public async Task<RequestDto> GetRequestByIdAsync(int requestId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get BGuest request data.
                var requestApiUrl = $"api/v2/requests/{requestId}?apiKey={ApiKey}&apiSecret={ApiSecret}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<RequestDto>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        public async Task<RequestDto> SetRequestAsIntegratedByIdAsync(int requestId, SetRequestAsIntegratedModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get BGuest request data.
                var requestApiUrl = $"api/v2/requests/{requestId}/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}";

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<RequestDto>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        public async Task<object> SetRequestStatusByIdAsync(int requestId, RequestStateModelIntegration model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Set BGuest api uri.
                var requestApiUrl = $"api/v2/requests/{requestId}/state?apiKey={ApiKey}&apiSecret={ApiSecret}";

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<object>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        public async Task<List<StayImportResultDto>> ImportStaysAsync(List<StayImportModel> stays)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Set BGuest api uri.
                var requestApiUrl = $"api/v2/stays?apiKey={ApiKey}&apiSecret={ApiSecret}";

                var responseBGuest = await client.PostAsJsonAsync(requestApiUrl, stays);
                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<List<StayImportResultDto>>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        public async Task<List<StayReservationDto>> GetImportedStaysAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get BGuest integrated requests data.
                var requestApiUrl =
                    $"api/v2/stays/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<List<StayReservationDto>>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BGuestIntegrationClient() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}