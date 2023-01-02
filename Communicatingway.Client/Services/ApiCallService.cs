using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalamud.Logging;
using Newtonsoft.Json;

namespace Communicatingway.Client.Services
{
    public class ApiCallService : IApiCallService
    {
        public async Task SendMessage(string sender, string message)
        {
            var requestBody = new Dictionary<string, string>
            {
                { "Sender", sender },
                { "Message", message },
                { "Timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()}
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{Commway.Configuration.BasicAuthUsername}:{Commway.Configuration.BasicAuthPassword}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            PluginLog.LogDebug($"Endpoint: {Commway.Configuration.Endpoint}");
            PluginLog.LogDebug($"Request Body: {JsonConvert.SerializeObject(requestBody)}");

            HttpResponseMessage response = await Task.Run(() => httpClient.PostAsync(Commway.Configuration.Endpoint, stringContent).Result);

            if (response.IsSuccessStatusCode)
            {
                PluginLog.LogDebug("Endpoint call is success.");
            }
            else
            {
                PluginLog.LogDebug("Endpoint call is failed: {0} ({1}).", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
