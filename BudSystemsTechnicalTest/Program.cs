using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BudSystemsTechnicalTest
{
    partial class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World. Please type in a 2 or 3 character ISO code for a country.");
            Console.WriteLine("E.g. GB for Great Britain");
            Console.WriteLine("Please type below: ");

            string isoCode = Console.ReadLine();

            Console.WriteLine("you typed " + isoCode);

            if (isoCode.Length > 3 || isoCode.Length < 2)
            {
                Console.WriteLine("Oops, I'm sorry but it looks like you didn't type in a valid ISO country code. Please try again.");
            }

            Console.WriteLine("You've put in " + isoCode + " as your country. Please hit Left Arrow to call the API");


            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.LeftArrow)
            {
                RunAsync(isoCode).GetAwaiter().GetResult();
            }

            Console.WriteLine("thanks for playing");
        }

        static void ShowProduct(Country country)
        {
            Console.WriteLine($"Name: {country.Name}\tCapital City: " +
                $"{country.CapitalCity}\tRegion: {country.Region}");
        }

        static async Task RunAsync(string isoCode)
        {
            try
            {
                client.BaseAddress = new Uri("http://api.worldbank.org/v2/country/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Response responseObj = new Response();
                Country newCountry = new Country();

                HttpResponseMessage response = await client.GetAsync(isoCode + "?format=json");

                if (response.IsSuccessStatusCode)
                {
                    var responseFromServer = await response.Content.ReadAsStringAsync();


                    var deserializedResponseArray = JsonConvert.DeserializeObject<Response>(responseFromServer);

                    // It is at this point that I got stuck after 3 hours. I couldn't deserialize the object as I couldn't get the schema right
                    //for my Response and ResponseArray object. Once the object is deserialized correctly then my code should be able to
                    //manipulate the response data in any shape, including printing to the console. However, this is not possible at the moment.





                    responseObj = JsonConvert.DeserializeObject<Response>(responseFromServer);
                    
                   
                    Console.WriteLine(newCountry.CapitalCity + " " + newCountry.Latitude);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
           

                ShowProduct(newCountry); //print to Console
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<string>(reader);
            long result;
            if(Int64.TryParse(value, out result))
            {
                return result;
            }
            throw new Exception("Cannot do");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
