using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//Birisi senden IProductService isterse ona ProductManager ver.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();//çalışan uygulama içerisine

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //implemente edilmiş interfaceleri  bul
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() //onlar için bu methodu çağır, bütün classlar için ilk önce bu çalışır, git bak aspect var mı?
                }).SingleInstance();
        }
    }
}
