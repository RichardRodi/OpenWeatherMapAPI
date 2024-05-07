using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    public class WeatherApiRequestService
    {
        public async Task CallApiByZipCode()
        {
            string key = File.ReadAllText("appsettings.json");

            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            while (true)
            {
                Console.WriteLine($"\t\t\n\nPlease enter your ZipCode: ");
                var zipCode = Console.ReadLine();
                int num = -1;
                try
                {
                    if (zipCode.Length == 5 && int.TryParse(zipCode, out num))
                    {
                        Console.WriteLine("Valid ZipCode:\n");
                        var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIKey}";
                        Console.WriteLine($"\n\t\tIt is currently {WeatherMap.GetTemp(apiCall)} degrees!\n");
                        Console.ReadKey();
                        MainMenu.RunMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("\t\tPlease enter a valid ZipCode.");
                    }
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("\n\t\tThe entered ZipCode is not found. Please enter a valid ZipCode.\n");
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine($"\n\t\tAn Error Occurred. {ex.Message} Please enter a valid zipcode\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\t\tAn Error Occurred. {ex.Message} Please enter a valid zipcode\n");
                }
              
            }
            
        }
           
        
        public async Task CallApiByState()
        {
            string key = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            while (true)
            {

                Console.WriteLine($"\t\t\n\nPlease enter your City: ");
                var cityName = Console.ReadLine();
                Console.WriteLine($"\t\t\n\nPlease enter your State Abbreviation: ");
                var stateCode = Console.ReadLine();
                var countryCode = "US";
                try
                {
                    if (!string.IsNullOrEmpty(cityName) && int.TryParse(cityName, out _) == false)
                    {
                        
                        var apiCall = $"https://api.openweathermap.org/data/2.5/weather?q={cityName},{stateCode},{countryCode}&units=imperial&appid={APIKey}";
                        Console.WriteLine($"\n\t\tIt is currently {WeatherMap.GetTemp(apiCall)} degrees!\n");
                        Console.ReadKey();
                        MainMenu.RunMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("\tPlease enter a valid City.");
                    }
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("\n\t\tThe entered City is not found. Please enter a valid City.\n");
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine($"\n\t\tAn Error Occurred.\n{ex.Message}\n" +
                        $"\tPlease enter a valid City.\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\t\tAn Error Occurred.\n{ex.Message}\n" +
                        $"\tPlease enter a valid City.\n");
                }

            }

        }
    }
}
