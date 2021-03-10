using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
//category ile ilgili dış dünyaya neyi servis etmek istiyorsam o operasyonları yazıyrum