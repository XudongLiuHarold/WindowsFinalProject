﻿using System.Collections.Generic;

namespace Entity
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
