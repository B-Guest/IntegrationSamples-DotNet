using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BGuest.Integration.Api.Client
{
    public class BGuestIntegrationClient : IDisposable
    {
        private HttpClient _client;

        #region Properties

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri { get; }

        /// <summary>
        /// Api key to be used for all service requests. 
        /// </summary>
        public Guid ApiKey { get; }

        /// <summary>
        /// Api secreet to be used for all service requests. 
        /// </summary>
        public string ApiSecret { get; }

        #endregion

        public BGuestIntegrationClient(string baseUri, Guid apiKey, string apiSecret)
        {
            BaseUri = new Uri(baseUri);
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            _client = new HttpClient
            {
                BaseAddress = BaseUri
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region Request

        public async Task<List<RequestDto>> GetRequestsAsync(int? fromId, int? skip, int? take)
        {
            var requestApiUrl =
                $"api/v2/requests?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<List<RequestDto>>();
        }

        public async Task<List<RequestDto>> GetIntegratedRequestsAsync(int? fromId, int? skip, int? take)
        {
            var requestApiUrl =
                $"api/v2/requests/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<List<RequestDto>>();
        }

        public async Task<RequestDto> GetRequestByIdAsync(int requestId)
        {
            var requestApiUrl = $"api/v2/requests/{requestId}?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<RequestDto>();
        }

        public async Task<RequestDto> SetRequestAsIntegratedByIdAsync(int requestId, SetRequestAsIntegratedModel model)
        {
            var requestApiUrl = $"api/v2/requests/{requestId}/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.PutAsJsonAsync(requestApiUrl, model);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<RequestDto>();
        }

        public async Task<object> SetRequestStatusByIdAsync(int requestId, RequestStateModelIntegration model)
        {
            var requestApiUrl = $"api/v2/requests/{requestId}/state?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.PutAsJsonAsync(requestApiUrl, model);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<object>();
        }

        #endregion

        #region Stays

        public async Task<List<StayImportResultDto>> ImportStaysAsync(List<StayImportModel> stays)
        {
            var requestApiUrl = $"api/v2/stays?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.PostAsJsonAsync(requestApiUrl, stays);
            responseBGuest.EnsureSuccessStatusCode();
            return await responseBGuest.Content.ReadAsAsync<List<StayImportResultDto>>();
        }

        public async Task<List<StayReservationDto>> GetImportedStaysAsync(int? fromId, int? skip, int? take)
        {
            var requestApiUrl =
                $"api/v2/stays/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<List<StayReservationDto>>();
        }

        #endregion

        #region CheckInRequest

        public async Task<List<CheckInRequestDto>> GetCheckInRequestsAsync(int? fromId, int? skip, int? take)
        {
            var requestApiUrl =
                $"api/v2/requests/checkinrequests?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<List<CheckInRequestDto>>();
        }

        public async Task<List<CheckInRequestDto>> GetIntegratedCheckInRequestsAsync(int? fromId, int? skip, int? take)
        {
            var requestApiUrl =
                $"api/v2/requests/checkinrequests/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}&fromId={fromId}&skip={skip}&take={take}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<List<CheckInRequestDto>>();
        }

        public async Task<CheckInRequestDto> GetCheckInRequestByIdAsync(int requestId)
        {
            var requestApiUrl = $"api/v2/requests/checkinrequests/{requestId}?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<CheckInRequestDto>();
        }

        public async Task<CheckInRequestDto> SetCheckInRequestAsIntegratedByIdAsync(int requestId, SetCheckInRequestAsIntegratedModel model)
        {
            var requestApiUrl =
                $"api/v2/requests/checkinrequests/{requestId}/integrated?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.PutAsJsonAsync(requestApiUrl, model);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<CheckInRequestDto>();
        }

        public async Task<object> SetCheckInRequestStatusByIdAsync(int requestId, CheckInRequestStateModelIntegration model)
        {
            var requestApiUrl =
                $"api/v2/requests/checkinrequests/{requestId}/state?apiKey={ApiKey}&apiSecret={ApiSecret}";

            var responseBGuest = await _client.PutAsJsonAsync(requestApiUrl, model);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<object>();
        }

        public async Task<IEnumerable<CheckInRequestDto>> GetCheckInRequestsToIntegrateAsync(int? skip, int? take)
        {
            var requestApiUrl = $"api/v2/requests/checkinrequests/tointegrate?apiKey={ApiKey}&apiSecret={ApiSecret}&skip={skip}&take={take}";

            var responseBGuest = await _client.GetAsync(requestApiUrl);

            responseBGuest.EnsureSuccessStatusCode();

            return await responseBGuest.Content.ReadAsAsync<List<CheckInRequestDto>>();
        }

        #endregion

        #region IDisposable Support

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }
        #endregion

    }
}