using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using static AspMVC.Models.WeatherViewModel;

public class WeatherController : Controller
{
    public async Task<IActionResult> Windex()
    {
        string apiKey = "4a27f543c7d84c9aa46224819231708";
        string city = "Birmingham"; // You can make this dynamic

        using (HttpClient client = new HttpClient())
        {
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(jsonData);
                return View(weatherInfo);
            }
            else
            {
                // Handle the error
                return View("Error");
            }
        }
    }
}
