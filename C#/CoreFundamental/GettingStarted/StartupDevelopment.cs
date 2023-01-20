namespace GettingStarted
{
    public class StartupDevelopment
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //app.Use(async (httpcontext1,))

            app.UseStatusCodePages();

            app.UseRouting();



            app.Map("/user", (IApplicationBuilder app) =>
            {
                app.Run((httpcontext) => httpcontext.Response.WriteAsync("from Map-middleware"));
            });

            app.Use(async (httpcontext1, httpcontext2) =>
            {
                await httpcontext1.Response.WriteAsync("from Use-MiddleWare" + Environment.NewLine);
                await httpcontext2.Invoke();
            });

            app.Run((httpcontext) => httpcontext.Response.WriteAsync("from run-middleware"));

            app.Run((httpcontext) => httpcontext.Response.WriteAsync("from run-middleware-1"));

            
        }
    }
}

