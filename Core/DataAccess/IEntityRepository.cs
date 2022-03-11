using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess 
{
    //class demek referans tip olabilir demek
    //T ya IEntity olabilir ya da IEntity implemente eden bir nesne olabilir.
    //new() - T newlenebbilir olmalı demek
    public interface IEntityRepository<T> where T: class, IEntity, new() //generic constraint - generic kısıt
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filter = null filtre vermeyebilirsin demek yani filtre yoksa tüm datayı getir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
