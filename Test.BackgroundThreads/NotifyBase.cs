using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test.BackgroundThreads
{
    public class NotifyBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
