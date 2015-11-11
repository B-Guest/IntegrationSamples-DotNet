using BGuest.Integration.Api.Client;
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

        #region Request
        public async Task<List<RequestDto>> GetRequestsAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl =
                    $"api/v2/requests?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<List<RequestDto>>();
            }
        }
        public async Task<List<RequestDto>> GetIntegratedRequestsAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl =
                    $"api/v2/requests/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<List<RequestDto>>();
            }
        }
        public async Task<RequestDto> GetRequestByIdAsync(int requestId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = $"api/v2/requests/{requestId}?apiKey={ApiKey}&apiSecret={ApiSecret}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<RequestDto>();
            }
        }
        public async Task<RequestDto> SetRequestAsIntegratedByIdAsync(int requestId, SetRequestAsIntegratedModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = $"api/v2/requests/{requestId}/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}";

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<RequestDto>();
            }
        }
        public async Task<object> SetRequestStatusByIdAsync(int requestId, RequestStateModelIntegration model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = $"api/v2/requests/{requestId}/state?apiKey={ApiKey}&apiSecret={ApiSecret}";

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<object>();
            }
        }
        #endregion

        #region Stays
        public async Task<List<StayImportResultDto>> ImportStaysAsync(List<StayImportModel> stays)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = $"api/v2/stays?apiKey={ApiKey}&apiSecret={ApiSecret}";

                var responseBGuest = await client.PostAsJsonAsync(requestApiUrl, stays);
                responseBGuest.EnsureSuccessStatusCode();
                return await responseBGuest.Content.ReadAsAsync<List<StayImportResultDto>>();
            }
        }
        public async Task<List<StayReservationDto>> GetImportedStaysAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl =
                    $"api/v2/stays/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

                var responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<List<StayReservationDto>>();
            }
        }
        #endregion

        #region CheckInRequest
        public async Task<List<CheckInRequestDto>> GetCheckInRequestsAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = string.Format("api/v2/requests/checkinrequests?apiKey={0}&apiSecret={1}&fromId={2}&skip={3}&take={4}",
                    ApiKey, ApiSecret, fromId, skip, take);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<List<CheckInRequestDto>>();
            }
        }
        public async Task<List<CheckInRequestDto>> GetIntegratedCheckInRequestsAsync(int? fromId, int? skip, int? take)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = string.Format("api/v2/requests/checkinrequests/integrated?apiKey={0}&apiSecret={1}&fromId={2}&skip={3}&take={4}",
                    ApiKey, ApiSecret, fromId, skip, take);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<List<CheckInRequestDto>>();
            }
        }
        public async Task<CheckInRequestDto> GetCheckInRequestByIdAsync(int requestId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = string.Format("api/v2/requests/checkinrequests/{0}?apiKey={1}&apiSecret={2}",
                    requestId, ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<CheckInRequestDto>();
            }
        }
        public async Task<CheckInRequestDto> SetCheckInRequestAsIntegratedByIdAsync(int requestId, SetCheckInRequestAsIntegratedModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = string.Format("api/v2/requests/checkinrequests/{0}/integrated?apiKey={1}&apiSecret={2}",
                    requestId, ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync<SetCheckInRequestAsIntegratedModel>(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<CheckInRequestDto>();
            }
        }
        public async Task<object> SetCheckInRequestStatusByIdAsync(int requestId, CheckInRequestStateModelIntegration model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestApiUrl = string.Format("api/v2/requests/checkinrequests/{0}/state?apiKey={1}&apiSecret={2}",
                    requestId, ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync<CheckInRequestStateModelIntegration>(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return await responseBGuest.Content.ReadAsAsync<object>();
            }
        }
        #endregion

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
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