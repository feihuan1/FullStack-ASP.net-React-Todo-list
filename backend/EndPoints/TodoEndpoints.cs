using backend.Dtos;

namespace backend.EndPoints;

public static class TodoEndpoints
{
    const string GetTodoEndpointName = "GetTodo";

    private static readonly List<TodoDto> todos = [
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

    public static RouteGroupBuilder MapTodoEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("todos")
                .WithParameterValidation();

        group.MapGet("/", () =>
        {
            return Results.Ok(todos);
        });


        group.MapGet("/{id}", (int id) =>
        {
            TodoDto? todo = todos.Find(todo => todo.id == id);

            return todo is null ? Results.NotFound() : Results.Ok(todo);
        })
            .WithName(GetTodoEndpointName);


        group.MapPost("/", (CreateTodo newTodo) =>
        {
            TodoDto todo = new(
                newTodo.userId,
                todos.Count + 1,
                newTodo.title,
                newTodo.complete
            );
            todos.Add(todo);

            return Results.CreatedAtRoute(GetTodoEndpointName, new { id = todo.id }, todo);
        });

        group.MapPut("/{id}", (int id, UpdateTodoDtos updatedTodo) =>
        {
            var index = todos.FindIndex((todo) => todo.id == id);

            if (index == -1)
            {
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

        group.MapDelete("/{id}", (int id) =>
        {
            todos.RemoveAll(todo => todo.id == id);

            return Results.NoContent();
        });

        return group;
    }

}
