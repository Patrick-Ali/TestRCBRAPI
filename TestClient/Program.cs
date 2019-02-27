using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace HttpClientSample
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();
        private static readonly string passPhrase = "l%HJb5N^O@fl0K02H9PsxlR9algJTzK7ARBjJsd3fPG0&GwkrU";

        static void ShowProduct(User user)
        {
            //Console.WriteLine($"Name: {product.Name}\tPrice: " +
                //$"{product.Price}\tCategory: {product.Category}");
        }

        static async Task<Uri> CreateProductAsync(User user)
        {
            User crypto = new User();
            crypto.Address = Crypto.Encrypt(user.Address, passPhrase);
            crypto.City = Crypto.Encrypt(user.City, passPhrase);
            crypto.DOB = Crypto.Encrypt(user.DOB, passPhrase);
            crypto.Email = Crypto.Encrypt(user.Email, passPhrase);
            crypto.FirstName = Crypto.Encrypt(user.FirstName, passPhrase);
            crypto.LastName = Crypto.Encrypt(user.LastName, passPhrase);
            crypto.PostCode = Crypto.Encrypt(user.PostCode, passPhrase);
            crypto.Password = Crypto.Encrypt(user.Password, passPhrase);
            crypto.Team = Crypto.Encrypt(user.Team, passPhrase);
            crypto.Posistion = Crypto.Encrypt(user.Posistion, passPhrase);
            crypto.Points = Crypto.Encrypt(user.Points, passPhrase);
            crypto.PhoneNumber = Crypto.Encrypt(user.PhoneNumber, passPhrase);
            crypto.MobilePhoneNumber = Crypto.Encrypt(user.MobilePhoneNumber, passPhrase);

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:44389/api/1.0/user", crypto);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<List<User>> GetProductAsync(string path)
        {
            List<User> product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<User>>();
            }
            return product;
        }

        static async Task<Product> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                //Product product = new Product
                //{
                //Name = "Gizmo",
                //Price = 100,
                //  Category = "Widgets"
                //};

                //var url = await CreateProductAsync(product);
                //Console.WriteLine($"Created at {url}");
                var url = "https://localhost:44389/api/1.0/user";
                // Get the product
                //url.PathAndQuery
                
                 User usering = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DOB = "02/02/2002",
                    Posistion = "Observer",
                    Address = "123 milll lane",
                    PostCode = "CV1 2KS",
                    Email = "john@random.com",
                    PhoneNumber = "123456789",
                    MobilePhoneNumber = "98745612332",
                    Password = "password",
                    City = "coventry",
                    Points = "0",
                    Team = "None"
                };

                var url2 = await CreateProductAsync(usering);
                Console.WriteLine($"Created at {url}");

                List<User> users = await GetProductAsync(url);
                foreach (User user in users)
                {
                    Console.WriteLine(user.FirstName);
                    string test = Crypto.Decrypt(user.FirstName, passPhrase);
                    Console.WriteLine(test);
                }

                //ShowProduct(user);

                // Update the product
                //Console.WriteLine("Updating price...");
                //product.Price = 80;
                //await UpdateProductAsync(product);

                // Get the updated product
                // product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                // Delete the product
                // var statusCode = await DeleteProductAsync(product.Id);
                // Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}