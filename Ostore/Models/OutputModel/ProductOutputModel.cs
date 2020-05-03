namespace Ostore.API.Models.OutputModels
{
    public class ProductOutputModel : ProductInfoOutputModel
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; }
        public string Subcategory { get; set; }
    }
}
