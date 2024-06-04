using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace OmdbAPI.Models
{
    public class MovieDAL
    {

        public static MovieModel GetMovie(string name)
        {
            string url = $"http://www.omdbapi.com/?apikey={secret.apiKey}&t={name}";

            HttpWebRequest request = WebRequest.CreateHttp(url) ;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse() ;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd() ;

            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result ;

        }

    }
}
