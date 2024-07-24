using Asp.Versioning;
using Asp.Versioning.Builder;
using Ats.Api.Extensions;
using Ats.Core;
using Ats.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Environment.IsProduction(), builder.Configuration);
builder.Services.AddCore();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Ats API", Version = "v1" });
	c.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblies(typeof(Program).Assembly);

builder.Services.AddEndpoints(typeof(Program).Assembly);

builder.Services.AddApiVersioning(options =>
{
	options.DefaultApiVersion = new ApiVersion(1);
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(),
		new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
	options.GroupNameFormat = "'v'V";
	options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Ats API"));
}

app.UseHttpsRedirection();

ApiVersionSet apiVersionSet = app.NewApiVersionSet()
	.HasApiVersion(new ApiVersion(1))
	.ReportApiVersions()
	.Build();

RouteGroupBuilder versionedGroup = app
	.MapGroup("api/v{version:apiVersion}")
	.WithApiVersionSet(apiVersionSet);


app.MapEndpoints(versionedGroup);
app.AddInfrastructure(builder.Environment.IsProduction());

app.Run();

//for tests
public partial class Program { }