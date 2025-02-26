using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public record class CreateTodo
(
    int userId,
    [Required] [StringLength(50)] string title,
    [Required] bool complete
);
