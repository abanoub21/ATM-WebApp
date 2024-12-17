using ATMApplication.Application.Contract;
using ATMApplication.Application.Services;
using ATMApplication.Infrastracture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ATMContext>();
builder.Services.AddTransient(typeof(IAsyncRepsoitory<>), typeof(AsyncRepository<>));
builder.Services.AddScoped<IAccountAppService, AccountAppService>();
builder.Services.AddScoped<IUserAccountService, UserAccountAppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
