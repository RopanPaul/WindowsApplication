using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinuiStopWatch.Command
{
    public class ButtonCommand : ICommand
    {
        Action<object> _buttonClick;
        Func<object, bool> _canbuttonclick;


        public ButtonCommand(Action<object> ButtonClick, Func<object, bool> CanButtonClick)
        {
            this._buttonClick = ButtonClick;
            this._canbuttonclick = CanButtonClick;

        }

        public bool CanExecute(object parameter)
        {
            if (_canbuttonclick == null)
            {
                return true;
            }
            else
            {
                return _canbuttonclick(parameter);
            }

        }

        public void Execute(object parameter)
        {
            _buttonClick(parameter);
        }
        public event EventHandler CanExecuteChanged;
    }
}

