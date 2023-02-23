using DataAccess;
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
        public ICommand CreateCommand { get; set; }
        public ICommand ShowTable { get; set; }
        public ICommand ShowMemberTable { get; set; }
        public ICommand ShowOrderTable { get; set; }
        private static FactoryTest factory;
        private ObservableCollection<object> _currentList;
        
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
            ShowTableRegister();
            ShowMemberRegister();
            ShowOrderRegister();
            CreateCommandRegister();
        }   

        private void ShowTableRegister()
        {
            this.ShowTable = new RelayCommand<object>((p) =>
            {
                ClearList();
                CurrentList = GetFactory("product").CreateCollection();
            });
        }

        private void ShowMemberRegister()
        {
            this.ShowMemberTable = new RelayCommand<object>((p) =>
            {
                ClearList();
                CurrentList = GetFactory("order").CreateCollection();
            });
        }

        private void ShowOrderRegister()
        {
            this.ShowOrderTable = new RelayCommand<object>((p) =>
            {
                ClearList();
                CurrentList = GetFactory("order").CreateCollection();
            });
        }

        private void CreateCommandRegister()
        {
            this.CreateCommand = new RelayCommand<object>((p) =>
            {
                CurrentList.Add(new Product(1, "asd"));
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
