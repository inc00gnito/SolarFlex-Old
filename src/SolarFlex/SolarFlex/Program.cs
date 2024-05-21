var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var conn = builder.Configuration.GetConnectionString("DataBase");

app.MapGet("/", () => "Hello World!");

app.Run();
