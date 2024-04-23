namespace OpenWeatherMapAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var client = new WeatherApiRequestService();
            client.CallApi();
        }
    }
}
