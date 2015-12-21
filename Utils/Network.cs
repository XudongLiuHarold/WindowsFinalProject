using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace PM25onWinPhone.Utils
{
    struct PM_URL
    {
       private string oneCityAllSitesPM25;
       private string oneCityAllSitesPM10;
       private string oneCityAllSitesCO;
       private string oneCityAllSitesNO2;
       private string oneCityAllSitesSO2;
       private string oneCityAllSitesO3;
        private string oneCityAllSitesAQI;
        private string oneSitesAQI;
        private string oneCityAllSitesLocation;
        private string allCities;
        private string allCitiesAQIRanking;
        private string allCitesAllData;

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

        public string OneCityAllSitesLocation
        {
            get
            {
                return oneCityAllSitesLocation;
            }

            set
            {
                oneCityAllSitesLocation = value;
            }
        }

        public string AllCities
        {
            get
            {
                return allCities;
            }

            set
            {
                allCities = value;
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

    class Network
    {
     private readonly string APPKEY = "5j1znBVAsnSf5xQyNQyq";
     private readonly PM_URL pmUrl;
     public Network()
    {
            pmUrl.OneCityAllSitesPM25 = "http://www.pm25.in/api/querys/pm2_5.json?";
            pmUrl.OneCityAllSitesPM10 = "http://www.pm25.in/api/querys/pm10.json?";
            pmUrl.OneCityAllSitesCO = "http://www.pm25.in/api/querys/co.json?";
            pmUrl.OneCityAllSitesNO2 = "http://www.pm25.in/api/querys/no2.json?";
            pmUrl.OneCityAllSitesO3 = "http://www.pm25.in/api/querys/o3.json?";
            pmUrl.OneCityAllSitesSO2 = "http://www.pm25.in/api/querys/so2.json?";
            pmUrl.OneCityAllSitesAQI = "http://www.pm25.in/api/querys/only_aqi.json?";
            pmUrl.OneCityAllSitesLocation = "http://www.pm25.in/api/querys/station_names.json?";
            pmUrl.OneSitesAQI = "http://www.pm25.in/api/querys/aqis_by_station.json?";
            pmUrl.AllCities = "http://www.pm25.in/api/querys.json?";
            pmUrl.AllCitiesAQIRanking = "http://www.pm25.in/api/querys/aqi_ranking.json?";
            pmUrl.AllCitesAllData = "http://www.pm25.in/api/querys/all_cities.json?";
    }
    private void sendRequest(string url)
    {
            var request = HttpWebRequest.Create(url);
            request.Method = "GET";
            request.BeginGetResponse(RequestCallBack, request);
    }
    private void RequestCallBack(IAsyncResult ar)
    {
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
            WebResponse response = request.EndGetResponse(ar);
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string content = reader.ReadToEnd();
                List<SiteDetail> sites = JsonConvert.DeserializeObject<List<SiteDetail>>(content);
                System.Diagnostics.Debug.WriteLine(sites[0].aqi);
            }
     }
       //获取数据
        public void getTheCityAllSitesPM25(string city)
        {
        string realUrl = pmUrl.OneCityAllSitesPM25 + "city=" + city + "&token=" + APPKEY;
        sendRequest(realUrl);
        }
        public void getTheCityAllSitesPM10(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesPM10 + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getTheCityAllSitesCO(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesCO + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getTheCityAllSitesSO2(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesSO2 + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getTheCityAllSitesNO2(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesNO2 + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getTheCityAllSitesO3(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesO3 + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getTheCityAllSitesAQI(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesAQI + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getTheCityAllSitesLocation(string city)
        {
            string realUrl = pmUrl.OneCityAllSitesLocation + "city=" + city + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getOneSiteAQI(string site)
        {
            string realUrl = pmUrl.OneSitesAQI + "station_code=" + site + "&token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getAllCitesList()
        {
            string realUrl = pmUrl.AllCities + "token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getAllCitesAQIRanking()
        {
            string realUrl = pmUrl.AllCitiesAQIRanking + "token=" + APPKEY;
            sendRequest(realUrl);
        }

        public void getAllCitesAllData()
        {
            string realUrl = pmUrl.AllCitesAllData + "token=" + APPKEY;
            sendRequest(realUrl);
        }

    }
}
