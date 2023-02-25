using System.Windows;
using SalesWPFApp.ViewModel;
using SalesWPFApp.ViewModel.Interface;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginVM login = new LoginVM();
            if (DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            } 
        }
    }
}
