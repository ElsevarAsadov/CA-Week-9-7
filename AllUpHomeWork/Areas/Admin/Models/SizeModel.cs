using System.ComponentModel.DataAnnotations;

namespace AllUpHomeWork.Areas.Admin.Models
{
    public class SizeModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 5)]
        public string Size { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
