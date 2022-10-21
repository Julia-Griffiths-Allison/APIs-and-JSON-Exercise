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

            var weather = new HttpClient();
            
            Console.WriteLine("Can you give me your zip code?");
            var zip = Console.ReadLine();
            Console.WriteLine("And now what is your country?");
            var country = Console.ReadLine().ToLower();

            if (country == "america")
            {
                country = "US";
            }
            else if (country == "usa")
            {
                country = "US";
            }
            else if(country == "united states")
            {
                country = "US";
            }
            else
            {
                Console.WriteLine("Sorry! I could not identify your country, try typing ''usa''.");
            }
            var apiKey = "14c94a8a4a7c87f64ac9e787c33278cb";

            var URL = ($"http://api.openweathermap.org/geo/1.0/zip?zip={zip},{country}&appid={apiKey}");
            var forecast = weather.GetStringAsync(URL).Result;

            var another = JObject.Parse(forecast);
            Console.WriteLine(forecast);
        }
    }
}
