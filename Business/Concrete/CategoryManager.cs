using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal; //bağımlılığı min etmek için

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        //bağımlılığımı constructor injection ile yapıyorum
        public List<Category> GetAll()
        {
            //business codes...
            return _categorydal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            //business codes...
            return _categorydal.Get(c => c.CategoryId == categoryId);
        }
    }
}
//ben categorymanager olarak dataaccess katmanına bağımlıyım ama zayıf bağımlılığım var çünkü interface - referans üzerinden bağımlıyım dataaccess katmanında istediğini yapabilirsin.
//categorinin iş sınıfları