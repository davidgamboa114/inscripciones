using Inscripciones.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuracion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string cadenaConexion = configuracion.GetConnectionString("mysqlremoto");
builder.Services.AddDbContext<InscripcionesContext>(options => options.UseMySql(cadenaConexion,
            ServerVersion.AutoDetect(cadenaConexion),
                                options => options.EnableRetryOnFailure(
                                        maxRetryCount: 5,
                                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                                       errorNumbersToAdd: null)
            ));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
});

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
