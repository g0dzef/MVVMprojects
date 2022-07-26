using MVVMproject.Infrastructure.Commands;
using MVVMproject.MVVM.ViewModels.Base;
using MVVMproject.Services.Interfaces;
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
        private readonly IAsyncDataService _asyncDataService;

        private string _dataValue;
        public string DataValue
        {
            get => _dataValue;
            private set => Set(ref _dataValue, value);
        }


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

        #region StartProcessCommand
        public ICommand StartProcessCommand { get; }

        private bool CanStartProcessCommandExecute(object p) => true;
        private void OnStartProcessCommandExecuted(object p)
        {
            DataValue = _asyncDataService.GetResult(DateTime.Now);
        }
        #endregion

        #region StopProcessCommand
        public ICommand StopProcessCommand { get; }

        private bool CanStopProcessCommandExecute(object p) => true;
        private void OnStopProcessCommandExecuted(object p)
        {

        }
        #endregion

        public MainWindowViewModel(IAsyncDataService asyncData)
        {
            _asyncDataService = asyncData;
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            StartProcessCommand = new RelayCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);
            StopProcessCommand = new RelayCommand(OnStopProcessCommandExecuted, CanStopProcessCommandExecute);
        }
    }
}
