using Loyality.DbContextApplication;
using Loyality.IRepository;
using Loyality.IRepository.Repository;
using Loyality.IService;
using Loyality.IService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

//builder.Services.AddScoped(IRider, RiderRepository);
builder.Services.AddTransient<IRider, RiderRepository>();


builder.Services.AddTransient<IRiderService, RiderService>();

//builder.Services.AddScoped(IRiderService, RiderService);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), sqlServerOptions => sqlServerOptions.CommandTimeout(120));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<pointInterface, RepositoryRider>();
var app = builder.Build();

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
