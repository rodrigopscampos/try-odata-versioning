using Microsoft.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using TryODataVersioning.Models;

namespace TryODataVersioning.Controllers
{

    [ApiVersion("2.0")]
    [ControllerName("Products")]
    [ODataRoutePrefix("Products")]
    public class ProductsV2Controller : ODataController
    {
        Product2[] _products = new[] 
        {
            new Product2 { Description = "v2", Id = "1" },
            new Product2 { Description = "v2", Id = "2" }
        };

        [ODataRoute]
        public Product2[] Get()
        {
            return _products;
        }
    }
}