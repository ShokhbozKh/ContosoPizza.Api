using ContosoPizza.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PizzaDbContext _context;
        public CustomersController(PizzaDbContext pizzaDbContext)
        {
            _context = pizzaDbContext ?? throw new ArgumentNullException(nameof(pizzaDbContext));
        }
        // GET: api/customers
       /* [HttpGet]

        //GET: api/customers/{id}
        [HttpGet("{id}")]

        // POST: api/customers
        [HttpPost]

        // PUT: api/customers/{id}
        [HttpPut("{id}")]

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
       */
        

    }
}
