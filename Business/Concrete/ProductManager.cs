using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
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

        public IResult Add(Product product)
        {

            if (product.ProductName.Length > 2)
            {
                return new ErrorResult (Messages.ProductNameInvalid); //magic string
            }

            _productDal1.Add(product);
            return new SuccessResult(Messages.ProductAdded); //bunu yapabilmnein yöntemi bir tane constructor eklemektir.
        }
        //mesaj vermek de istemeyebilirisn.

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları, ifler...
            //yetkisi var mı, varsa alltaki komutlar devreye girebilir.
            //InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal(); /Eğer böyle yazarsam iş kodlarının tamamı bellekle çalışır. Gerçek veritabanına geçeceğim zaman operasyonların hepsini veri erişimini değiştirdiğim zaman değiştirmem gerekir.

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal1.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)  //filtrelenmiş ürün listesi
        {
            return new SuccessDataResult<List<Product>>(_productDal1.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal1.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal1.GetProductDetails());
        }

        public IDataResult<Product> GetProductId(int productId)
        {
            return new SuccessDataResult<Product>(_productDal1.Get(p => p.ProductId == productId));
        }
    }
}
//Kural: Bir business classı başka classları newlemez.
//Business da asla inmemory, entityframework hiçbir şey yok, business'ın bildiği tek şey IProductdal ve bu her şey olabilir.