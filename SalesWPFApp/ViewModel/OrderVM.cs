using DataAccess.DTO;
using DataAccess.Repository;
using SalesWPFApp.ViewModel.Interface;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace SalesWPFApp.ViewModel
{
    class OrderVM : BaseVM, ICloseWindow
    {
        private string _OrderId;
        private string _MemberId;
        private string _OrderDate;
        private string _RequiredDate;
        private string _ShippedDate;
        private string _Freight;
        public string _mySecret;
        private OrderRepository repo;
        public ICommand ConfirmCommand { get; set; }
        public Action Close { get; set; }
        public string mySecret
        {
            get { return _mySecret;  }
            set
            {
                _mySecret = value;
                OnPropertyChanged();
            }
        }
        public OrderVM()
        {
            mySecret = "False";
            repo = new OrderRepository();
            ConfirmCommandRegister();
        }

        private void ConfirmCommandRegister()
        {
            ConfirmCommand = new RelayCommand<object>((p) =>
            {
                switch (mySecret)
                {
                    default:
                        try { repo.Insert(GetOrder()); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("OrderId is already existed!");
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (OrderId.Equals("") || OrderId == null)
                            {
                                MessageBox.Show("OrderId cannot be empty!");
                            }
                            else
                            {
                                CloseWindow();
                            }
                        }
                        break;
                    case "True":
                        try { repo.Update(GetOrder()); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Product id is already existed!");
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (OrderId.Equals("") || OrderId == null)
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

        private void CloseWindow()
        {
            Close?.Invoke();
            OrderId = "";
            MemberId = "";
            OrderDate = "";
            RequiredDate = "";
            ShippedDate = "";
            Freight = "";
        }

        private OrderDTO GetOrder()
        {
            return new OrderDTO
                (
                    Int32.Parse(OrderId),
                    Int32.Parse(MemberId),
                    DateTime.Parse(OrderDate),
                    DateTime.Parse(RequiredDate),
                    DateTime.Parse(ShippedDate),
                    Decimal.Parse(Freight)
                );
        }

        public string OrderId
        {
            get { return _OrderId; }
            set
            {
                _OrderId = value;
                OnPropertyChanged();
            }
        }
        public string MemberId
        {
            get { return _MemberId; }
            set
            {
                _MemberId = value;
                OnPropertyChanged();
            }
        }
        public string OrderDate
        {
            get { return _OrderDate; }
            set
            {
                _OrderDate = value;
                OnPropertyChanged();
            }
        }
        public string RequiredDate
        {
            get { return _RequiredDate; }
            set
            {
                _RequiredDate = value;
                OnPropertyChanged();
            }
        }
        public string ShippedDate
        {
            get { return _ShippedDate; }
            set
            {
                _ShippedDate = value;
                OnPropertyChanged();
            }
        }
        public string Freight
        {
            get { return _Freight; }
            set
            {
                _Freight = value;
                OnPropertyChanged();
            }
        }
    }
}
