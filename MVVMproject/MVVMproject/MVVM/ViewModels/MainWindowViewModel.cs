using MVVMproject.MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
