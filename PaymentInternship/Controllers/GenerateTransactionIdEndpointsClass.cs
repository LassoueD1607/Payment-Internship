using PaymentInternship.Models;
namespace PaymentInternship.Controllers;

public static class GenerateTransactionIdEndpointsClass
{
    public static void MapGenerateTransactionIdEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/GenerateTransactionId", () =>
        {
            return new[] { new GenerateTransactionId() };
        })
        .WithName("GetAllGenerateTransactionIds");


    }
}
