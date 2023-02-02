namespace Gp.Test.Entity
{
    using System.ComponentModel.DataAnnotations;
    public class Personas
    {
        [Key]
        public Guid Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Edad{ get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Profesion { get; set; }
    }
}