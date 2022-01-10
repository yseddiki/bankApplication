using SuperviseurApi.Models.HelbModel;
using SuperviseurApi.Services;
using System.Net.Http.Headers;

namespace SuperviseurApi.Handlers
{
    public class HelbAuthenticationHandler : DelegatingHandler
    {
        private readonly IHelbAuthenticationService _helbAuthenticationService;

        public HelbAuthenticationHandler(IHelbAuthenticationService helbAuthenticationService)
        {
            _helbAuthenticationService = helbAuthenticationService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            UserLogin userLogin = new UserLogin { Password = "123", Username = "Superviseur" };
            var token = await _helbAuthenticationService.RetrieveToken(userLogin);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
