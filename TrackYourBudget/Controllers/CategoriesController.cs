using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.Business.Categories.Queries;

namespace TrackYourBudget.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IGetAllCategoriesQueryHandler _getAllCategoriesQueryHandler;

        public CategoriesController(IGetAllCategoriesQueryHandler getAllCategoriesQueryHandler)
        {
            _getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _getAllCategoriesQueryHandler.Get();
            return categories;
        }
    }
}