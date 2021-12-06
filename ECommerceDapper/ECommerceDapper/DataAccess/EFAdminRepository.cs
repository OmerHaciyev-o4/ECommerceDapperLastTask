using Dapper;
using ECommerceDapper.Domain.Abstractions;
using ECommerceDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ECommerceDapper.DataAccess
{
    public class EFAdminRepository : IAdminRepository
    {
        public List<Admin> GetAllData()
        {
            ICollection<Admin> admins;
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                string sql = "select * from Admins";
                admins = conn.Query<Admin>(sql).ToList();
                return admins as List<Admin>;
            }
        }

        public int GetById(string username)
        {
            List<Admin> admins = GetAllData();

            foreach (var admin in admins)
            {
                if (admin.Username == username)
                    return admin.Id;
            }
            return 0;
        }

        public int AddAdmin(Admin admin)
        {
            using (var conn = new SqlConnection(ConnectionStrings["ConnStr"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", admin.Username, DbType.String);
                parameters.Add("@Pass", admin.Password, DbType.String);
                int result = 0;
                try
                {
                    result = conn.Execute("AddAdmin", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception) { }

                return result;
            }
        }
    }
}
