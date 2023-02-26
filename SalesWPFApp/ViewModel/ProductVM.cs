using System;
using System.Diagnostics.Metrics;
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
        private string _mySecret;
        public string mySecret 
        { 
            get
            {
                return _mySecret;
            }
            set
            {
                _mySecret = value;
            } 
        }
        private ProductRepository repo;
        public ICommand ConfirmCommand { get; set; }
        public Action Close { get; set; }
        public ProductVM()
        {
            EmptyAllFields();
            mySecret = "False";
            repo = new ProductRepository();
            ConfirmCommandRegister();
        }

        private void ConfirmCommandRegister()
        {
            ConfirmCommand = new RelayCommand<object>(
            (p) =>
            {
                return ValidateNotEmpty();
            },
            (p) =>
            {
                switch (mySecret)
                {
                    default:
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
                                CloseWindow();
                            }
                        }
                        break;
                    case "True":
                        try { repo.Update(GetProduct()); }
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
                                CloseWindow();
                            }
                        }
                        Console.WriteLine();
                        break;
                }
            });
        }

        private bool ValidateNotEmpty()
        {
            if (ProductId.Equals("")) return false;
            if (CategoryId.Equals("")) return false;
            if (ProductName.Equals("")) return false;
            if (Weight.Equals("")) return false;
            if (UnitPrice.Equals("")) return false;
            if (UnitInStock.Equals("")) return false;
            return true;
        }

        private void CloseWindow()
        {
            Close?.Invoke();
            EmptyAllFields();
        }

        private void EmptyAllFields()
        {
            ProductId = "";
            CategoryId = "";
            ProductName = "";
            Weight = "";
            UnitPrice = "";
            UnitInStock = "";
        }

        private Product GetProduct()
        {
            return new Product
                (
                    Int32.Parse(ProductId.Trim()),
                    Int32.Parse(CategoryId.Trim()),
                    ProductName.Trim(),
                    Weight.Trim(),
                    Decimal.Parse(UnitPrice.Trim()),
                    Int32.Parse(UnitInStock.Trim())
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
