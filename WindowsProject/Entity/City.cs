using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM25onWinPhone.Entity
{
    class cityData
    {
        public string cityid;
        public string CityName;
        public string provinceId;
    }

    class City
    {
        public string statusCode;
        public string message;
        public List<cityData> data;
       
    }
}
