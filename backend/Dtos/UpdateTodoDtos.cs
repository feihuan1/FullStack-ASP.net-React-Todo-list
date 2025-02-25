namespace backend.Dtos;

public record class UpdateTodoDtos
(
    int userId,
    string title,
    bool complete
);
