using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context : db tabloları ile proje classlarını bağlamak, ilişkilendirmek
    public class NorthWindContext : DbContext  //entityframework kurduğumda onunla birlikte base bir sınıf geliyor.
    {
        //veri tabanım tam olarak şurada demem gerek.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //projem hangi veri tabanıyle ilişkili
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = Northwind; Trusted_Connection = true"); //sqlserver kullanıcaz, sql servere nasıl bağlanıcağımı belirtmem yeterli 
            //Trusted_Connection = true - kullanıcı adı ve şifre gerekmez demektir.
            //projeyi çalıştırdğımda entity framework hemen burya bakar ben nereye bağlanıcam diye
        }

        //veritabanının ne olduğunu söyledim ama hangi nesnem hangi nesneye karşılık gelecek  
        public DbSet<Product> Products { get; set; } //products nesnemi veri tabanındaki product ile bağla demektir
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Orders { get; set; }
        //artık customer, category ... için kodlarımızı yazabiliriz
    }
}