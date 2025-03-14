var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".myapp";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   // app.UseHsts();
}


app.UseHttpsRedirection();
app.UseRouting();
//app.UseAuthorization();

app.MapStaticAssets();


// convensional based routing
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Create}/{id?}")
   .WithStaticAssets();

//app.MapControllerRoute(
//    name: "contact",
//    pattern: "home/contact-us",
//    defaults: new { controller = "Home", action = "Contact" }
//);

//.WithStaticAssets();


app.Run();
