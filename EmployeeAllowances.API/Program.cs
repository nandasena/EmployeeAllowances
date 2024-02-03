using EmployeeAllowances.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using EmployeeAllowance.Intrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeIntegetionWorkerProcessor, EmployeeIntegetionWorkerProcessor>();
var assemblies = Assembly.Load("EmployeeAllowances.Application");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assemblies));


//Db Connection 
builder.Services.AddDbContext<EmployeeAllowancesContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"))
    );


//Add Swagger 

builder.Services.AddSwaggerGen(c =>
{
    c.DocInclusionPredicate(
                    (docName, apiDesc) =>
                    {
                        if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo))
                        {
                            return false;
                        }

                        IEnumerable<ApiVersion> versions =
                            methodInfo.DeclaringType
                                .GetCustomAttributes(true)
                                .OfType<ApiVersionAttribute>()
                                .SelectMany(a => a.Versions);

                        return versions.Any(v => $"v{v}" == docName);
                    }
                );

    c.SwaggerDoc(
        "v1.0",
        new OpenApiInfo { Title = "EmployeeAllowances.API", Version = "1.0" }
    );
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

});

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"../swagger/v1.0/swagger.json", "EmployeeAllowances.API");
});




app.UseAuthorization();

app.MapControllers();

app.Run();