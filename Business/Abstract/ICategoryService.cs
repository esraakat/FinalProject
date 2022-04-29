using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService //Category ile ilgili dış dünyaya ne servis etmek istiyorsan o operasyonları yaz.
    {
        IDataResult<List<Category>> GetAll(); 
        IDataResult<Category> GetById(int categoryId);
    }
}
 