using System.ComponentModel.DataAnnotations;

namespace TrackYourBudget.Model.Categories
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
