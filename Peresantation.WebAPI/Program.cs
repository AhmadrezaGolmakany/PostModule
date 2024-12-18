using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Peresantation.WebAPI.Utility;
using PostModule.Domain.Services;
using PostModule.Infrastracture.EF;
using PostModule.Infrastracture.EF.Repositpries;
using PostModule.Query;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var configuration = builder.Configuration;
var local = configuration.GetConnectionString("Post");
Post_Bootstrapper.Confiq(services,local);

services.AddControllers();


#region Swagger
services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerPostDocument>();
services.AddSwaggerGen();


#endregion

#region Versioning

services.AddApiVersioning(option =>
{
    option.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.ReportApiVersions = true;
    option.ReportApiVersions = true;
    //option.ApiVersionReader = new HeaderApiVersionReader("X-ApiVersion");

});


services.AddVersionedApiExplorer(x =>
{
    x.GroupNameFormat = "'v'VVVV";
});

#endregion
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        var provider = app.Services.CreateScope().ServiceProvider
                .GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var item in provider.ApiVersionDescriptions)
        {
            x.SwaggerEndpoint($"swagger/{item.GroupName}/swagger.json", item.GroupName.ToString());

        }
        //x.SwaggerEndpoint("/swagger/VilaOpenApi/swagger.json" , "Vila");
        x.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
