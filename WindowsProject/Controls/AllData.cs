using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls;
using Entity;
using Dataset;

namespace Controls
{
    class AllData
    {
        public static AllData allDataList = new AllData();
        public static int cityIndex = 0; 
        static List<ChoCity> lcitys = new List<ChoCity>();
        static List<List<StationData>> stationList = new List<List<StationData>>();
        static List<data> avgData = new List<data>();
        static List<String> measureList = new List<string>();
        static Dictionary<int, List<DataForBinding>> hashMap = new Dictionary<int, List<DataForBinding>>();
        private AllData()
        { }

       
        public static AllData getAllData()
        {
            return allDataList;
        }

        public void addAvgData(int i, List<DataForBinding> lists)
        {
            hashMap.Add(i, lists);
        }

        public void addStationData(List<StationData> list)
        {
            stationList.Add(list);
        }

        public Dictionary<int, List<DataForBinding>> getHashMap()
        {
            return hashMap;
        }


        public List<List<StationData>> getStationList()
        {
            return stationList;
        }

        public void addAvgData(data data)
        {
            avgData.Add(data);
        }

        public List<data> getAvgData()
        {
            return avgData;
        }

        public void addMeasure(string measure)
        {
            measureList.Add(measure);
        }

        public List<string> getMeasure()
        {
            return measureList;
        }

        public List<ChoCity> Lcitys
        {
            get
            {
                return lcitys;
            }

            set
            {
                lcitys = value;
            }
        }

        public int CityIndex
        {
            get 
            {
                return cityIndex;
            }
            set
            {
                cityIndex = value;
            }
        }
    }
}
