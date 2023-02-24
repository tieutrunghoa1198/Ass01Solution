using DataAccess.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml.Linq;
using System.Collections.ObjectModel;
namespace SalesWPFApp.ViewModel
{
    class MainWindowVM : BaseVM
    {
        private ObservableCollection<object> _currentList;
        private string _currentType { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ShowTable { get; set; }

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
            CurrentList = new ObservableCollection<object>();
            _currentType = "";
            ShowTableRegister();
            CreateCommandRegister();
            UpdateCommandRegister();
            DeleteCommandRegister();
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
                Console.Write(_currentType);
                CurrentList.Add(new Product(1, "asd"));
            });
        }

        private void UpdateCommandRegister() 
        {
            this.UpdateCommand = new RelayCommand<object>((p) =>
            {
                Console.WriteLine("update");
            });
        }

        private void DeleteCommandRegister()
        {
            this.DeleteCommand = new RelayCommand<object>((p) =>
            {
                Console.WriteLine("delete");
            });
        }

        private FactoryTest GetFactory(string type)
        {
            return new CollectionFactory(type).MyObject;
        }

        private void ClearList()
        {
            CurrentList.Clear();
        }
    }
}
