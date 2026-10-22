using System.ComponentModel.DataAnnotations;

namespace ClinicaVida.Web.Models;

public class Paciente
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "Informe o CPF do paciente.")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O CPF tem 14 caracteres com a máscara.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Use o formato 000.000.000-00.")]
    public string Cpf { get; set; } = string.Empty;

    public DateTime DataNascimento { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }
}