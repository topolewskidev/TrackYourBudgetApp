using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackYourBudget.DataAccess;
using TrackYourBudget.Model.Categories;

namespace TrackYourBudget.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        public CategoriesController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpGet]
        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _applicationContext.Categories.ToList();
            return categories;
        }
    }
}