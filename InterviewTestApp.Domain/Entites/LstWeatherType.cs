using InterviewTestApp.Domain.Common;

namespace InterviewTestApp.Domain.Entites
{
    public class LstWeatherType : BaseModel
    {
        public string? Type { get; set; }
        public virtual ICollection<TableWeatherForecast> WeatherForecasts { get; set; }
    }

}
