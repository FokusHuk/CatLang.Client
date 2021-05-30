using Catlang.Client.Contracts;
using Catlang.Client.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Catlang.Client
{
    public static class CatLangRestClient
    {
        public static string Username;

        private static RestClient client;
        private static string token;

        public static void Initialize()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Config/appsettings.json")
                .Build();

            client = new RestClient(configuration["ServerUrl"]);            
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

        public static List<SetDto> GetAllSets()
        {
            var resource = $"sets";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetAllSetsResponse>(response.Content);

            return content.Sets;
        }

        public static ConformityExerciseDto StartConformityExercise(ExerciseFormat exerciseFormat, Guid setId)
        {
            var resource = $"exercises/create/conformity";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                ExerciseFormat = exerciseFormat,
                SetId = setId
            };
            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<ConformityExerciseDto>(response.Content);

            return content;
        }

        public static void CommitConformityAnswer(
            ExerciseFormat exerciseFormat,
            Guid exerciseId,
            Guid setId,
            int wordId,
            string taskAnswer,
            bool userChoice)
        {
            var resource = $"exercises/commit/conformity";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                ExerciseFormat = exerciseFormat,
                ExerciseId = exerciseId,
                SetId = setId,
                WordId = wordId,
                TaskAnswer = taskAnswer,
                UserChoice = userChoice
            };
            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            client.Execute(request);
        }

        public static ChoiceExerciseDto StartChoiceExercise(ExerciseFormat exerciseFormat, Guid setId)
        {
            var resource = $"exercises/create/choice";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                ExerciseFormat = exerciseFormat,
                SetId = setId
            };
            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<ChoiceExerciseDto>(response.Content);

            return content;
        }

        public static void CommitChoiceAnswer(
            ExerciseFormat exerciseFormat,
            Guid exerciseId,
            Guid setId,
            int wordId,
            string chosenAnswer)
        {
            var resource = $"exercises/commit/choice";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                ExerciseFormat = exerciseFormat,
                ExerciseId = exerciseId,
                SetId = setId,
                WordId = wordId,
                ChosenAnswer = chosenAnswer
            };
            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            client.Execute(request);
        }

        public static ExerciseResultDto FinishExercise(Guid exerciseId, ExerciseFormat exerciseFormat)
        {
            var resource = $"exercises/finish";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                ExerciseId = exerciseId,
                ExerciseFormat = exerciseFormat
            };
            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<ExerciseResultDto>(response.Content);

            return content;
        }

        public static List<StudiedSetDto> GetStudiedSets()
        {
            var resource = $"sets/studied/user";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetStudiedSetsResponse>(response.Content);

            return content.StudiedSets;
        }

        public static SetDto GetSetById(Guid setId)
        {
            var resource = $"sets/{setId}";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<SetDto>(response.Content);

            return content;
        }

        public static List<StudiedWordDto> GetStudiedWords()
        {
            var resource = $"words/studied";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetStudiedWordsResponse>(response.Content);

            return content.StudiedWords;
        }

        public static List<CreatedSetDto> GetCreatedSets()
        {
            var resource = $"sets/user";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetCreatedSetsResponse>(response.Content);

            return content.CreatedSets;
        }

        public static List<Guid> GetRecommendedSets()
        {
            var resource = $"recommendations";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetRecommendedSetsResponse>(response.Content);

            return content.RecommendedSets;
        }

        public static List<WordDto> GetAllWords()
        {
            var resource = $"words/all";
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetAllWordsResponse>(response.Content);

            return content.Words;
        }

        public static void CreateSet(string studyTopic, int[] setWordsIds)
        {
            var resource = $"sets";
            var request = new RestRequest(resource, Method.POST);
            var body = new
            {
                StudyTopic = studyTopic,
                SetWordsIds = setWordsIds
            };
            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            client.Execute(request);
        }
    }
}
