using System.Collections.Generic;

namespace Entity
{
    class StationData
    {
        public string AQI;
        public string CO;
  public string Measure;
  public string NO2;
  public string O3;
  public string PM10;
  public string PM2_5;
  public string PrimaryPollutant;
  public string Quality;
  public string SO2;
  public string TimePoint;
  public string Unheathful;
  public string cityid;
  public string Area;
  public string Latitude;
  public string Longitude;
  public string PositionName;//观测站名字
  public string O3_24h;
  public string SO2_24h;
  public string PM2_5_24h;
  public string PM10_24h;
  public string O3_8h_24h;
  public string O3_8h;
  public string NO2_24h;
  public string CO_24h;

    }

    class CiteStationAir
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public List<StationData> data { get; set; }

    }
}
