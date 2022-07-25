using MVVMproject.Infrastructure.Commands;
using MVVMproject.MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMproject.MVVM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _title = "Main window";

        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
    }
}
