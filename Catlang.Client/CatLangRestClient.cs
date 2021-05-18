using Catlang.Client.Contracts;
using Catlang.Client.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Catlang.Client
{
    public static class CatLangRestClient
    {
        public static string Username;

        private static RestClient client;
        private static string token;

        public static void Initialize(string serverUrl)
        {
            client = new RestClient(serverUrl);
            
        }

        public static bool Authorize(string login, string password)
        {
            var resource = $"authentication";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                login = login,
                password = password
            };
            request.AddJsonBody(body);

            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = JsonConvert.DeserializeObject<AuthenticationResponse>(response.Content);
                token = content.AccessToken;
                Username = content.Username;
                return true;
            }
            else
                return false;
        }

        public static bool CreateUser(string username, string login, string password)
        {
            var resource = $"registration";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                username = username,
                login = login,
                password = password
            };
            request.AddJsonBody(body);

            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public static List<Set> GetAllSets()
        {
            var resource = $"sets";
            var request = new RestRequest(resource, Method.GET);
            var response = client.Execute(request);
            request.AddHeader("Authorization", "Bearer " + token);

            var content = JsonConvert.DeserializeObject<GetAllSetsResponse>(response.Content);

            return content.Sets;
        }
    }
}
