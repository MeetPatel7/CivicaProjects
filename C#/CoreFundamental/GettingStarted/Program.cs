
//namespace GettingStarted
//{
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        IHostBuilder hostBuilder = CreateHostBuilder(args);
//        IHost host = hostBuilder.Build();

//        host.Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args)
//    {
//        return Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(x =>
//            {
//                x.UseStartup<StartupDevelopment>();
//            });
//    }
//}


//}

var builder = WebApplication.CreateBuilder(args);
var app=builder.Build();
var section = app.Configuration.GetSection("Positon");
app.MapGet("/", () => section["-Title"]);
app.Run();