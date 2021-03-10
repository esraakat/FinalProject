using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal1; //injection yaptık yani soyut nesneyle bağlantı kurduk.
        public ProductManager(IProductDal productDal1) //injection - ctor
        {
            _productDal1 = productDal1;
        }


        public List<Product> GetAll()
        {
            //iş kodları, ifler...
            //yetkisi var mı, varsa alltaki komutlar devreye girebilir.
            //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal(); /Eğer böyle yazarsam iş kodlarının tamamı bellekle çalışır. Gerçek veritabanına geçeceğim zaman operasyonların hepsini veri erişimini değiştirdiğim zaman değiştirmem gerekir.
            return _productDal1.GetAll();
        }

        public List<Product> GetAllByCategoryId(int Id)  //filtrelenmiş ürün listesi
        {
            return _productDal1.GetAll(p => p.CategoryId == Id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal1.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal1.GetProductDetails();
        }
    }
}
//Kural: Bir business classı başka classları newlemez.
//Business da asla inmemory, entityframework hiçbir şey yok, business'ın bildiği tek şey IProductdal ve bu her şey olabilir.