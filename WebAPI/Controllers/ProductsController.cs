using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //bu isteği yaparken insanlar bize nasıl ulaşssın? başına api yazsın
    [ApiController] //attribute
    public class ProductsController : ControllerBase
    {
        //naming convention
        //IoC Container - Inversion of Control - Değişimin kontrolü - 
        IProductService _productService; //field'ların defaultu private
        public ProductsController(IProductService productService) //loose coupling - gevşek bağlılık
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Product> Get()
        {
            //dependancy chain
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
//business'daki datayı burada döndürebiliriz.