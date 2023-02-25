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
                CurrentList = GetFactory(type).CreateCollection();
            });
        }

        private void CreateCommandRegister()
        {
            this.CreateCommand = new RelayCommand<object>((p) =>
            {
                GetWindowFactory(_currentType).ShowDialog();
            });
        }

        private void UpdateCommandRegister() 
        {
            this.UpdateCommand = new RelayCommand<object>(
            hasSelectedItem(),
            (p) =>
            {
                Console.Write(SelectedItem);
                Console.WriteLine("update");
            });
        }

        private void DeleteCommandRegister()
        {
            this.DeleteCommand = new RelayCommand<object>(
            hasSelectedItem(), 
            (p) =>
            {
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
            return new ViewModelFactory(type).dialog;
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
