
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace MVVMproject.MVVM.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handlers = PropertyChanged;
            if (handlers is null) return;

            var invoketionList = handlers.GetInvocationList();
            var arg = new PropertyChangedEventArgs(propertyName);

            foreach (var action in invoketionList)
            {
                if (action.Target is DispatcherObject dispatcherObject)
                    dispatcherObject.Dispatcher.Invoke(action, this, arg);
                else
                    action.DynamicInvoke(this, arg);
            }
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        //~BaseViewModel()
        //{
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _disposed) return;
            _disposed = true;
        }
    }
}
