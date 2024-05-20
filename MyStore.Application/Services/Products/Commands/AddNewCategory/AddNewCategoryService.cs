using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Products;

namespace MyStore.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        private Category GetParent(long? parentId)
        {
            return _context.Categories.Find(parentId);
        }

        public ResultDto Execute(long? parentId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمائید"
                };
            }
            Category category = new Category
            {
                Name = name,
                ParentCategory = GetParent(parentId)
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
        }
    }
}
