using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    public class WeatherApiRequestService
    {
        public async Task CallApi()
        {
            string key = File.ReadAllText("appsettings.json");

            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            while (true)
            {
                Console.WriteLine("Enter your ZipCode: ");
                var zipCode = Console.ReadLine();
                int num = -1;
                try
                {
                    if (zipCode.Length == 5 && int.TryParse(zipCode, out num))
                    {
                        Console.WriteLine("Valid ZipCode!\n");
                        var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIKey}";
                        Console.WriteLine($"\nIt is currently {WeatherMap.GetTemp(apiCall)} degrees!\n");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid ZipCode");
                    }
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("\nThe entered ZipCode is not found. Please enter a valid ZipCode.\n");
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine($"\nAn Error Occurred. {ex.Message} Please enter a valid zipcode\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn Error Occurred. {ex.Message} Please enter a valid zipcode\n");
                }

            }
        }
    }
}
