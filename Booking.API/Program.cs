using Booking.API;
using Booking.API.Middleware;
using Booking.Dal.Repositories;
using Booking.Domain.Abstractions.Repositories;
using Booking.Domain.Abstractions.Services;
using Booking.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IDataSource, DataSource>();
builder.Services.AddScoped<IHotelsRepository, HotelRepository>();
builder.Services.AddScoped<IReservationInterface, ReservationService>();//everthing dealing with the db has to be scoped 
builder.Services.AddAutoMapper(typeof(Program));

var cs= builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<Booking.Dal.DataContext>(options => { options.UseSqlServer(cs); }) ;// this is also scoped



//crreates a single instance when first required 
//provides the same instance to all consumers for the entire lifetime

//services.addtransient()
//creates an instance each time that it is required, new instance for new consumers


//services.scoped()
//crreates an instance for each request 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();//middleware for swagger
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection(); //redirect to https

app.UseAuthorization();

//app.UseDateTimeHeader();

app.MapControllers(); //map the request to a controller base class


app.Run();
