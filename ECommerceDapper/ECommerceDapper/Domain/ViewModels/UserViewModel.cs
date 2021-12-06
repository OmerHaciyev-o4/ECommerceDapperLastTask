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
using System.Windows.Threading;

namespace ECommerceDapper.Domain.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public static string Usernamee { get; set; }
        public static string Passwordd { get; set; }


        public ICommand OrderNow { get; set; }
        private double price = 0;

        private ObservableCollection<string> texts;

        public ObservableCollection<string> Texts
        {
            get { return texts; }
            set { texts = value; OnPropChanged(); }
        }



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
            set { selectProduct = value; OnPropChang(); }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        DispatcherTimer timer;
        public UserViewModel()
        {
            Texts = new ObservableCollection<string>();
            Texts.Add("");
            Texts.Add("");
            Texts.Add("");

            OrderNow = new RelayCommand((sender) =>
            {
                if ((Texts[0] == "" || Texts[0] == null) && SelectProduct == null)
                    MessageBox.Show("Please select product or set product code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else if ((Texts[1] == "" || Texts[1] == null) && SelectProduct == null)
                    MessageBox.Show("Please select product or set product name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    int userId = App.DB.UserRepository.GetById(Usernamee);
                    int productId = App.DB.ProductRepository.GetById(Texts[1]);
                    int number = Convert.ToInt32(Texts[2]);

                    Order order = new Order()
                    {
                        ProductId = productId,
                        UserId = userId,
                        Quantity = number,
                        Price = price
                    };

                    int result = App.DB.OrderRepository.AddOrder(order);

                    if (result == 1)
                    { 
                        setData();
                        MessageBox.Show("The order was given successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("INCORRECT ENTRY", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            setData();
            timer.Stop();
        }

        private void setData()
        {
            var productList = App.DB.ProductRepository.GetAllData();
            if (productList != null)
                AllProduct = ObservableHelper.ToObservableCollection(productList);

            var orderList = App.DB.OrderRepository.GetAllData();

            List<Order> newOrder = new List<Order>();

            foreach (var order in orderList)
            {
                if (order.User.Username == Usernamee)
                    newOrder.Add(order);
            }

            if (newOrder != null)
                AllOrder = ObservableHelper.ToObservableCollection(newOrder);
        }

        public event PropertyChangedEventHandler ProperChan;
        protected void OnPropChang([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = ProperChan;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            if (SelectProduct != null)
            {
                Texts.Clear();
                Texts.Add(SelectProduct.Code.ToString());
                Texts.Add(SelectProduct.Name);
                Texts.Add("1");
                price = selectProduct.Price;
                Count = SelectProduct.Quantity;
            }
        }
    }
}
