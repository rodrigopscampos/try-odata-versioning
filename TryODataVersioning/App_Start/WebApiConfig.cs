using Microsoft.OData;
using Microsoft.OData.UriParser;
using Microsoft.Web.Http;
using Microsoft.Web.OData.Builder;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace TryODataVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            ConfigureVersioningByPath(configuration);
        }

        static void ConfigureVersioningByPath(HttpConfiguration configuration)
        {
            configuration.AddApiVersioning();

            configuration
               .Count()
               .Filter()
               .Expand()
               .Select()
               .MaxTop(null);

            var modelBuilder = new VersionedODataModelBuilder(configuration)
            {
                ModelConfigurations =
                {
                    new ProductModelConfiguration()
                }
            };

            var models = modelBuilder.GetEdmModels();

            configuration.MapVersionedODataRoutes("odata", "", models, builder =>
            {
                builder.AddService(ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new CaseInsensitiveODataUriResolver());
            });

            configuration.MapVersionedODataRoutes("odata-bypath", "v{apiVersion}", models, builder =>
            {
                builder.AddService(ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new CaseInsensitiveODataUriResolver());
            });
        }
    }

    public class ProductModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            if (apiVersion == new ApiVersion(1, 0))
            {
                builder.EntitySet<Models.Product>("Products").EntityType.HasKey(p => p.Id);
            }
            else if (apiVersion == new ApiVersion(2, 0))
            {
                builder.EntitySet<Models.Product2>("Products").EntityType.HasKey(p => p.Id);
            }
            else if (apiVersion == new ApiVersion(3, 0))
            {
                builder.EntitySet<Models.Product3>("Products").EntityType.HasKey(p => p.Id);
            }
        }
    }

    public sealed class CaseInsensitiveODataUriResolver : UnqualifiedODataUriResolver
    {
        /// <summary>
        /// Gets or sets whether the URI resolver is case-sensitive.
        /// </summary>
        /// <value>True if the URI resolver is case-sensitive; otherwise, false.</value>
        /// <remarks>This property will always return <c>false</c>.</remarks>
        public override bool EnableCaseInsensitive { get { return true; } set { } }
    }
}
