using MyStore.Application.Services.Products.Commands.AddNewCategory;
using MyStore.Application.Services.Products.Commands.AddNewProduct;
using MyStore.Application.Services.Products.Queries.GetAllCategories;
using MyStore.Application.Services.Products.Queries.GetCategories;
using MyStore.Application.Services.Products.Queries.GetProductDetailForAdmin;
using MyStore.Application.Services.Products.Queries.GetProductForAdmin;
using MyStore.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Interfaces.FacadPattern
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }

        IGetCategoriesService GetCategoriesService { get; }

        AddNewProductService AddNewProductService { get; }

        IGetAllCategoriesService GetAllCategoriesService { get; }

        IGetProductForAdminService GetProductForAdminService { get; }

        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }

        IGetProductForSiteService GetProductForSiteService { get; }
    }
}
