using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<Object>
    {
        private LoginViewModel _loginVM;
        public ShellViewModel(LoginViewModel loginVM)
        {
            //here it's a usage of dependency injection with bootstrapper
            //specifically with the part of code demanding the reflection

            _loginVM = loginVM;
            ActivateItemAsync(_loginVM);
        }
    }
}
