using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

//
namespace Core.DataAccess 
{
    //T bir referans tip olmak zorunda - int'leri engelleriz. 
    //class olabilir demek değildir referans tip olabilir demektir
    //T ya IEntity ya da IEntity'den implemente eden bir nesne olabilir.
    //new() : newlenebilir olmalı - IEntiy interface olduğu için newlenemez. Ben IEntity kullanmak istemiyorsam 
    //sistemimiz gerçekten veritabanı nesneleriyle çalışan bir repository oldu.
    public interface IEntityRepository<T> where T: class,IEntity,new()  //T'yi sınırlandırmak istiyorum - generic constraint - generic kısıt
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filtre için yazdığım kod, lambda gibi bir şey atmamızı sağlayan yapı
        T Get(Expression<Func<T, bool>> filter); //tek bir data getirmek için, sistemde bir şeyin detayına gitmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
