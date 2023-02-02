
namespace Gp.Test.Api.DTO
{
    public class PersonasDTO
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty!;
        public string Edad { get; set; } = string.Empty!;
        public string Domicilio { get; set; } = string.Empty!;
        public string? Telefono { get; set; }
        public string? Profesion { get; set; }
    }
}
