using backend.EndPoints;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapTodoEndpoints();


app.Run();