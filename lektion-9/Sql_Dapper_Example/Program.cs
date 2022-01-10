using Sql_Dapper_Example.Services;

ICategoryService categoryService = new CategoryService();
IProductService productService = new ProductService();

categoryService.Create("TV");
productService.Create("LG tv 49 tum", "Detta är en tv med bästa kvalitet", 13000, categoryService.GetByName("TV").Id);

foreach (var product in productService.GetAll())
{
    Console.WriteLine($"{product.Id} - {product.Name} (Pris: {product.Price}:-)");
    Console.WriteLine($"{product.Description}");
    Console.WriteLine($"Kategori: {product.Category}");
    Console.WriteLine("");
}