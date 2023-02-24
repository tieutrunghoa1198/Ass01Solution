using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SalesWPFApp.ViewModel.Interface;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window, IDialog
    {
        private static ProductWindow instance = null;
        private static readonly object instanceLock = new object();

        private ProductWindow() 
        {
            InitializeComponent();
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
        }

        public void ShowDialog()
        {
            this.Show();
        }
    }
}
