using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using primetechmvc.DbContexts;
using primetechmvc.IRepository;
using primetechmvc.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);

builder.Services.AddSwaggerGen();

AddAuthenticationServiceJwt(builder);

// Dependency Inject
builder.Services.AddTransient<IUser, UserService>();
builder.Services.AddTransient<IStudent, StudentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();


app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();


static void AddAuthenticationServiceJwt(WebApplicationBuilder builder)
{
    var auth = builder.Configuration.GetSection("Auth");
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(auth["Secret"]))
        };
    });
}