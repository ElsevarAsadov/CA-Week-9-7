namespace AllUpHomeWork.Areas.Admin.Models
{
    public class ColorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
