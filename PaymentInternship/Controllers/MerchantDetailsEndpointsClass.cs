using PaymentInternship.Models;
namespace PaymentInternship.Controllers;

public static class MerchantDetailsEndpointsClass
{
    public static MerchantDetails merchantDetails = new MerchantDetails();
    public static void MapMerchantDetailsEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/MerchantDetails", () =>
        {
            return merchantDetails;
        })
        .WithName("GetAllMerchantDetailss");

         
    }
}
