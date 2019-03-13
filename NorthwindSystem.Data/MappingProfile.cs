using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ProductDTOModel = NorthwindSystem.Data.Models.Product;
using ProductDAOEntity = NorthwindSystem.Data.Entities.Product;
using CategoryDTOModel = NorthwindSystem.Data.Models.Category;
using CategoryDAOEntity = NorthwindSystem.Data.Entities.Category;
using SupplierDTOModel = NorthwindSystem.Data.Models.Supplier;
using SupplierDAOEntity = NorthwindSystem.Data.Entities.Supplier;

namespace NorthwindSystem.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDAOEntity, ProductDTOModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(d => d.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName))
                .ReverseMap();
            CreateMap<CategoryDAOEntity, CategoryDTOModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CategoryName))
                .ReverseMap();
            CreateMap<SupplierDAOEntity, SupplierDTOModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.SupplierId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CompanyName))
                .ReverseMap();
        }
    }
}
