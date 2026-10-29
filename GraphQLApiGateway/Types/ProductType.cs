namespace GraphQLApiGateway.Types
{

    // that one is type schema that user know what the data that they have 
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int CategoryId { get; set; } 
    }

    public class ProductListResponse
    {
        public ProductType Product { get; set; }
        public CategoryType Category { get; set; }
        public InventoryType Inventory { get; set; }
        public IEnumerable<ReviewType> Reviews { get; set; }
    }

}
