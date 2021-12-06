using ECommerceDapper.DataAccess;
using ECommerceDapper.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceDapper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;

        public App()
        {
            using (var context = new MyContext())
            {
                try
                {
                    context.Database.CreateIfNotExists();
                }
                catch (Exception)
                {
                }

            }
            DB = new EFUnitOfWork();
        }
    }
}
