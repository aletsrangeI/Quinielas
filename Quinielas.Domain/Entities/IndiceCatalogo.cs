using Quinielas.Domain.Common;

namespace Quinielas.Domain.Entities
{

    public class IndiceCatalogo : BaseAuditableEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
