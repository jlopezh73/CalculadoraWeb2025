var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Todos",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("Todos");

//http://localhost:5030/operacion?op1=12&op2=6&operacion=1
app.MapGet("/operacion", (double op1, double op2, int operacion) =>
{    
    Operaciones ops = new Operaciones();
    var resul = ops.ejecutar(op1, op2, operacion);
    return new {resultado=resul};
})
.WithName("RealizarOperacion");

app.Run();


