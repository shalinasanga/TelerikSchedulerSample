using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class StaffFunctionModel : INotifyPropertyChanged
    {
        private Guid _StaffFunctionId;
        public Guid StaffFunctionId
        {
            get { return _StaffFunctionId; }
            set
            {
                _StaffFunctionId = value;
                OnPropertyChanged();
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public Guid F_OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public Guid Pk_FunctionToEventId { get; set; }
        public Guid F_ResourceId { get; set; }

        public bool NormalFunction
        {
            get
            {
                return !(StaffFunctionId == Guid.Empty);
            }
        }

        public bool AddNewFunction
        {
            get
            {
                return StaffFunctionId == Guid.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class StaffFunctionList : ObservableCollection<StaffFunctionModel>
    {

    }
}
