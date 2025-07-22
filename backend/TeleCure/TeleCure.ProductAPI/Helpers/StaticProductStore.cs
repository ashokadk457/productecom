namespace TeleCure.ProductAPI.Helpers
{
    public static class StaticProductStore
    {
        public static List<Product> Products = new();

        public static int NextId = 1;
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }

}
