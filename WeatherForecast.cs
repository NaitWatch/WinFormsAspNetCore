using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WinFormsAspNetCore
{
    
    [DataContract]
    public class WeatherForecast
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int TemperatureC { get; set; }

        [DataMember]
        public int TemperatureF { get { return 32 + (int)(TemperatureC / 0.5556); } set { } }

        [DataMember]
        public string? Summary { get; set; }


    }
}