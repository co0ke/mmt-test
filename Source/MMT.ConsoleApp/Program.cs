namespace MMT.ConsoleApp
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            var categoryResult = await HttpClient.GetStringAsync("http://localhost:6014/categories");
            Console.WriteLine("Get categories... {0}", categoryResult);
            Console.WriteLine();

            var featuredProductsResult = await HttpClient.GetStringAsync("http://localhost:6014/products/featured");
            Console.WriteLine("Get featured products... {0}:", featuredProductsResult);
            Console.WriteLine();

            var categoryId = args.FirstOrDefault() ?? "2";
            var productsByCategoryResult = await HttpClient.GetStringAsync($"http://localhost:6014/products/category/{categoryId}");
            Console.WriteLine("Get products with category ID {0}... {1}:", categoryId, productsByCategoryResult);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
