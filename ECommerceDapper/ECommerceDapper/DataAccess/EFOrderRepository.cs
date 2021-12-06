using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDapper.Domain.Abstractions;
using ECommerceDapper.Domain.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Collections.ObjectModel;

namespace ECommerceDapper.DataAccess
{
    public class EFOrderRepository : IOrderRepository
    {
        public int AddOrder(Order order)
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                int result = 0;
                string insert = " insert into Orders([ProductId], [UserId], [Date], [Quantity], [Price]) " +
                                                        " values(@PProductId, @UUserId, @DDate, @QQuantity, @PPrice)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PProductId", order.ProductId, DbType.Int32);
                parameters.Add("@UUserId", order.UserId, DbType.Int32);
                parameters.Add("@DDate", DateTime.Now, DbType.DateTime2);
                parameters.Add("@QQuantity", order.Quantity, DbType.Int32);
                parameters.Add("@PPrice", order.Quantity * order.Price, DbType.Double);

                try
                {
                    conn.Execute(insert, parameters);

                    result = 1;
                }
                catch (Exception) { }

                return result;
            }
        }

        public List<Order> GetAllData()
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                string sql = "select O.*, P.*, U.* " +
                    " from Orders as O  " +
                    " inner join Products as P  " +
                    " on O.ProductId = P.Id  " +
                    " inner join Users as U  " +
                    " on O.UserId = U.[Id] ";
                try
                {
                    var list = conn.Query<Order, Product, User, Order>(sql,
                        (order, product, user) =>
                        {
                            Order newOrder = new Order()
                            {
                                Id = order.Id,
                                ProductId = product.Id,
                                UserId = user.Id,
                                Date = order.Date,
                                Quantity = order.Quantity,
                                Price = order.Price,
                                Product = product,
                                User = user
                            };
                            return newOrder;
                            
                        }).ToList();                  

                    return list;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public int GetById(string data)
        {
            throw new NotImplementedException();
        }
    }
}
