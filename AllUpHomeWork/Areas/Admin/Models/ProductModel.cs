using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllUpHomeWork.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, 1)]
        public float SaleFraction { get; set; }

        public List<ColorModel>? Colors { get; set; }
        public List<SizeModel>? Sizes { get; set; }


        [NotMapped]
        public List<int> ColorIds { get; set; }

        [NotMapped]
        public List<int> SizeIds { get; set; }

    }
}
