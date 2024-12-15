using FarmersOnlyBudget.Api.Extensions;
using FarmersOnlyBudget.Api.Security.Authentication;
using FarmersOnlyBudget.Api.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

FirebaseApp.Create(new AppOptions
{
    Credential = await GoogleCredential.GetApplicationDefaultAsync(),
    ProjectId = builder.Configuration["GoogleProjectId"],
});

builder.Services.AddAuthentication()
    .AddScheme<FirebaseAuthSchemeOptions, FirebaseAuthSchemeHandler>(AuthenticationSchemes.Firebase, options => { });
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();

builder.Services.AddFluentValidation();
builder.Services.AddFarmersOnlyMapster();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BudgetDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration["DbConnectionString"],
        options => options.MigrationsAssembly("FarmersOnlyBudget.Api"));
});

builder.Services.AddTransient<IBudgetService, BudgetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();