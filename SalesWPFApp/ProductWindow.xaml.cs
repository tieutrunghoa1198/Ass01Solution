
using System;
using System.Windows;
using SalesWPFApp.ViewModel.Interface;
using SalesWPFApp.ViewModel;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window, IDialog
    {
        private static ProductWindow instance = null;
        private static readonly object instanceLock = new object();
        public Action CloseDialog { get; set; }
        private ProductWindow()
        {
            InitializeComponent();
            if (DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
        public static ProductWindow Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductWindow();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        

        private void Window_Closed(object sender, EventArgs e)
        {
            Instance.Close();
            Instance = null;
            categoryTxtBox.Text = "";
            idTxtBox.Text = "";
            nameTxtBox.Text = "";
            weightTxtBox.Text = "";
            unitPriceTxtBox.Text = "";
            unitStockTxtBox.Text = "";
            mySecret.Text = "";
            CloseDialog?.Invoke();
        }

        public void ShowDialog()
        {
            Instance.Show();
        }

    }
}
