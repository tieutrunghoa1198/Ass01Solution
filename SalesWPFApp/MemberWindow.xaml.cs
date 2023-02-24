using System;
using System.Windows;
using SalesWPFApp.ViewModel.Interface;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window, IDialog
    {
        private static MemberWindow instance = null;
        private static readonly object instanceLock = new object();

        private MemberWindow()
        {
            InitializeComponent();
        }
        public static MemberWindow Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MemberWindow();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public void ShowDialog()
        {
            this.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Instance.Close();
            Instance = null;
        }
    }
}
