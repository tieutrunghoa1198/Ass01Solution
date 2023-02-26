using DataAccess.DTO;
using DataAccess.Repository;
using SalesWPFApp.ViewModel.Interface;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace SalesWPFApp.ViewModel
{
    class MemberVM : BaseVM, ICloseWindow
    {
        private string _MemberId;
        private string _Email;
        private string _CompanyName;
        private string _City;
        private string _Country;
        private string _Password;
        private string _mySecret;
        private MemberRepository repo;
        public ICommand ConfirmCommand { get; set; }
        public Action Close { get; set; }
        public string mySecret
        {
            get { return _mySecret; }
            set
            {
                _mySecret = value;
                OnPropertyChanged();
            }
        }
        public MemberVM()
        {
            EmptyAllFields();
            mySecret = "False";
            repo = new MemberRepository();
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
                        try { Console.WriteLine(GetMember().ToString()); repo.Insert(GetMember()); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Product id is already existed!");
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (MemberId.Equals("") || MemberId == null)
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
                        try { repo.Update(GetMember()); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Product id is already existed!");
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (MemberId.Equals("") || MemberId == null)
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
            EmptyAllFields();
        }

        private void EmptyAllFields()
        {
            MemberId = "";
            Email = "";
            CompanyName = "";
            City = "";
            Country = "";
            Password = "";
        }

        private bool ValidateNotEmpty()
        {
            if (MemberId.Equals("")) return false;
            if (Email.Equals("")) return false;
            if (CompanyName.Equals("")) return false;
            if (City.Equals("")) return false;
            if (Country.Equals("")) return false;
            if (Password.Equals("")) return false;
            return true;
        }

        private MemberDTO GetMember()
        {
            return new MemberDTO
                (
                    Int32.Parse(MemberId.Trim()),
                    Email.Trim(),
                    CompanyName.Trim(),
                    City.Trim(),
                    Country.Trim(),
                    Password.Trim()
                );
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
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                _CompanyName = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged();
            }
        }
        public string Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
    }
}
