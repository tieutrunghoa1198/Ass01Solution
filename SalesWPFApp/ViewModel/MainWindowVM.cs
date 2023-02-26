using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using BusinessObject;
using SalesWPFApp.ViewModel.Interface;
using BusinessObject.Factory;
using SalesWPFApp.Factory;
using System.Windows;
using DataAccess.DTO;
namespace SalesWPFApp.ViewModel
{
    class MainWindowVM : BaseVM
    {
        private ObservableCollection<object> _currentList;
        private string _currentType { get; set; }
        private object _selectedItem { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand ShowTable { get; set; }
        private bool IsCreateDialogOpen { get; set; }
        public MainWindowVM() 
        {
            _currentType = "member";
            CurrentList = GetListByType();
            ShowTableRegister();
            CreateCommandRegister();
            UpdateCommandRegister();
            DeleteCommandRegister();
            SearchCommandRegister();
        }   

        private void ShowTableRegister()
        {
            this.ShowTable = new RelayCommand<object>((param) =>
            {
                ClearList();
                string type = param.ToString().ToLower();
                _currentType = type;
                CurrentList = GetListByType();
            });
        }

        private void CreateCommandRegister()
        {
            this.CreateCommand = new RelayCommand<object>((p) =>
            {
                IsCreateDialogOpen = true;
                var dialog = (Window)GetWindowFactory(_currentType);
                dialog.Show();
                dialog.Closed += DataWindow_Closing;
            });
        }

        private void UpdateCommandRegister() 
        {
            this.UpdateCommand = new RelayCommand<object>(
            hasSelectedItem(),
            (p) =>
            {
                switch (_currentType)
                {
                    case "product":
                        Product product = (Product)SelectedItem;
                        var productWindow = (ProductWindow)GetWindowFactory(_currentType);
                        productWindow.idTxtBox.Text = product.ProductId.ToString();
                        productWindow.mySecret.Text = "True";
                        productWindow.categoryTxtBox.Text = product.CategoryId.ToString();
                        productWindow.nameTxtBox.Text = product.ProductName.ToString();
                        productWindow.weightTxtBox.Text = product.Weight.ToString();
                        productWindow.unitPriceTxtBox.Text = product.UnitPrice.ToString();
                        productWindow.unitStockTxtBox.Text = product.UnitInStock.ToString();
                        productWindow.ShowDialog();
                        productWindow.Closed += DataWindow_Closing;
                        break;
                    case "order":
                        OrderDTO order = (OrderDTO)SelectedItem;
                        var orderWindow = (OrderWindow)GetWindowFactory(_currentType);
                        orderWindow.orderIdTxt.Text = order.OrderId.ToString();
                        orderWindow.mySecret.Text = "True";
                        orderWindow.memberIdTxt.Text = order.MemberId.ToString();
                        orderWindow.orderDateTxt.Text = order.OrderDate.ToString();
                        orderWindow.requireDateTxt.Text = order.RequiredDate.ToString();
                        orderWindow.shippedDateTxt.Text = order.ShippedDate.ToString();
                        orderWindow.freightTxt.Text = order.Freight.ToString();
                        orderWindow.ShowDialog();
                        orderWindow.Closed += DataWindow_Closing;
                        break;
                    case "member":
                        MemberDTO member = (MemberDTO)SelectedItem;
                        var memberWindow = (MemberWindow)GetWindowFactory(_currentType);
                        memberWindow.memberIdTxt.Text = member.MemberId.ToString();
                        memberWindow.mySecret.Text = "True";
                        memberWindow.emailTxt.Text = member.Email.ToString();
                        memberWindow.companyNameTxt.Text = member.CompanyName.ToString();
                        memberWindow.cityTxt.Text= member.City.ToString();
                        memberWindow.countryTxt.Text = member.Country.ToString();
                        memberWindow.passwordTxt.Text = member.Password.ToString();
                        memberWindow.ShowDialog();
                        memberWindow.Closed += DataWindow_Closing;
                        break;
                }


                Console.WriteLine("update");
            });
        }

        private void DeleteCommandRegister()
        {
            this.DeleteCommand = new RelayCommand<object>(
            hasSelectedItem(), 
            (p) =>
            {
                CRUDFactory.GetBusinessObject(_currentType).Delete(SelectedItem);
                CurrentList = GetListByType();
            });
        }

        private void SearchCommandRegister()
        {
            this.SearchCommand = new RelayCommand<object>(
            (p) => { return _currentType.ToLower().Equals("product"); },
            (p) =>
            {
                Console.WriteLine("delete");
            });
        }

        private void DataWindow_Closing(object sender, EventArgs e)
        {
            CurrentList = GetListByType();
            IsCreateDialogOpen = false;
        }

        private ObservableCollection<object> GetListByType()
        {
            return GetFactory(_currentType).CreateCollection();
        }
        private IDataGridFactory GetFactory(string type)
        {
            return new CollectionFactory(type).MyList;
        }

        private IDialog GetWindowFactory(string type)
        {
            return ViewModelFactory.Instance().dialog(type);
        }

        private Predicate<object> hasSelectedItem()
        {
            return (p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                if (IsCreateDialogOpen)
                {
                    return false;
                }
                else return true;
            };
        }

        private void ClearList()
        {
            CurrentList.Clear();
        }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ObservableCollection<object> CurrentList
        {
            get { return _currentList; }
            set
            {
                _currentList = value;
                OnPropertyChanged("CurrentList");
            }
        }
    }
}
