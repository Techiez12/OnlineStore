namespace Ostore.API.Models.InputModels
{
    public class ProductInputModel
    {
        public int? Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int SubcategoryId { get; set; }
    }
}
