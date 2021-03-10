using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //entity framework kullanarak bir repository base oluştur demek
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()  //bu bir db tablosu olacak, bu bir referans tip olacak
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);  //ben bunu db ile ilişkilendirdim, referansı yakalama
                addedEntity.State = EntityState.Added; // onun aslında eklenecek bir nesne olduğunu söyledim
                context.SaveChanges(); //şimdi ekle 
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);  //önce tabloya bağlanıyorum. Bu filtreyi oraya uygula demektir.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) 
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //tabloya yerleş ve oradaki tüm datayı listele - yani select *from table    
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
//using - Idisposable pattern implementaion of c# 
//bu şeklilde yazınca daha performanslı bir ürün geliştirmiş oluyorsun
//c#'a özel yapı, using içerisine yazdığımız nesneler using'in işi bitince garbage collektor'e geliyor, beni bellekten at diyor çünkü context nesnesi biraz pahalı