using System;
using System.Windows;
using System.Windows.Input;
using DataAccess.DTO;
using DataAccess.Repository;
using SalesWPFApp.ViewModel.Interface;

namespace SalesWPFApp.ViewModel.Interface
{
    interface IProductVM
    {
        void ConfirmCommandRegister();
        Product GetProduct();

    }
}
