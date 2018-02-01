using System.Collections.Generic;

namespace TrackYourBudget.Business.Categories.Queries
{
    public interface IGetAllCategoriesQuery
    {
        IEnumerable<CategoryDto> Get();
    }
}