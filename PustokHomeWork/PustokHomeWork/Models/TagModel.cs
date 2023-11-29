namespace PustokHomeWork.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
