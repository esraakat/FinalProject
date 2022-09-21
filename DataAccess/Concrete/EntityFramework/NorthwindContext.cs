using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //projen hangi db ile ilişkili
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=Northwind;Trusted_Connection=true"); //sqlserver'ın nerede olduğunu anlatır
        }

        //Hangi veri tabanına bağlanacağımızı belirledik. Şimdi de hangi clas hangi tabloya karşılık gelecek onu belirle

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
