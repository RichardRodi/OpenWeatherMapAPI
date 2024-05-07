namespace OpenWeatherMapAPI
{
    public static class MainMenu
    {
        public static void RunMainMenu()
        {
            var client = new WeatherApiRequestService();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            {
                string prompt = ($"\n\n\n\t\t\t ☁  ☁  ☁  Open Weather API ☁  ☁  ☁ \n\n\n" +
                    $"{ArtAssets.Sunset}\n\n\n" +
                    $"\t\t\tFind the Current Temperature (USA) by ZipCode or by State\n");

                string[] options = { "1.Find by Zipcode", "2.Find by City and State",};
                Menu menu = new Menu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        client.CallApiByZipCode();
                        break;

                    case 1:
                        client.CallApiByState();
                        break;

                }

            }
        }
    }
}
