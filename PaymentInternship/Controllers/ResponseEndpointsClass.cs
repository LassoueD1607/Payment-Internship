using PaymentInternship.Models;
namespace PaymentInternship.Controllers;

public static class ResponseEndpointsClass
{
    public static void MapResponseEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Response", () =>
        {
            return new [] { LoginController.responseMessage };
        })
        .WithName("GetAllResponses");

        
    }
}
