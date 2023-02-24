using System;
using System.Windows.Input;
using DataAccess.DTO;
using DataAccess.Repository;
namespace SalesWPFApp.ViewModel
{
    class ProductVM : BaseVM
    {
        private string _productId;
        private string _categoryId;
        private string _productName;
        private string _weight;
        private string _unitPrice;
        private string _unitStock;
        public ICommand ConfirmCommand { get; set; }

        public ProductVM()
        {
            ConfirmCommandRegister();
        }

        private void ConfirmCommandRegister()
        {
            ConfirmCommand = new RelayCommand<object>((p) =>
            {
                ProductRepository repo = new ProductRepository();
                repo.Insert(GetProduct());
            });
        }

        private Product GetProduct()
        {
            return new Product
                (
                    Int32.Parse(ProductId),
                    Int32.Parse(CategoryId),
                    ProductName,
                    Weight,
                    Decimal.Parse(UnitPrice),
                    Int32.Parse(UnitInStock)
                );
        }

        public string ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public string CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public string UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                OnPropertyChanged(nameof(UnitPrice));
            }
        }
        public string UnitInStock
        {
            get
            {
                return _unitStock;
            }
            set
            {
                _unitStock = value;
                OnPropertyChanged(nameof(UnitInStock));
            }
        }
    }
}
