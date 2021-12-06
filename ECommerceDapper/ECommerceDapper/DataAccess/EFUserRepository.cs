using Dapper;
using ECommerceDapper.Domain.Abstractions;
using ECommerceDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.DataAccess
{
    class EFUserRepository : IUserRepository
    {
        public List<User> GetAllData()
        {
            ICollection<User> users;
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                string sql = "select * from Users";
                users = conn.Query<User>(sql).ToList();
                return users as List<User>;
            }
        }

        public int GetById(string username)
        {
            List<User> users = GetAllData();

            foreach (var user in users)
            {
                if (user.Username == username)
                    return user.Id;
            }
            return 0;
        }

        public int AddUser(User user)
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", user.Username, DbType.String);
                parameters.Add("@Pass", user.Password, DbType.String);

                int result = 0;
                try
                {
                    result = conn.Execute("AddUser", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception) { }

                return result;
            }
        }

        public bool GetData(User user)
        {
            throw new NotImplementedException();
        }
    }
}
