using System;
using System.Windows;
using System.Windows.Input;
using DataAccess.DTO;
using DataAccess.Repository;
using SalesWPFApp.ViewModel.Interface;
namespace SalesWPFApp.ViewModel
{
    class ProductVM : BaseVM, ICloseWindow
    {
        private string _productId;
        private string _categoryId;
        private string _productName;
        private string _weight;
        private string _unitPrice;
        private string _unitStock;
        private ProductRepository repo;
        public ICommand ConfirmCommand { get; set; }
        public Action Close { get; set; }
        public ProductVM()
        {
            repo = new ProductRepository();
            ConfirmCommandRegister();
        }

        private void ConfirmCommandRegister()
        {
            ConfirmCommand = new RelayCommand<object>((p) =>
            {
                try { repo.Insert(GetProduct()); }
                catch (Exception ex)
                {
                    MessageBox.Show("Product id is already existed!");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (ProductName.Equals("") || ProductName == null)
                    {
                        MessageBox.Show("Product name cannot be empty!");
                    }
                    else
                    {
                        Close?.Invoke();
                    }
                }
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
