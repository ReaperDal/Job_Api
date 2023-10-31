using Job_Api.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Job_Api.Helpers;

public static class ODataConfiguration
{
    public static IEdmModel GetEdmModel()
    {
        var edmBuilder = new ODataConventionModelBuilder();
        edmBuilder.EntitySet<Job>("ODataJobs");
        return edmBuilder.GetEdmModel();
    }
}
