using Microsoft.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using TryODataVersioning.Models;

namespace TryODataVersioning.Controllers
{
    [ApiVersion("1.0")]
    [ControllerName("Products")]
    [ODataRoutePrefix("Products")]
    public class ProductsV1Controller : ODataController
    {
        Product[] _products = new[] 
        {
            new Product { Description = "v1" },
            new Product { Description = "v1" }
        };

        [ODataRoute]
        public Product[] Get()
        {
            return _products;
        }
    }
}