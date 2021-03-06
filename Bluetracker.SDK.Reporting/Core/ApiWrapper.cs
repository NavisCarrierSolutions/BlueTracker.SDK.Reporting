﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bluetracker.SDK.Reporting.Core
{
    /// <summary>
    /// Abstracts from specific calls to the ApiControllers.
    /// </summary>
    internal abstract class ApiWrapper
    {
        private readonly string _serverAddress;
        private readonly string _authorization;
        private readonly HttpClient _httpClient = new HttpClient();

        private const string DefaultServerAddress = "https://api.bluetracker-reporting.com";

        protected ApiWrapper(string authorization) : this(null, authorization)
        {
        }

        protected ApiWrapper(string serverAddress, string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                throw new ArgumentNullException(nameof(authorization));
            }

            _serverAddress = serverAddress;

            if (string.IsNullOrEmpty(_serverAddress))
            {
                _serverAddress = DefaultServerAddress;
            }

            _authorization = authorization;

            _httpClient.BaseAddress = new Uri(_serverAddress);
            _httpClient.DefaultRequestHeaders.Authorization = GetAuthHeader();
        }

        protected TR PostObject<TR, TI>(TI postObject, string route)
        {
            var json = JsonConvert.SerializeObject(postObject,
                new JsonSerializerSettings {DateTimeZoneHandling = DateTimeZoneHandling.Unspecified});

            var request = new HttpRequestMessage(HttpMethod.Post, route);

            request.Headers.Authorization = GetAuthHeader();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            
            HttpResponseMessage response;
            string content;

            try
            {
                var sendTask = _httpClient.SendAsync(request);
                sendTask.Wait();
                response = sendTask.Result;

                var readTask = sendTask.Result.Content.ReadAsStringAsync();
                readTask.Wait();
                content = readTask.Result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to communicate with BlueCloud API on {_serverAddress}.", ex);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpException((int) response.StatusCode,
                    $"Failed to post object with code {response.StatusCode}. Message: {content}");
            }

            try
            {
                var ret = JsonConvert.DeserializeObject<TR>(content);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize answer. Possibly it's not of type {typeof(TR)}", ex);
            }
        }

        protected TR PutObject<TR, TI>(TI putObject, string route)
        {
            var json = JsonConvert.SerializeObject(putObject,
                new JsonSerializerSettings { DateTimeZoneHandling = DateTimeZoneHandling.Unspecified });

            var request = new HttpRequestMessage(HttpMethod.Put, route);

            request.Headers.Authorization = GetAuthHeader();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            HttpResponseMessage response;
            string content;

            try
            {
                var sendTask = _httpClient.SendAsync(request);
                sendTask.Wait();
                response = sendTask.Result;

                var readTask = sendTask.Result.Content.ReadAsStringAsync();
                readTask.Wait();
                content = readTask.Result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to communicate with BlueCloud API on {_serverAddress}.", ex);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpException((int)response.StatusCode,
                    $"Failed to post object with code {response.StatusCode}. Message: {content}");
            }

            try
            {
                var ret = JsonConvert.DeserializeObject<TR>(content);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize answer. Possibly it's not of type {typeof(TR)}", ex);
            }
        }

        protected TR DeleteObject<TR>(string route)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, route);

            request.Headers.Authorization = GetAuthHeader();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;
            string content;

            try
            {
                var sendTask = _httpClient.SendAsync(request);
                sendTask.Wait();
                response = sendTask.Result;

                var readTask = sendTask.Result.Content.ReadAsStringAsync();
                readTask.Wait();
                content = readTask.Result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to communicate with BlueCloud API on {_serverAddress}.", ex);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpException((int)response.StatusCode,
                    $"Failed to post object with code {response.StatusCode}. Message: {content}");
            }

            try
            {
                var ret = JsonConvert.DeserializeObject<TR>(content);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize answer. Possibly it's not of type {typeof(TR)}", ex);
            }
        }

        protected TR PostEmpty<TR>(string route)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, route);

            request.Headers.Authorization = GetAuthHeader();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;
            string content;

            try
            {
                var sendTask = _httpClient.SendAsync(request);
                sendTask.Wait();
                response = sendTask.Result;

                var readTask = sendTask.Result.Content.ReadAsStringAsync();
                readTask.Wait();
                content = readTask.Result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to communicate with BlueCloud API on {_serverAddress}.", ex);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpException((int)response.StatusCode,
                    $"Failed to post with code {response.StatusCode}. Message: {content}");
            }

            try
            {
                var ret = JsonConvert.DeserializeObject<TR>(content);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize answer. Possibly it's not of type {typeof(TR)}", ex);
            }
        }

        protected JObject GetJson(string route)
        {
            var requestString = CombineRoute(route);

            string content = null;

            try
            {
                var response = _httpClient.GetAsync(requestString);

                response.Wait();

                var responseMessage = response.Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseStreamTask = responseMessage.Content.ReadAsStreamAsync();
                    responseStreamTask.Wait();

                    var responseStream = responseStreamTask.Result;

                    if (responseStream == null)
                        return null;

                    using (var reader = new StreamReader(responseStream))
                    {
                        content = reader.ReadToEnd();
                    }
                }

                if (responseMessage.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException((int)responseMessage.StatusCode,
                        $"Failed to retrieve data with code {responseMessage.StatusCode}. Message: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }

            try
            {
                return JObject.Parse(content);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse the server answer into a valid JSON object.", ex);
            }
        }

        protected T GetObject<T>(string route)
        {
            var requestString = CombineRoute(route);

            string content = null;

            try
            {
                var response = _httpClient.GetAsync(requestString);
                
                response.Wait();

                var responseMessage = response.Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseStreamTask = responseMessage.Content.ReadAsStreamAsync();
                    responseStreamTask.Wait();

                    var responseStream = responseStreamTask.Result;

                    if (responseStream == null)
                        return default(T);

                    using (var reader = new StreamReader(responseStream))
                    {
                        content = reader.ReadToEnd();
                    }
                }

                if (responseMessage.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException((int)responseMessage.StatusCode,
                        $"Failed to retrieve data with code {responseMessage.StatusCode}. Message: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to contact {requestString}", ex);
            }

            try
            {
                var ret = JsonConvert.DeserializeObject<T>(content,
                    new JsonSerializerSettings
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                    });

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize answer. Possibly it's not of type {typeof(T)}", ex);
            }
        }

        private string CombineRoute(string route)
        {
            var requestString = _serverAddress.TrimEnd('/') + "/" + route.TrimStart('/');

            return requestString;
        }

        private AuthenticationHeaderValue GetAuthHeader() => new AuthenticationHeaderValue("ApiKey", _authorization);
    }
}
