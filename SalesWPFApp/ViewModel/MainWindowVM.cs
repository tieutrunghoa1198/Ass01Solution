using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using BusinessObject;
using SalesWPFApp.ViewModel.Interface;
using BusinessObject.Factory;
using SalesWPFApp.Factory;
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

        public MainWindowVM() 
        {
            _currentType = "member";
            CurrentList = new MemberObject().CreateCollection();
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

        private ObservableCollection<object> GetListByType()
        {
            return GetFactory(_currentType).CreateCollection();
        }

        private void CreateCommandRegister()
        {
            this.CreateCommand = new RelayCommand<object>((p) =>
            {
                var dialog = GetWindowFactory(_currentType);
                dialog.ShowDialog();
                dialog.CloseDialog += () =>
                {
                    CurrentList = GetListByType();
                };
            });
        }

        private void UpdateCommandRegister() 
        {
            this.UpdateCommand = new RelayCommand<object>(
            hasSelectedItem(),
            (p) =>
            {

                

                
                Console.WriteLine("update");
            });
        }

        private void DeleteCommandRegister()
        {
            this.DeleteCommand = new RelayCommand<object>(
            hasSelectedItem(), 
            (p) =>
            {
                switch (_currentType)
                {
                    case "product":
                        DataAccess.DTO.Product asdz = (DataAccess.DTO.Product)SelectedItem;
                        DataAccess.Repository.ProductRepository productRepo = new DataAccess.Repository.ProductRepository();
                        productRepo.Delete(asdz);
                        CurrentList = GetListByType();
                        break;
                    case "order":
                        DataAccess.DTO.OrderDTO asd2 = (DataAccess.DTO.OrderDTO)SelectedItem;
                        DataAccess.Repository.OrderRepository orderRepo = new DataAccess.Repository.OrderRepository();
                        orderRepo.Delete(asd2);
                        CurrentList = GetListByType();
                        break;
                    case "member":
                        DataAccess.DTO.MemberDTO as3d = (DataAccess.DTO.MemberDTO)SelectedItem;
                        DataAccess.Repository.MemberRepository memberRepo = new DataAccess.Repository.MemberRepository();
                        memberRepo.Delete(as3d);
                        CurrentList = GetListByType();

                        break;
                }
                Console.WriteLine("delete");
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
                else return true;
            };
        }

        private void ClearList()
        {
            CurrentList.Clear();
        }
    }
}
