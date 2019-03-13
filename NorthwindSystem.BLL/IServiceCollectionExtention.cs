using Microsoft.Extensions.DependencyInjection;
using NorthwindSystem.BLL.Implementation;
using NorthwindSystem.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindSystem.BLL
{
    public static class IServiceCollectionExtention
    {
        public static void RegisterBLLServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ILocalConfiguration, Configuration>();
        }
    }
}
