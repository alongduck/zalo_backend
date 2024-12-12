namespace zalo_server.SkyModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public decimal Price { get; set; }
        public string TimeUp { get; set; }
        public int DetailId { get; set; }
        public int CategoryId { get; set; }
        public bool Hot { get; set; }
        public int UserId { get; set; }

          // Navigation property to Detail
        public Detail Detail { get; set; }
    }
}
