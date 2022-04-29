using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //static newlememek için
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductOfCategoryError = "Bir kategoride maksimum 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten bir ürün var.";
        public static string CategoryLimitExceded = "Kategory limiti aşıldığı için yeni ürün eklenemiyor.";
    }
}
