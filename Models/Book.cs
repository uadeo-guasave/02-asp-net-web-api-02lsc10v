namespace _02_asp_net_web_api_02lsc10v.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string AmazonId { get; set; }
        public string Filename { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}