using System.Collections.Generic;

namespace TrackYourBudget.Business.Categories.Queries
{
    public interface IGetAllCategoriesQueryHandler
    {
        IEnumerable<CategoryDto> Get();
    }
}