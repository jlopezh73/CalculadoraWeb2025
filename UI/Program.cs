var builder = WebApplication.CreateBuilder(args);


var OperacionesUrlSvc = builder.Configuration["OperacionesUrlService"];

builder.Services.AddHttpClient("OperacionesService", client =>
{ 
    client.BaseAddress = new Uri(OperacionesUrlSvc);
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<DatosOperacion>();
builder.Services.AddSingleton<IOperaciones, OperacionesGW>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();
app.MapRazorPages();
app.MapFallbackToPage("/Operaciones");
app.Run();
