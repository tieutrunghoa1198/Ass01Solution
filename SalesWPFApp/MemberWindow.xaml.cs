using System;
using System.Windows;
using SalesWPFApp.ViewModel.Interface;
using SalesWPFApp.ViewModel;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window, IDialog
    {
        private static MemberWindow instance = null;
        private static readonly object instanceLock = new object();
        public Action CloseDialog { get; set; }
        private MemberWindow()
        {
            InitializeComponent();
            MemberVM member = new MemberVM();
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
            Instance.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Instance.Close();
            Instance = null;
            CloseDialog?.Invoke();
        }
    }
}
