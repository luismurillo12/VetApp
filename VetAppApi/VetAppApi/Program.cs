using VetAppApi.Controllers;
using VetAppApi.Models;
using VetAppApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom services
builder.Services.AddScoped<AuthModel>();
builder.Services.AddScoped<UserModel>();
builder.Services.AddScoped<PetModel>();
builder.Services.AddScoped<ClientModel>();
builder.Services.AddScoped<ProductModel>();
builder.Services.AddScoped<ServiceModel>();
builder.Services.AddScoped<SupplierModel>();
builder.Services.AddScoped<FormsModel>();
builder.Services.AddScoped<EmailSend>();
builder.Services.AddScoped<AppointmentModel>();
builder.Services.AddScoped<ReportsModel>();
builder.Services.AddScoped<RoleModel>();
builder.Services.AddScoped<PaymentModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
