using ApiProdutos.Domain;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.CrossCutting.IoC;
using ApiProdutos.Infra.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();


#region IoC Configuration
builder.Services.AddDistribuidoraDatabase();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();


builder.Services.AddDistribuidoraCors();
#endregion



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DistribuidoraContext>();
    Seed.Initilize(dbContext);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        // Point SwaggerUI to the default OpenAPI JSON endpoint
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();

//app.UseAuthorization();



app.MapControllers();

app.UseCors("appprodutos_angular");

app.UseRouting();
app.Run();
