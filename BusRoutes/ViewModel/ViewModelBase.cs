using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;


namespace BusRoutes.ViewModel 
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public ViewModelBase ()
		{
		}

		protected void Notify([CallerMemberName] string propertyName = "")
		{
			OnPropertyChanged (propertyName);
		}

		protected virtual void OnPropertyChanged (string name)
		{
			var ev = PropertyChanged;
			if (ev != null) {
				ev (this, new PropertyChangedEventArgs (name));
			}
		}
	}
}

