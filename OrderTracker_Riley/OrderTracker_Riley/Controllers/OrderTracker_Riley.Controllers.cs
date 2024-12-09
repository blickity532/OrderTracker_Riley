using Microsoft.AspNetCore.Mvc;

namespace OrderTracker_Riley.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController(ILogger<OrderTrackerController> logger) : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Order Placed", "Processing", "Shipped", "Out for Delivery", "Delivered", "Returned", "Cancelled", "Refunded", "Pending", "Completed"
        ];

        [HttpGet(Name = "Customer")]
        public IEnumerable<Customer> Get()
        {
            return GenerateSampleCustomers();
        }

        private static IEnumerable<Customer> GenerateSampleCustomers() => Enumerable.Range(1, 5).Select(index =>
                                                                                       new Customer($"Customer {index}", Summaries[index % Summaries.Length])
            ).ToArray();
    }

    public record Customer(string Name, string Details);

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new();

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return product;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new
            {
                id = product.Id
            }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            Products.Remove(product);
            return NoContent();
        }
    }

    public class Product
    {
        public int Id
        {
            get; set;
        }
        public required string Name
        {
            get; set;
        }
        public required decimal Price
        {
            get; set;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class WomensClothingController : ControllerBase
    {
        private static readonly List<WomensClothing> WomensClothingItems = new();

        [HttpGet]
        public IEnumerable<WomensClothing> GetWomensClothingItems()
        {
            return WomensClothingItems;
        }

        [HttpGet("{id}")]
        public ActionResult<WomensClothing> GetWomensClothingItemById(int id)
        {
            var item = WomensClothingItems.FirstOrDefault(p => p.Id == id);
            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public IActionResult CreateWomensClothingItem([FromBody] WomensClothing item)
        {
            item.Id = WomensClothingItems.Count + 1;
            WomensClothingItems.Add(item);
            return CreatedAtAction(nameof(GetWomensClothingItemById), new
            {
                id = item.Id
            }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWomensClothingItem(int id, [FromBody] WomensClothing updatedItem)
        {
            var item = WomensClothingItems.FirstOrDefault(p => p.Id == id);
            if (item == null)
                return NotFound();

            item.Name = updatedItem.Name;
            item.Size = updatedItem.Size;
            item.Price = updatedItem.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWomensClothingItem(int id)
        {
            var item = WomensClothingItems.FirstOrDefault(p => p.Id == id);
            if (item == null)
                return NotFound();

            WomensClothingItems.Remove(item);
            return NoContent();
        }
    }

    public class WomensClothing
    {
        public int Id
        {
            get; set;
        }
        public required string Name
        {
            get; set;
        }
        public required string Size
        {
            get; set;
        }
        public required decimal Price
        {
            get; set;
        }
    }
}
