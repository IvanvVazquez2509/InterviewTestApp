using InterviewTestApp.Domain.Enums;

namespace InterviewTestApp.Domain.Entites
{
    public class WeatherForecast
    {
        public string Date { get; set; }
        public Typeofweatherenum WeatherType { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
    }
}
