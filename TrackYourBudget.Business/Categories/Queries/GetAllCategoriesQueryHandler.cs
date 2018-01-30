﻿using System.Collections.Generic;
using System.Linq;
using TrackYourBudget.Business.Common;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget.Business.Categories.Queries
{
    public class GetAllCategoriesQueryHandler : IGetAllCategoriesQueryHandler
    {
        private readonly ApplicationContext _context;

        public GetAllCategoriesQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryDto> Get()
        {
            using (_context)
            {
                return _context.Categories
                    .Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList();
            }
        }
    }
}