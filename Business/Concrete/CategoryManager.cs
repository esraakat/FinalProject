using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService 
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)//bağımlılığımı constructor injection ile yapıyorum.
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodları
            return _categoryDal.GetAll();
        }

        //select *from Categories where CategoryId = 3

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
//business katmanı veri erişime bağlı, veri erişimi şimdi enityframework ama değişebilir o yüzden bağımlılığı min et. 
