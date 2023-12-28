using System.Net;
using System.Text.Json;

namespace Robin.NetStandard.Tests
{
    public class ActionHandler : HttpMessageHandler
    {
        public Func<HttpRequestMessage, Task<HttpResponseMessage>> Run { get; }

        public ActionHandler(Action<HttpRequestMessage> run, object response, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = req =>
            {
                run(req);
                return Task.FromResult(new HttpResponseMessage(code) { Content = new StringContent(JsonSerializer.Serialize(response)) });
            };
        }

        public ActionHandler(Action<HttpRequestMessage> run, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = req =>
            {
                run(req);
                return Task.FromResult(new HttpResponseMessage(code));
            };
        }

        public ActionHandler(Func<HttpRequestMessage, Task> run, object response, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = async req =>
            {
                await run(req);
                return new HttpResponseMessage(code) { Content = new StringContent(response is string ? response.ToString() : JsonSerializer.Serialize(response)) };
            };
        }

        public ActionHandler(Func<HttpRequestMessage, Task> run, HttpStatusCode code = HttpStatusCode.OK)
        {
            Run = async req =>
            {
                await run(req);
                return new HttpResponseMessage(code);
            };
        }

        public ActionHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> run)
        {
            Run = run;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Run(request);
        }
    }
}
