using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.Business.Categories.Queries;

namespace TrackYourBudget.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IGetAllCategoriesQuery _getAllCategoriesQuery;

        public CategoriesController(IGetAllCategoriesQuery getAllCategoriesQuery)
        {
            _getAllCategoriesQuery = getAllCategoriesQuery;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _getAllCategoriesQuery.Get();
            return categories;
        }
    }
}