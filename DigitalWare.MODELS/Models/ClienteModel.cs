namespace DigitalWare.MODELS.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; } = null!;
        public string? Apellidos { get; set; }
        public int? Edad { get; set; }
    }
}
