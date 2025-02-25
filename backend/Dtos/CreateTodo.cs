namespace backend.Dtos;

public record class CreateTodo
(
    int userId,
    string title,
    bool complete
);
