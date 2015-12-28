using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataset
{
    [Table(Name="City")]
    public class ChoCity : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private string _CityName;
        [Column(IsPrimaryKey = true)]
        public string CityName
        {
            get { return _CityName; }
            set
            {
                if (_CityName != value)
                {
                    NotifyPropertyChanging("CityName");
                    _CityName = value;
                    NotifyPropertyChanged("CityName");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
        #endregion
    }
}
