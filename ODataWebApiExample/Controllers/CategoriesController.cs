using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataWebApiExample.Data;
using ODataWebApiExample.Models;
using System.Linq;

namespace ODataWebApiExample.Controllers
{
    [Route("odata/[controller]")]
    public class CategoriesController : ODataController
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Category> Get() => _context.Categories;

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == key);
            if (category == null) return NotFound();
            return Ok(category);
        }
    }
}
