using ECommerceDapper.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ECommerceDapper.Domain.Views
{
    /// <summary>
    /// Interaction logic for AdminSide.xaml
    /// </summary>
    public partial class AdminSide : Window
    {
        public AdminSide()
        {
            InitializeComponent();
        }
        private void box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            AdminViewModel.Pass = box.Password;
        }
    }
}
