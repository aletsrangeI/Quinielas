using Quinielas.Domain.Common;

namespace Quinielas.Domain.Entities
{
    public class ContenidoCatalogo : BaseAuditableEntity
    {
        public string Descripcion { get; set; }
        public int IdCatalogo { get; set; }
        public string Categoria { get; set; }
    }
}
