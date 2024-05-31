// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AgriEnergyContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=FarmersmarketDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")));

    services.AddIdentity<IdentityUser, IdentityRole>()
       .AddEntityFrameworkStores<AgriEnergyContext>()
       .AddDefaultTokenProviders();

    services.AddControllersWithViews();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}