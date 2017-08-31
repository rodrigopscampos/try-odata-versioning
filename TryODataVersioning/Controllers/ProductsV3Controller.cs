using Microsoft.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using TryODataVersioning.Models;

namespace TryODataVersioning.Controllers
{

    [ApiVersion("3.0")]
    [ControllerName("Products")]
    [ODataRoutePrefix("Products")]
    public class ProductsV3Controller : ODataController
    {
        Product3[] _products = new[]
        {
            new Product3 { Description = "v3", Id = true },
            new Product3 { Description = "v3", Id = false }
        };

        [ODataRoute]
        public Product3[] Get()
        {
            return _products;
        }
    }

}