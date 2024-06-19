using Newtonsoft.Json;
using System.Text;

namespace tpw.APIConsumer
{
    public static class Crud<T>
    {
        // Crud
        public static T Create(string apiUrl, T datos)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                );
                var json = JsonConvert.SerializeObject(datos);
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl );
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var  response = client.SendAsync(request);
                response.Wait();

                json = response.Result.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        // cRud
        public static T[] Read_All(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(apiUrl);
                response.Wait();

                var json = response.Result;
                var result = JsonConvert.DeserializeObject<T[]>(json);
                return result;
            }
        }

        public static T Read_ById(string apiUrl, int id)
        {
            using (var client = new HttpClient())
            {
                apiUrl = apiUrl + "/" + id.ToString();
                var response = client.GetStringAsync(apiUrl);
                response.Wait();

                var json = response.Result;
                var result = JsonConvert.DeserializeObject<T> (json);
                return result;
            }
        }

        // crUd
        public static bool Update(string apiUrl, int id, T datos)
        {
            using (var client = new HttpClient())
            {
                apiUrl = apiUrl + "/" + id.ToString();
                client.DefaultRequestHeaders.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                );
                var json = JsonConvert.SerializeObject(datos);
                var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.SendAsync(request);
                response.Wait();

                return true;
            }
        }

        // cruD
        public static bool Delete(string apiUrl, int id)
        {
            using (var client = new HttpClient()) 
            {
                apiUrl = apiUrl + "/" + id.ToString();
                client.DeleteAsync(apiUrl).Wait();
                return true;
            }
        }
    }
}