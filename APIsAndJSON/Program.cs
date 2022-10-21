using System.Net.Http;
using Newtonsoft.Json.Linq;
using System;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var https = new HttpClient();
            string kanyeSaid;
            string ronSaid;
            string kanyeQuoted;
            string ronQuoted;

            for (int i = 0; i < 5; i++)
            {
                kanyeSaid = https.GetStringAsync("https://api.kanye.rest/").Result;
                ronSaid = https.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                kanyeQuoted = JObject.Parse(kanyeSaid).GetValue("quote").ToString();
                ronQuoted = JArray.Parse(ronSaid).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Kanye: {kanyeQuoted}");
                Console.WriteLine($"Ron: {ronQuoted}");
                Console.WriteLine("");
            }
        }
    }
}
