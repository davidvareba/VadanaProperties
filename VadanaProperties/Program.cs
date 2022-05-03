using VadanaProperties.Repositories;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                       policy =>
                       {
                           policy.WithOrigins("https://local.host:7045", "https://local.host:3000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                       });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRealtorsRepository, RealtorsRepository>();
builder.Services.AddTransient<IListingsRepository, ListingsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors( builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });

app.UseAuthorization();

app.MapControllers();

app.Run();