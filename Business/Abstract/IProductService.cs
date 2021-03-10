using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService 
    {
        List<Product> GetAll(); //tüm ürünleri listeleyecek ortam
        List<Product> GetAllByCategoryId(int Id);
        List<Product> GetByUnitPrice(decimal min, decimal max); //şu fiyat aralığındaki ürünleri getir.
        List<ProductDetailDto> GetProductDetails();
    } 
}
