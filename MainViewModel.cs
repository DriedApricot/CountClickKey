﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using CountClickKey.Localization;

namespace CountClickKey
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IEnumerable<CultureInfo> _cultureInfos;
        private CultureInfo _currentCulture;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<CultureInfo> CultureInfos
        {
            get { return _cultureInfos ?? (_cultureInfos = LocalizationManager.Instance.Cultures); }
            set
            {
                if (Equals(value, _cultureInfos)) return;
                _cultureInfos = value;
                OnPropertyChanged();
            }
        }

        public CultureInfo CurrentCulture
        {
            get { return _currentCulture ?? (_currentCulture = LocalizationManager.Instance.CurrentCulture); }
            set
            {
                if (Equals(value, _currentCulture)) return;

                Properties.Settings.Default.DefaultLanguage = value;
                Properties.Settings.Default.Save();

                _currentCulture = value;
                LocalizationManager.Instance.CurrentCulture = value;
                OnPropertyChanged();
            }
        }
    }
}
