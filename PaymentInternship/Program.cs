using Microsoft.EntityFrameworkCore;
using PaymentInternship.Data;
using PaymentInternship.Models;
using PaymentInternship.Controllers;
using PaymentInternship.HubConfig;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ContextPayment>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddHttpClient<PostHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7046/api/");
});

//Enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

//added
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.MapGet("merchentId", async (PostHttpClient postHttpClient) => {
    return await postHttpClient.AllPosts();
});
app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

//added
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<MyHub>("/toastr");
});



app.UseAuthorization();

app.MapControllers();



app.MapResponseEndpoints();

app.MapMerchantDetailsEndpoints();

app.MapGenerateTransactionIdEndpoints();


app.Run();
