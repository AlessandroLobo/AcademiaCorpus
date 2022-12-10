using AcademiaCorpus.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adicionando serviço de conexão com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options => options
               .UseSqlServer(builder.Configuration
               .GetConnectionString("DefaultConnection")));

//Adicionando serviço do Microsoft.AspNetCore.Identity.EntityFrameworkCore
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
       .AddEntityFrameworkStores<AppDbContext>()
       .AddDefaultTokenProviders();

// Relacionado ao cash
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();


//Habilitando o cash
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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

//Habilitando cash
app.UseSession();

// Configura Identity para gerenciar loguin
app.UseAuthentication();
//Função do DbContext
app.UseAuthorization();





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Aluno}/{action=Index}/{id?}"
         );


});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
