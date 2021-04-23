using System;

namespace testAPI
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int? TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)((TemperatureC.HasValue? TemperatureC.Value :0)/ 0.5556);

        public string Summary { get; set; }
    }
}
