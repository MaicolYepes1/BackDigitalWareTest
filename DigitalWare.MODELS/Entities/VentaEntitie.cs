namespace DigitalWare.MODELS.Entities
{
    public class VentaEntitie
    {
        public int VentaId { get; set; }
        public string ProductoId { get; set; } = null!;
        public string? ClienteId { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorTotal { get; set; }
        public DateTime? FechaVenta { get; set; }
    }
}
