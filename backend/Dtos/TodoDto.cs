namespace backend.Dtos;

public record class TodoDto
(
    int userId,
    int id,
    string title,
    bool complete
);
