var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseEndpoints((x) =>
{
    x.MapControllers();
    //x.MapControllerRoute(name: "default",
    //    pattern: "{controller=Employee}/{action=AboutUs}/{id?}");
});

app.Run();
