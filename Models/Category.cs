using System.Collections.Generic;

namespace _02_asp_net_web_api_02lsc10v.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}