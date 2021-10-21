using Applicattion.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kata.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new List.Query());

            return HandleResult(result);
        }
    }
}
