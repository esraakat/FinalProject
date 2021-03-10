using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category :IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
//Çıplak class kalmasın - Bir class herhangi bir inheritance, interface implementasyonu almıyorsa problem vardır. Bu varlıkları işaretleme/gruplama eğilimine gideriz. 
//Concrete klasöründeki classlar bir veritabanı tablosuna karşılık geliyor.
