using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    struct PMURL
    {
        string GetCityAirByCityId ;
        string GetSitesAirByCityId;
        string GetAllCites;
        string GetAllProvince;
        string GetCiteByProvinceId;

        string oneCityAllSitesPM25;
        string oneCityAllSitesPM10;
        string oneCityAllSitesCO;
        string oneCityAllSitesNO2;
        string oneCityAllSitesSO2;
        string oneCityAllSitesO3;
        string oneCityAllSitesAQI;
        string oneSitesAQI;
        string allCitiesAQIRanking;
        string allCitesAllData;
        public string GetCityAirByCityId1
        {
            get
            {
                return GetCityAirByCityId;
            }

            set
            {
                GetCityAirByCityId = value;
            }
        }

        public string GetSitesAirByCityId1
        {
            get
            {
                return GetSitesAirByCityId;
            }

            set
            {
                GetSitesAirByCityId = value;
            }
        }

        public string GetAllCites1
        {
            get
            {
                return GetAllCites;
            }

            set
            {
                GetAllCites = value;
            }
        }

        public string GetAllProvince1
        {
            get
            {
                return GetAllProvince;
            }

            set
            {
                GetAllProvince = value;
            }
        }

        public string GetCiteByProvinceId1
        {
            get
            {
                return GetCiteByProvinceId;
            }

            set
            {
                GetCiteByProvinceId = value;
            }
        }

        public string OneCityAllSitesPM25
        {
            get
            {
                return oneCityAllSitesPM25;
            }

            set
            {
                oneCityAllSitesPM25 = value;
            }
        }

        public string OneCityAllSitesPM10
        {
            get
            {
                return oneCityAllSitesPM10;
            }

            set
            {
                oneCityAllSitesPM10 = value;
            }
        }

        public string OneCityAllSitesCO
        {
            get
            {
                return oneCityAllSitesCO;
            }

            set
            {
                oneCityAllSitesCO = value;
            }
        }

        public string OneCityAllSitesNO2
        {
            get
            {
                return oneCityAllSitesNO2;
            }

            set
            {
                oneCityAllSitesNO2 = value;
            }
        }

        public string OneCityAllSitesSO2
        {
            get
            {
                return oneCityAllSitesSO2;
            }

            set
            {
                oneCityAllSitesSO2 = value;
            }
        }

        public string OneCityAllSitesO3
        {
            get
            {
                return oneCityAllSitesO3;
            }

            set
            {
                oneCityAllSitesO3 = value;
            }
        }

        public string OneCityAllSitesAQI
        {
            get
            {
                return oneCityAllSitesAQI;
            }

            set
            {
                oneCityAllSitesAQI = value;
            }
        }

        public string OneSitesAQI
        {
            get
            {
                return oneSitesAQI;
            }

            set
            {
                oneSitesAQI = value;
            }
        }

        public string AllCitiesAQIRanking
        {
            get
            {
                return allCitiesAQIRanking;
            }

            set
            {
                allCitiesAQIRanking = value;
            }
        }

        public string AllCitesAllData
        {
            get
            {
                return allCitesAllData;
            }

            set
            {
                allCitesAllData = value;
            }
        }
    }

    class SharedNetwork
    {
        // private var
        private static readonly SharedNetwork instance = new SharedNetwork();
        private readonly string TOKEN = "test123";
        private readonly string APPKEY = "5j1znBVAsnSf5xQyNQyq";
        private readonly PMURL PMURL;
        private int interfaceFlag;
        private object locker = new object();

        // public var 
        /// <summary>
        ///  无限制源
        /// </summary>
        public List<Entity.cityData> Cites;
        public Entity.CityAir theCityAir;
        public Entity.CiteStationAir cityStaionsAir;

        /// <summary>
        /// 有限制源
        /// </summary>
        public List<Entity.CityDetail> sites;
        public List<Entity.CityRanking> ranking;
        public bool withStation = true;
  
        public string exceptionFlag;

        /// <summary>
        ///  private funcation
        /// </summary>
        private  SharedNetwork()
        {
            PMURL.GetCityAirByCityId1 = "http://api.air.hzexe.com/api/air/getCityAir?token="+TOKEN+"&cityid=";
            PMURL.GetSitesAirByCityId1 = "http://api.air.hzexe.com/api/air/getCityStationAir?token="+TOKEN+"&cityid=";
            PMURL.GetCiteByProvinceId1 = "http://api.air.hzexe.com/api/basic/getCitysByProvinceId?token="+TOKEN+ "&ProvinceId=";
            PMURL.GetAllCites1 = "http://api.air.hzexe.com/api/basic/getAllCitys?token=" + TOKEN;
            PMURL.GetAllProvince1 = "http://api.air.hzexe.com/api/basic/getAllProvinces?token=" + TOKEN;

            PMURL.OneCityAllSitesPM25 = "http://www.pm25.in/api/querys/pm2_5.json?";
            PMURL.OneCityAllSitesPM10 = "http://www.pm25.in/api/querys/pm10.json?";
            PMURL.OneCityAllSitesCO = "http://www.pm25.in/api/querys/co.json?";
            PMURL.OneCityAllSitesNO2 = "http://www.pm25.in/api/querys/no2.json?";
            PMURL.OneCityAllSitesO3 = "http://www.pm25.in/api/querys/o3.json?";
            PMURL.OneCityAllSitesSO2 = "http://www.pm25.in/api/querys/so2.json?";
            PMURL.OneCityAllSitesAQI = "http://www.pm25.in/api/querys/only_aqi.json?";

            PMURL.OneSitesAQI = "http://www.pm25.in/api/querys/aqis_by_station.json?";
            PMURL.AllCitiesAQIRanking = "http://www.pm25.in/api/querys/aqi_ranking.json?";

        }

        public async Task initCites()
        {
           interfaceFlag = 1;
           await sendRequest(PMURL.GetAllCites1);
        }

        private async Task sendRequest(string url)
        {
            var request = HttpWebRequest.Create(url);

            request.Method = "GET";
            try
            {
                using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
                {
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();

                        try
                        {
                            switch (interfaceFlag)
                            {
                                case 1:
                                    Entity.City Cityresponse = JsonConvert.DeserializeObject<Entity.City>(content);
                                    Cites = Cityresponse.data;
                                    System.Diagnostics.Debug.WriteLine("==========testing1" + Cites[0].CityName + "=========");
                                    break;
                                case 2:

                                    theCityAir = JsonConvert.DeserializeObject<Entity.CityAir>(content);

                                    System.Diagnostics.Debug.WriteLine("==========testing2" + theCityAir.data.AQI + "=========");
                                    break;
                                case 3:
                                    cityStaionsAir = JsonConvert.DeserializeObject<Entity.CiteStationAir>(content);
                                    System.Diagnostics.Debug.WriteLine("==========testing3" + cityStaionsAir.data[0].AQI + "=========");
                                    break;
                                case 4:
                                    sites = JsonConvert.DeserializeObject<List<Entity.CityDetail>>(content);
                                    System.Diagnostics.Debug.WriteLine("==========testing4" + sites[0].position_name + "=========");
                                    break;
                                case 5:

                                    ranking = JsonConvert.DeserializeObject<List<Entity.CityRanking>>(content);

                                    System.Diagnostics.Debug.WriteLine("==========testing5" + ranking[0].area + "=========");
                                    break;

                                default:
                                    System.Diagnostics.Debug.WriteLine("Testing No this interface");
                                    break;
                            }
                        }
                        catch (JsonException e)
                        {
                            exceptionFlag = e.Message;
                            System.Diagnostics.Debug.WriteLine("Testing" + e.Message);
                        }

                    }
                }
            }
            catch (WebException e)
            {
                exceptionFlag = e.Message;
                System.Diagnostics.Debug.WriteLine("Testing" + e.Message);

            }
        }

        /// <summary>
        ///  public interface 
        /// </summary>
        /// <returns>return the singlton</returns>
        public  static SharedNetwork sharedNetwork()
        {
            return instance;
        }

        /// <summary>
        ///  无限制源的API 采用cityName
        /// </summary>
        /// <param name="cityName"></param>
        public async Task getCityAir(string cityName)
        {
            Entity.cityData theCity = Cites.Find(
                  delegate (Entity.cityData cityData)
                  {
                      return cityData.CityName.Equals(cityName);
                  }
                  );

            if (theCity != null)
            {
                interfaceFlag = 2;
                System.Diagnostics.Debug.WriteLine(PMURL.GetCityAirByCityId1 + theCity.cityid);
                await sendRequest(PMURL.GetCityAirByCityId1 + theCity.cityid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("sorry, we still don't have the data of this city");
            }
        }

        public async Task getSationAir(string cityName)
        {
            Entity.cityData theCity = Cites.Find(
                delegate (Entity.cityData cityData)
                {
                    return cityData.CityName.Equals(cityName);
                }
                );

            if (theCity != null)
            {
                interfaceFlag = 3;
                System.Diagnostics.Debug.WriteLine(PMURL.GetSitesAirByCityId1 + theCity.cityid);
                await sendRequest(PMURL.GetSitesAirByCityId1 + theCity.cityid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("sorry, we still don't have the data of this city");
            }
        }

        /// <summary>
        ///  有请求次数源的API， 采用city
        ///  尽量无限制源的API， 除非需要特别数据
        /// </summary>
        /// <param name="city"></param>


        // 这个接口经常达到调用上限
        public async Task getTheCityAllSitesPM25(string city)
        {
            string realUrl;
            if (withStation)
                realUrl = PMURL.OneCityAllSitesPM25 + "city=" + city + "&token=" + APPKEY;
            else
                realUrl = PMURL.OneCityAllSitesPM25 + "city=" + city + "&token=" + APPKEY + "&station=no";
            interfaceFlag = 4;
            await sendRequest(realUrl);
        }
        public async Task getTheCityAllSitesPM10(string city)
        {
            string realUrl;
            if (withStation)
                 realUrl = PMURL.OneCityAllSitesPM10 + "city=" + city + "&token=" + APPKEY;
            else
                realUrl = PMURL.OneCityAllSitesPM10 + "city=" + city + "&token=" + APPKEY + "&station=no";
            interfaceFlag = 4;
           await sendRequest(realUrl);
        }

        public async Task getTheCityAllSitesCO(string city)
        {
            string realUrl;
            if (withStation)
             realUrl = PMURL.OneCityAllSitesCO + "city=" + city + "&token=" + APPKEY;
            else
             realUrl = PMURL.OneCityAllSitesCO + "city=" + city + "&token=" + APPKEY + "&station=no";
            interfaceFlag = 4;
            await sendRequest(realUrl);
        }

        public async Task getTheCityAllSitesSO2(string city)
        {
            string realUrl;
            if (withStation)
                 realUrl = PMURL.OneCityAllSitesSO2 + "city=" + city + "&token=" + APPKEY;
            else
                realUrl = PMURL.OneCityAllSitesSO2 + "city=" + city + "&token=" + APPKEY + "&station=no";
            interfaceFlag = 4;
            await sendRequest(realUrl);
        }

        public async Task getTheCityAllSitesNO2(string city)
        {
            string realUrl;
            if (withStation)
                 realUrl = PMURL.OneCityAllSitesNO2 + "city=" + city + "&token=" + APPKEY;
            else
                realUrl = PMURL.OneCityAllSitesNO2 + "city=" + city + "&token=" + APPKEY + "&station=no";
             await sendRequest(realUrl);
        }

        public async Task getTheCityAllSitesO3(string city)
        {
            string realUrl;
            if (withStation)
                 realUrl = PMURL.OneCityAllSitesO3 + "city=" + city + "&token=" + APPKEY;
            else
                realUrl = PMURL.OneCityAllSitesO3 + "city=" + city + "&token=" + APPKEY + "&station=no";
            interfaceFlag = 4;
            await sendRequest(realUrl);
        }

        public async Task getTheCityAllSitesAQI(string city)
        {
            string realUrl;
            if (withStation)
                realUrl = PMURL.OneCityAllSitesAQI + "city=" + city + "&token=" + APPKEY;
            else
                realUrl = PMURL.OneCityAllSitesAQI + "city=" + city + "&token=" + APPKEY + "&station=no";
            interfaceFlag = 4;
            await sendRequest(realUrl);
        }


        public async Task getOneSiteAQI(string site)
        {
            string realUrl = PMURL.OneSitesAQI + "station_code=" + site + "&token=" + APPKEY;
            interfaceFlag = 4;
            await sendRequest(realUrl);
        }

        /// <summary>
        ///  这个接口经常调用次数已满
        /// </summary>
        public async Task getAllCitesAQIRanking()
        {
            string realUrl = PMURL.AllCitiesAQIRanking + "token=" + APPKEY;
            interfaceFlag = 5;
            await sendRequest(realUrl);
        }

    }
}
