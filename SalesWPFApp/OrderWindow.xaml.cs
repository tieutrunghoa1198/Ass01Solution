using System.Windows;
using SalesWPFApp.ViewModel.Interface;
using SalesWPFApp.ViewModel;
using System;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window, IDialog
    {
        private static OrderWindow instance = null;
        private static readonly object instanceLock = new object();
        public Action CloseDialog { get; set; }
        private OrderWindow()
        {
            InitializeComponent();
        }
        public static OrderWindow Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderWindow();
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

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Instance.Close();
            Instance = null;
            CloseDialog?.Invoke();
        }
    }
}
