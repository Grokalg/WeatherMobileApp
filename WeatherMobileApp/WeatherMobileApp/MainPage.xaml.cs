using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherMobileApp
{
    public partial class MainPage : ContentPage
    {
        const string key = "d47dec713f26930dabdd6fa1aeb1f3c8";

        public MainPage()
        {
            InitializeComponent();
            /*Image image = new Image();
            image.Source = ImageSource.FromResource("WeatherMobileApp.Images.main_image.png");
            Content = image;*/
        }

        private async void getWeatherButton_Clicked(object sender, EventArgs e)
        {
            string city = userInput.Text.Trim();
            if (city.Length < 2)
            {
                await DisplayAlert("Error", "City name should be bigger", "Ok");
                return;
            }

            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=metric";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            string temp = json["main"]["temp"].ToString();
            resultLabel.Text = "Температура сейчас: " + temp;
        }
    }
}
