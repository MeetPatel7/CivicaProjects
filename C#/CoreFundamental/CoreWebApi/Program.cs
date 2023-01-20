var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints((x) =>
{
    x.MapControllerRoute(name: "default",
        pattern: "{controller=Home}/{action=AboutUs}/{id?}");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
