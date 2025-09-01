
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class ViewModelBase 
    {
        public ViewModelBase()
        {
        }
        private bool isBusy;
        /// <summary>
        /// Gets or sets if the view is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private bool _IsNoConnection;
        public bool IsNoConnection
        {
            get { return _IsNoConnection; }
            set
            {
                _IsNoConnection = value;
                OnPropertyChanged();
            }
        }

        private INavigation _navigation;
        public INavigation Navigation
        {
            get { return _navigation; }
            set { SetProperty(ref _navigation, value); }
        }
        protected void SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

