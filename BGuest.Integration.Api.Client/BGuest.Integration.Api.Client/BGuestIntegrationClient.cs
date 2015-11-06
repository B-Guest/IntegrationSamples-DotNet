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
        private Uri _baseUri;
        private Guid _apiKey;
        private string _apiSecret;

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }

        /// <summary>
        /// Api key to be used for all service requests. 
        /// </summary>
        public Guid ApiKey
        {
            get { return this._apiKey; }
            set { this._apiKey = value; }
        }

        /// <summary>
        /// Api secreet to be used for all service requests. 
        /// </summary>
        public string ApiSecret
        {
            get { return this._apiSecret; }
            set { this._apiSecret = value; }
        }

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

                var requestApiUrl = string.Format("api/v2/requests?apiKey={0}&apiSecret={1}&fromId={2}&skip={3}&take={4}",
                    ApiKey, ApiSecret, fromId, skip, take);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

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

                var requestApiUrl = string.Format("api/v2/requests/integrated?apiKey={0}&apiSecret={1}&fromId={2}&skip={3}&take={4}",
                    ApiKey, ApiSecret, fromId, skip, take);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

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

                var requestApiUrl = string.Format("api/v2/requests/{0}?apiKey={1}&apiSecret={2}",
                    requestId, ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

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

                var requestApiUrl = string.Format("api/v2/requests/{0}/integrated?apiKey={1}&apiSecret={2}",
                    requestId, ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync<SetRequestAsIntegratedModel>(requestApiUrl, model);

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

                var requestApiUrl = string.Format("api/v2/requests/{0}/state?apiKey={1}&apiSecret={2}",
                    requestId, ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.PutAsJsonAsync<RequestStateModelIntegration>(requestApiUrl, model);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<object>(await responseBGuest.Content.ReadAsStringAsync());
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

                var requestApiUrl = string.Format("api/v2/stays?apiKey={0}&apiSecret={1}", ApiKey, ApiSecret);

                HttpResponseMessage responseBGuest = await client.PostAsJsonAsync<List<StayImportModel>>(requestApiUrl, stays);
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

                var requestApiUrl = string.Format("api/v2/stays/integrated?apiKey={0}&apiSecret={1}&fromId={2}&skip={3}&take={4}",
                    ApiKey, ApiSecret, fromId, skip, take);

                HttpResponseMessage responseBGuest = await client.GetAsync(requestApiUrl);

                responseBGuest.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<List<StayReservationDto>>(await responseBGuest.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<List<CheckInRequestDto>>(await responseBGuest.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<List<CheckInRequestDto>>(await responseBGuest.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<CheckInRequestDto>(await responseBGuest.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<CheckInRequestDto>(await responseBGuest.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<object>(await responseBGuest.Content.ReadAsStringAsync());
            }
        }
        #endregion

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