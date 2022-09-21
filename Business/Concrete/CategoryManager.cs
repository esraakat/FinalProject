using Business.Abstract;
using Core.Utilities.Results;
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

        public CategoryManager(ICategoryDal categoryDal) //bağımlılığı constructor injection ile minimize ediyorum.
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //business codes
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }
    }
}
//business katmanı veri erişime bağlı, veri erişimi şimdi enityframework ama değişebilir o yüzden bağımlılığı minimize et. 
