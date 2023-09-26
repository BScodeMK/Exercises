using Ogani.Data.Entities;

namespace Ogani.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public List<Product>? Products { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
