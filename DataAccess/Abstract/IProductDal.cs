using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //product'la ilgili veri tabanında yapacağım operasyonları içeren interface
    public interface IProductDal : IEntityRepository<Product> 
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
//code refactoring - kodun iyileştirilmesi