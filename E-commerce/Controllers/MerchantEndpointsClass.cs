using E_commerce.Models;
namespace E_commerce.Controllers;

public static class MerchantEndpointsClass
{
    public static void MapMerchantEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/merchant", () =>
        {
            return new [] { new Merchant() };
        })
        .WithName("GetAllMerchants");

         
    }
}
