using Caliburn.Micro;
using System;
using System.Threading.Tasks;
using TRMDesktopUI.Helpers;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public string UserName
        {
            get { return _userName; }
            set { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                //Here we call password a component that have been set as a passwordBox from source code (Tim Corey), check the videos to get the right call
                //there is a question about security here and with the passwordBox component
            }
        }

        public bool CanLogIn(string userName, string password)
        {
            bool output = false;
            if (userName.Length > 0 && password.Length > 0)
            {
                output = true;
            }
            return output;
        }
        public async Task LogIn()
        {
            try {
                var result = await _apiHelper.Authenticate(UserName, Password);
            }
            catch ( Exception ex) {

                Console.WriteLine(ex.Message);
            }      
        }
    }
}
