using BankApplication.Core.Domain;
using BankApplication.Src.Application.Accounts;
using BankApplication.Src.Application.Customers;
using BankApplication.Src.Application.Movements;
using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Contracts.Movements;
using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Customers;
using BankApplication.Src.Domain.Movements;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BankApplicationDbContext>(opt =>
{
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("BankApplicationDb"),
        builder => builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null)
    );
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddScoped<IAccountAppService, AccountAppService>();

builder.Services.AddScoped<IMovementRepository, MovementRepository>();
builder.Services.AddScoped<IMovementManager, MovementManager>();
builder.Services.AddScoped<IMovementAppService, MovementAppService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
