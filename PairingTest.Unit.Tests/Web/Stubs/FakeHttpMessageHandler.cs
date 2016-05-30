using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web.Stubs
{
    internal class FakeHttpMessageHandler : HttpMessageHandler
    {
        private string _correctUrl;
        private string _correctUrlReturnContent;

        public FakeHttpMessageHandler(string correctUrl, string correctUrlReturnContent)
        {
            _correctUrl = correctUrl;
            _correctUrlReturnContent = correctUrlReturnContent;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            if (request.RequestUri == new Uri(_correctUrl))
            {
                responseMessage.StatusCode = HttpStatusCode.OK;
                responseMessage.Content = new StringContent(_correctUrlReturnContent);
            }

            return await Task.FromResult(responseMessage);
        }
    }
}
