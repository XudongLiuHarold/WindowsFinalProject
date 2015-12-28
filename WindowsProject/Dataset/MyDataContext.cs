using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataset
{

    [Database(Name = "MyDataContext")]
    public class MyDataContext : DataContext
    {
        public MyDataContext(string connectionString) : base(connectionString) { }

        public Table<ChoCity> CityTable;
        public Table<ColCity> ColCityTable;
    }
}
