using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataset
{
    [Table(Name="ColCity")]
    public class ColCity : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private string _ColCityName;
        [Column(IsPrimaryKey = true)]
        public string ColCityName
        {
            get { return _ColCityName; }
            set
            {
                if (_ColCityName != value)
                {
                    NotifyPropertyChanging("ColCityName");
                    _ColCityName = value;
                    NotifyPropertyChanged("ColCityName");
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
