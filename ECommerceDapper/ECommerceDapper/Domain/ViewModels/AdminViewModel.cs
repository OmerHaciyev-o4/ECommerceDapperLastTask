using ECommerceDapper.Commands;
using ECommerceDapper.Domain.Additional_Classes;
using ECommerceDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ECommerceDapper.Domain.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public static string Usernamee { get; set; }
        public static string Passwordd { get; set; }


        public ICommand CreateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<Product> allProduct;

        public ObservableCollection<Product> AllProduct
        {
            get { return allProduct; }
            set { allProduct = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Order> allOrder;

        public ObservableCollection<Order> AllOrder
        {
            get { return allOrder; }
            set { allOrder = value; OnPropertyChanged(); }
        }


        private Product selectProduct;

        public Product SelectProduct
        {
            get { return selectProduct; }
            set { selectProduct = value; OnPropChan("SelectProduct"); }
        }

        private ObservableCollection<string> texts;

        public ObservableCollection<string> Texts
        {
            get { return texts; }
            set { texts = value; OnPropChanged(); }
        }


        private bool? userChecked;

        public bool? UserChecked
        {
            get { return userChecked; }
            set { userChecked = value; OnPropertyChanged(); }
        }


        private bool? adminChecked;

        public bool? AdminChecked
        {
            get { return adminChecked; }
            set { adminChecked = value; OnPropertyChanged(); }
        }

        private static string pass;

        public static string Pass
        {
            get { return pass; }
            set { pass = value; OnPropChanged(); }
        }


        public AdminViewModel()
        {
            UserChecked = true;
            Texts = new ObservableCollection<string>();
            Texts.Add("");
            Texts.Add("");
            Texts.Add("");
            Texts.Add("");
            Texts.Add("");
            Texts.Add("");

            CreateCommand = new RelayCommand((sender) =>
            {

                if (Texts[0] == "" && Pass == "" || Pass == null)
                    MessageBox.Show("Please set Username or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    if (UserChecked == true)
                    {
                        int result = App.DB.UserRepository.AddUser(new User() { Username = Texts[0], Password = Pass });
                        if (result == 1)
                            MessageBox.Show("User successfully added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        int result = App.DB.AdminRepository.AddAdmin(new Admin() { Username = Texts[0], Password = Pass });
                        if (result == 1)
                            MessageBox.Show("Admin successfully added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });

            AddCommand = new RelayCommand((sender) =>
            {
                if (Texts[1] == "" || Texts[1] == null)
                    MessageBox.Show("Please set Product Code", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (Texts[2] == "" || Texts[2] == null)
                    MessageBox.Show("Please set Product Name", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (Texts[3] == "" || Texts[3] == null)
                    MessageBox.Show("Please set Product Quantity", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (Texts[4] == "" || Texts[4] == null)
                    MessageBox.Show("Please set Product Price", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    Product product = new Product();
                    product.Code = Convert.ToInt32(Texts[1]);
                    product.Name = Texts[2];
                    product.Quantity = Convert.ToInt32(Texts[3]);
                    product.Price = Convert.ToDouble(Texts[4]);

                    int result = App.DB.ProductRepository.ProductAdd(product);

                    if (result == 1)
                    {
                        MessageBox.Show("Product successfully added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        setData();
                    }
                    else
                        MessageBox.Show("INCORRECT ENTRY", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            UpdateCommand = new RelayCommand((sender) =>
            {
                if (Texts[1] == "" || Texts[1] == null)
                    MessageBox.Show("Please set Product Code", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (Texts[2] == "" || Texts[2] == null)
                    MessageBox.Show("Please set Product Name", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (Texts[3] == "" || Texts[3] == null)
                    MessageBox.Show("Please set Product Quantity", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (Texts[4] == "" || Texts[4] == null)
                    MessageBox.Show("Please set Product Price", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(Texts[5]);
                    product.Code = Convert.ToInt32(Texts[1]);
                    product.Name = Texts[2];
                    product.Quantity = Convert.ToInt32(Texts[3]);
                    product.Price = Convert.ToDouble(Texts[4]);

                    int result = App.DB.ProductRepository.ProductUpdate(product);

                    if (result == 1)
                    {
                        MessageBox.Show("Product successfully updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        setData();
                    }
                    else
                        MessageBox.Show("INCORRECT ENTRY", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, (pred) =>
            {
                if (SelectProduct != null)
                {
                    return true;
                }
                return false;
            });

            DeleteCommand = new RelayCommand((sender) =>
            {
                int result = App.DB.ProductRepository.ProductDelete(Convert.ToInt32(Texts[5]));

                if (result == 1)
                {
                    MessageBox.Show("Product successfully deleted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    setData();
                }
                else
                    MessageBox.Show("INCORRECT ENTRY", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }, (pred) =>
            {
                if (SelectProduct != null)
                {
                    return true;
                }
                return false;
            });

            setData();
        }

        private void setData()
        {
            var productList = App.DB.ProductRepository.GetAllData();
            if (productList != null)
                AllProduct = ObservableHelper.ToObservableCollection(productList);

            var orderList = App.DB.OrderRepository.GetAllData();
            if (orderList != null)
                AllOrder = ObservableHelper.ToObservableCollection(orderList);
        }

        public event PropertyChangedEventHandler PropChan;

        protected void OnPropChan([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropChan;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            if (SelectProduct != null)
            {
                Texts.Clear();
                Texts.Add("");
                Texts.Add(SelectProduct.Code.ToString());
                Texts.Add(SelectProduct.Name.ToString());
                Texts.Add(SelectProduct.Quantity.ToString());
                Texts.Add(SelectProduct.Price.ToString());
                Texts.Add(SelectProduct.Id.ToString());
            }
        }
    }
}