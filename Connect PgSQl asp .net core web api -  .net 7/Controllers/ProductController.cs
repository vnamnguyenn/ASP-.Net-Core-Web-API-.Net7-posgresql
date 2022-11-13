using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Connect_PgSQl_asp_.net_core_web_api____.net_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ProductController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            var products = await connection.QueryAsync<Product>("select * from product");
            return Ok(products);
        }
    }
}