using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataWebApiExample.Data;
using ODataWebApiExample.Models;
using System.Linq;

namespace ODataWebApiExample.Controllers
{
    [Route("odata/[controller]")]
    public class ProductsController : ODataController
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Product> Get() => _context.Products;

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == key);
            if (product == null) return NotFound();
            return Ok(product);
        }

        public IActionResult Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created(product);
        }

        public IActionResult Put(int key, [FromBody] Product update)
        {
            var product = _context.Products.Find(key);
            if (product == null) return NotFound();
            product.Name = update.Name;
            product.Price = update.Price;
            product.CategoryId = update.CategoryId;
            _context.SaveChanges();
            return Updated(product);
        }

        public IActionResult Delete(int key)
        {
            var product = _context.Products.Find(key);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
