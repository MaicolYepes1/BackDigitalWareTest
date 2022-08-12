using System;
using System.Collections.Generic;

namespace DigitalWare.MODELS.Entities
{
    public class ProductoEntitie
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Precio { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Cantidad { get; set; }
    }
}
