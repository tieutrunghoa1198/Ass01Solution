using System;
using System.Windows.Input;
using System.Windows;
using SalesWPFApp.ViewModel.Interface;

namespace SalesWPFApp.ViewModel
{
    class LoginVM : BaseVM, ICloseWindow
    {
        private string _UserName;
        private string _Password;
        public ICommand LoginCommand { get; set; }
        public Action Close { get; set; }
        public string UserName 
        { 
            get => _UserName; 
            set 
            { 
                _UserName = value; 
                OnPropertyChanged(); 
            } 
        }
        public string Password 
        { 
            get => _Password; 
            set 
            { 
                _Password = value; 
                OnPropertyChanged(); 
            } 
        }

        public LoginVM()
        {
            LoginCommandRegister();
        }

        private void LoginCommandRegister()
        {
            LoginCommand = new RelayCommand<LoginWindow>((p) =>
            {
                return true;
            }, (p) =>
            {
                var sysAccount = AppSetting.GetAccount();
                string sysUserName = sysAccount["username"] ?? "";
                string sysPassword = sysAccount["password"] ?? "";
                Boolean matchUserName = UserName.ToLower().Equals(sysUserName);
                Boolean matchPassword = Password.ToLower().Equals(sysPassword);
                Boolean matchAccount = matchPassword && matchUserName;
                if (matchAccount)
                {
                    MainWindow mainScreen = new MainWindow();
                    CloseWindow();
                    mainScreen.Show();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Wrong username or password.", 
                        "Login failed", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
            });
        }

        public void CloseWindow()
        {
            Close?.Invoke();
        }
    } 
}
