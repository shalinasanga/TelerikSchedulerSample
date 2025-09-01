using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class EventLabelModel : INotifyPropertyChanged
    {
        public Guid LabelId { get; set; }
        public string LabelCaption { get; set; }
        public int LabelColor { get; set; }
        public Nullable<Guid> F_OrganizationID { get; set; }
        public Nullable<bool> SystemDefined { get; set; }
        private string _HexColor;
        public string HexColor
        {
            get { return _HexColor; }
            set
            {
                _HexColor = value;
                OnPropertyChanged();
            }
        }
        public bool IsSelect { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
