using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("C:\\Users\\DavidVareba\\OneDrive - FreightWise, LLC\\Desktop\\BackEnd\\TheVadanaProperties\\VadanaProperties\\VadanaProperties\\vadanaproperties-firebase-adminsdk-dgv1e-bed8e42209.json"),
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.Authority = "https://securetoken.google.com/vadanaproperties";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://securetoken.google.com/vadanaproperties",
        ValidateAudience = true,
        ValidAudience = "vadanaproperties",
        ValidateLifetime = true,
    };
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();