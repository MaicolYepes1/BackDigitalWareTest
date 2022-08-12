namespace DigitalWare.MODELS.Models
{
    public class ProductoModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Precio { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Cantidad { get; set; }
    }
}
