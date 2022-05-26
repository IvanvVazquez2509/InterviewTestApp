using InterviewTestApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestApp.Domain.Entites
{
    public class TableWeatherForecast : BaseUIModel
    {
        public DateTime Date { get; set; }
        public int WeatherTypeId { get; set; }
        public virtual LstWeatherType? WeatherType { get; set; } = null;
        public double TemperatureCelseus { get; set; }
        public string? Description { get; set; }
    }
}
