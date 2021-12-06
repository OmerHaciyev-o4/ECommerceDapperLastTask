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

namespace ECommerceDapper.DataAccess
{
    class EFProductRepository : IProductRepository
    {
        public List<Product> GetAllData()
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                string sql = "GetAllProduct";
                try
                {
                    var list = conn.Query<Product>(sql, commandType: CommandType.StoredProcedure).ToList();
                    return list;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public int GetById(string productName)
        {
            List<Product> products = GetAllData();

            foreach (var product in products)
            {
                if (product.Name == productName)
                    return product.Id;
            }

            return 0;
        }

        public int ProductAdd(Product product)
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                string sql = "AddProduct";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Code", product.Code, DbType.Int32);
                parameters.Add("@Name", product.Name, DbType.String);
                parameters.Add("@Quantity", product.Quantity, DbType.Int32);
                parameters.Add("@Price", product.Price, DbType.Double);

                int result = 0;

                try
                {
                    result = conn.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception) { }

                return result;
            }
        }

        public int ProductDelete(int id)
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                int result = 0;

                try
                {
                    string sql = "DeleteProduct";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PId", id, DbType.Int32);

                    result = conn.Execute(sql, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception) { }

                return result;
            }
        }

        public int ProductUpdate(Product product)
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                string sql = "UpdateProduct";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PId", product.Id, DbType.Int32);
                parameters.Add("@PCode", product.Code, DbType.Int32);
                parameters.Add("@PName", product.Name, DbType.String);
                parameters.Add("@PQuantity", product.Quantity, DbType.Int32);
                parameters.Add("@PPrice", product.Price, DbType.Double);

                int result = 0;

                try
                {
                    result = conn.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception) { }

                return result;
            }
        }
    }
}
