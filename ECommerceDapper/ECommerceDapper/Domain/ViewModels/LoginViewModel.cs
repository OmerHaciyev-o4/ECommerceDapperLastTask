using ECommerceDapper.Commands;
using ECommerceDapper.Domain.Entities;
using ECommerceDapper.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ECommerceDapper.Domain.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private static string pass;

        public static string Pass
        {
            get { return pass; }
            set { pass = value; OnPropChanged(); }
        }




        public LoginViewModel()
        {
            LoginCommand = new RelayCommand((sender) =>
            {
                if (App.DB.AdminRepository.GetById(Name) > 0)
                {
                    AdminSide admin = new AdminSide();
                    AdminViewModel.Usernamee = Name;
                    AdminViewModel.Passwordd = Pass;
                    admin.ShowDialog();
                }
                else if (App.DB.UserRepository.GetById(Name) > 0)
                {
                    UserSide user = new UserSide();
                    UserViewModel.Usernamee = Name;
                    UserViewModel.Passwordd = Pass;
                    user.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect Entry !!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}