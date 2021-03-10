using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
     
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//veritabanı
        public InMemoryProductDal()
        {
            //oracle,sqlserver,postgres,mongodb den geliyormuş gibi simüle ediyoruz.
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 2, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product { ProductId = 2, CategoryId = 2, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Mouse", UnitPrice = 85, UnitsInStock = 1},
            };

        }
        public void Add(Product product)
        {
            _products.Add(product); //Businessdan bana gönderilen ürünü alıp veritabanına ekliyorum
        }

        public void Delete(Product product)
        {
            // _products.Remove(product); Bunu listeden bu şekilde asla silemezsin,çalışmaz. List<int> olsaydı silebilirdin
            
            //Product productToDelete = null; //linq yöntemini kullanmadan

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId) //id'leri karşılaştırıcaz, eşleşen var mı yok mu
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            //linq ne işe yarıyor? Linq c#'ı diğer dillerden daha güçlü hale getiren kullanımlardan biri. Language ıntegrated query - dile gömülü sorgulama. Linq ile liste bazlı yapıları sql gibi filtrelebiliriz.
            
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); //tek bir eleman bulmaya yarar. Bizim yerinize products'ı tek tek dolaşmaya yarar.
            _products.Remove(productToDelete);
            //lambda p-tek tek dolaşırken verdğimiz takma isim
            //her p için p'nin productıd'si benim gönderdiğim product'ın productıd'sine eşit mi?
            //genelde ıd aradığımızda kullanırız
            //SingleOrDefault yerine firstordefault veya first de kullanabilirdik.
            //singleordefault forecah görevini yapar.
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()//veritabanındaki datayı businessa gönderiyorum
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();  //sqldeki where gibi where koşulu içindeki şarta uyan tüm elemanları yeni bir liste haline getirir ve onu döndürür.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //Gönderdiğim ürünün ıd'sine sahip olan listediki ürünü bul demektir.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
