using System.ComponentModel.DataAnnotations;

namespace backend.Dtos;

public record class UpdateTodoDtos
(
    int userId,
    [Required] [StringLength(50)] string title,
    [Required] bool complete
);
