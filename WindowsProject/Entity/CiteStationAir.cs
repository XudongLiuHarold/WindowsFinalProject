using System.Collections.Generic;

namespace Entity
{
    class StationData
    {
        public string AQI{ get; set; }
        public string CO{ get; set; }
       public string Measure{ get; set; }
       public string NO2{ get; set; }
       public string O3{ get; set; }
       public string PM10{ get; set; }
       public string PM2_5{ get; set; }
       public string PrimaryPollutant { get; set; }
       public string Quality { get; set; }
       public string SO2 { get; set; }
       public string TimePoint { get; set; }
       public string Unheathful { get; set; }
       public string cityid { get; set; }
       public string Area { get; set; }
       public string Latitude { get; set; }
       public string Longitude { get; set; }
       public string PositionName{ get; set; }//观测站名字
       public string O3_24h { get; set; }
       public string SO2_24h { get; set; }
       public string PM2_5_24h { get; set; }
       public string PM10_24h { get; set; }
       public string O3_8h_24h { get; set; }
       public string O3_8h { get; set; }
       public string NO2_24h { get; set; }
       public string CO_24h { get; set; }

    }

    class CiteStationAir
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public List<StationData> data { get; set; }

    }
}
