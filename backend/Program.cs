
using backend.Dtos;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

//https://jsonplaceholder.typicode.com/todos
//   {
//     "userId": 1,
//     "id": 1,
//     "title": "delectus aut autem",
//     "completed": false
//   },

const string GetTodoEndpointName = "GetTodo";

List<TodoDto> todos = [
    new (
        1,
        1,
        "go shoppping",
        false
    ),
    new (
        1,
        2,
        "Play with kids",
        false
    ),
    new (
        1,
        3,
        "Work overtime",
        false
    )
]; 


app.MapGet("/todos", () => {
    return Results.Ok(todos);
});


app.MapGet("/todos/{id}", (int id) => {
    TodoDto? todo = todos.Find(todo => todo.id == id);

    return todo is null ? Results.NotFound() : Results.Ok(todo);
})
    .WithName(GetTodoEndpointName);


app.MapPost("/todos", (CreateTodo newTodo) => {
    TodoDto todo = new(
        newTodo.userId,
        todos.Count + 1,
        newTodo.title,
        newTodo.complete
    );
    todos.Add(todo);

    return Results.CreatedAtRoute(GetTodoEndpointName, new {id = todo.id}, todo);
});

app.MapPut("/todos/{id}", (int id, UpdateTodoDtos updatedTodo) => {
    var index = todos.FindIndex((todo)=> todo.id == id);

    if(index == -1){
        return Results.NotFound();
    }

    todos[index] = new TodoDto(
        updatedTodo.userId,
        id,
        updatedTodo.title,
        updatedTodo.complete
    );

    return Results.NoContent();
});

app.MapDelete("/todos/{id}", (int id) => {
    todos.RemoveAll(todo => todo.id == id);

    return Results.NoContent();
});

app.Run();