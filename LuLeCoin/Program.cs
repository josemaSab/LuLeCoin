
using LuLeCoin.RedP2P;
using LuLeCoin.RedP2P.Servicios;

var builder = WebApplication.CreateBuilder(args);
// Inizialize lulecoin
Nodo nodo1 = new Nodo("192.168.1.20", 8080);
Nodo nodo2 = new Nodo("192.168.1.30", 8080);
NodoService.addNodo(nodo1);
NodoService.addNodo(nodo2);
//------------------------------

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



