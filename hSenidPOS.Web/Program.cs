using hSenidPOS.BLL.IManager;
using hSenidPOS.BLL.Manager;
using hSenidPOS.DAL.Data;
using hSenidPOS.DAL.IRepository;
using hSenidPOS.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IDummyManager, DummyManager>();
builder.Services.AddScoped<IDummyRepository, DummyRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
