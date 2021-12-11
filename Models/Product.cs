namespace ProductModel
{
    public class Product // Create Model to use in _ProductItem.cshtml
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}