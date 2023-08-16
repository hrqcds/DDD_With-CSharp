using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Person : Entity
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "O Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "A Idade é obrigatória")]
    [Range(0, 150, ErrorMessage = "A idade deve está entre 0 e 150 anos")]
    public int Age { get; set; }
}
