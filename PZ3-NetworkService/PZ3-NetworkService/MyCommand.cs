﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PZ3_NetworkService
{
    public class MyCommand
    {

        public class MyICommand : ICommand
        {
            Action _TargetExecuteMethod;
            Func<bool> _TargetCanExecuteMethod;

            public MyICommand(Action executeMethod)
            {
                _TargetExecuteMethod = executeMethod;
            }

            public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
            {
                _TargetExecuteMethod = executeMethod;
                _TargetCanExecuteMethod = canExecuteMethod;
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }

            bool ICommand.CanExecute(object parameter)
            {

                if (_TargetCanExecuteMethod != null)
                {
                    return _TargetCanExecuteMethod();
                }

                if (_TargetExecuteMethod != null)
                {
                    return true;
                }

                return false;
            }

            public event EventHandler CanExecuteChanged = delegate { };

            void ICommand.Execute(object parameter)
            {
                _TargetExecuteMethod?.Invoke();
            }
        }

        public class MyICommand<T> : ICommand
        {

            Action<T> _TargetExecuteMethod;
            Func<T, bool> _TargetCanExecuteMethod;

            public MyICommand(Action<T> executeMethod)
            {
                _TargetExecuteMethod = executeMethod;
            }

            public MyICommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            {
                _TargetExecuteMethod = executeMethod;
                _TargetCanExecuteMethod = canExecuteMethod;
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }

            #region ICommand Members

            bool ICommand.CanExecute(object parameter)
            {

                if (_TargetCanExecuteMethod != null)
                {
                    T tparm = (T)parameter;
                    return _TargetCanExecuteMethod(tparm);
                }

                if (_TargetExecuteMethod != null)
                {
                    return true;
                }

                return false;
            }

            public event EventHandler CanExecuteChanged = delegate { };

            void ICommand.Execute(object parameter)
            {
                _TargetExecuteMethod?.Invoke((T)parameter);
            }

            #endregion
        }




    }
}
