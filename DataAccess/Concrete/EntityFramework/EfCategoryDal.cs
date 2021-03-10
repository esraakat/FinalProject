using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //biz başkalarının yazdığı paket kodları kullanıcaz kodların ortak koyulduğu ve yönetildiği bir ortam var - nuget
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthWindContext>, ICategoryDal 
    {
        
    }
}
//entity framework - ms'in bir ürünü, bir object, linq destekli çalışır 
//amaç şu veri tabanındaki tabloyu sanki classmış gibi onunla ilişkilendir
