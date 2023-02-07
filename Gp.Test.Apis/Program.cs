
using Gp.Test.Business.Services;
using Gp.Test.Interface.Repositories;
using Gp.Test.Interface.Services;
using Gp.Test.Interface.Validations;
using Gp.Test.Repository;
using Gp.Test.Repository.Config;
using Gp.Test.Repository.Repositories;
using GP.Test.Apis.Validations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestContext>(test => test.UseInMemoryDatabase(databaseName: "Test"));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(typeof(ITestValidation), typeof(TestValidation));
builder.Services.AddTransient(typeof(ITestRepository), typeof(TestRepository));
builder.Services.AddTransient(typeof(ITestService), typeof(TestService));

var app = builder.Build();
var dataTest = System.IO.File.ReadAllText(@"Test.json");
ConfigDomain.ConfigurationDomain(app.Services, dataTest);
IWebHostEnvironment environment = app.Environment;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();